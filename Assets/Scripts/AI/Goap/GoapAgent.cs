using UnityEngine;
using System.Collections.Generic;
using System;
using VEngine.Log;
using Sirenix.OdinInspector;

namespace VEngine.AI.Goap
{
	[DisallowMultipleComponent]
	public class GoapAgent : SerializedMonoBehaviour
	{
		#region members
		[SerializeField] [ReadOnly] private GoapAction _currentAction;

		private Fsm.Fsm _stateMachine;

		private Fsm.Fsm.FsmState _idleState;
		private Fsm.Fsm.FsmState _moveToState;
		private Fsm.Fsm.FsmState _performActionState;

		private HashSet<GoapAction> _availableActions;
		private Queue<GoapAction> _currentActions;

		private GoapPlanner _planner;
		private IGoap _dataProvider;
		#endregion

		#region properties
		private bool HasActionPlan { get { return _currentActions.Count > 0; } }
		public bool PlanInterrupted { get; set; }
		#endregion

		public Action OnPlanInterrupted;

		#region init
		protected virtual void Start()
		{
			_stateMachine = new Fsm.Fsm();
			_availableActions = new HashSet<GoapAction>();
			_currentActions = new Queue<GoapAction>();
			_planner = new GoapPlanner();
			FindDataProvider();
			CreateIdleState();
			CreateMoveToState();
			CreatePerformActionState();
			_stateMachine.PushState(_idleState);
			LoadActions();
		}

		public void AddDataProvider(IGoap dataProvider)
		{
			_dataProvider = dataProvider;
		}

		private void LoadActions()
		{
			GoapAction[] actions = gameObject.GetComponents<GoapAction>();
			foreach (GoapAction a in actions)
				_availableActions.Add(a);

			VLog.Log(VLog.eFlag.AI, VLog.eLevel.Normal, $"Found actions: {actions}");
		}

		private void FindDataProvider()
		{
			if (_dataProvider != null)
				return;
			_dataProvider = gameObject.GetComponent<IGoap>();
		}
		#region Create states
		#region Idle
		private void CreateIdleState()
		{
			_idleState = (fsm, gameObj) =>
			{
				if (InterruptPlan(fsm))
					return;
				var worldState = _dataProvider.GetWorldStates();
				var goals = _dataProvider.CreateGoalStates();

				var plan = _planner.Plan(gameObject, _availableActions, worldState, goals);
				if (plan == null)
					OnPlanningFailed(fsm, goals);
				else
					OnPlanningSuccess(fsm, goals, plan);
			};
		}

		private void OnPlanningSuccess(Fsm.Fsm fsm, HashSet<KeyValuePair<eGoapEffects, object>> goals, Queue<GoapAction> plan)
		{
			_currentActions = plan;
			_dataProvider.PlanFound(goals, plan);
			fsm.PopState();
			fsm.PushState(_performActionState);
		}

		private void OnPlanningFailed(Fsm.Fsm fsm, HashSet<KeyValuePair<eGoapEffects, object>> goals)
		{
#if UNITY_EDITOR
			var sGoals = GoalsToString(goals);
			VLog.Log(VLog.eFlag.AI, VLog.eLevel.Editor, $"Failed Plan: {sGoals}");
#endif
			_dataProvider.PlanFailed(goals);
			fsm.PopState();
			fsm.PushState(_idleState);
		}

		private string GoalsToString(HashSet<KeyValuePair<eGoapEffects, object>> goals)
		{
			string sGoals = "( ";
			foreach (var g in goals)
				sGoals += g.Key + " ";
			sGoals += ")";
			return sGoals;
		}

		#endregion

		#region move
		private void CreateMoveToState()
		{
			_moveToState = (fsm, gameObj) =>
			{
				if (InterruptPlan(fsm))
					return;
				_currentAction = _currentActions.Peek();
				if (_currentAction.RequiresInRange() && _currentAction.Target == null)
				{
					VLog.Log(VLog.eFlag.AI, VLog.eLevel.Error, $"Action requires a target but has none. Planning failed. You did not assign the target in your Action.checkProceduralPrecondition()");
					fsm.PopState();
					fsm.PopState();
					fsm.PushState(_idleState);
					return;
				}

				if (_dataProvider.MoveAgent(_currentAction))
					fsm.PopState();
				else
					_currentAction.OnMove();
			};
		}
		#endregion

		#region perform
		private void CreatePerformActionState()
		{
			_performActionState = (fsm, gameObj) =>
			{
				if (InterruptPlan(fsm))
					return;

				if (!HasActionPlan)
				{
					OnActionFinished(fsm);
					return;
				}
				RemoveCurrentActionIfDone();

				if (HasActionPlan)
					UseNextAction(fsm, gameObj);
				else
					OnActionFinished(fsm);

			};
		}

		private void UseNextAction(Fsm.Fsm fsm, GameObject gameObj)
		{
			_currentAction = _currentActions.Peek();
			bool inRange = _currentAction.RequiresInRange() ? _currentAction.InRange : true;

			if (inRange)
			{
				PerformNextAction(fsm, _currentAction, gameObj);
			}
			else
			{
				fsm.PushState(_moveToState);
			}
		}

		private void PerformNextAction(Fsm.Fsm fsm, GoapAction action, GameObject gameObj)
		{
			if (!action.Perform(gameObj))
			{
				fsm.PopState();
				fsm.PushState(_idleState);
				_dataProvider.PlanAborted(action);
			}
		}

		private void RemoveCurrentActionIfDone()
		{
			_currentAction = _currentActions.Peek();
			if (_currentAction.IsDone())
				_currentActions.Dequeue();
		}

		private void OnActionFinished(Fsm.Fsm fsm)
		{
			VLog.Log(VLog.eFlag.AI, VLog.eLevel.Normal, $"<color=green>Done actions</color>");
			fsm.PopState();
			fsm.PushState(_idleState);
			_dataProvider.ActionsFinished();
		}
		#endregion
		#endregion
		#endregion

		void Update()
		{
			_stateMachine.Update(gameObject);
		}

		public void AddAction(GoapAction a)
		{
			_availableActions.Add(a);
		}

		public GoapAction GetAction(Type action)
		{
			foreach (GoapAction g in _availableActions)
			{
				if (g.GetType().Equals(action))
					return g;
			}
			return null;
		}

		public void RemoveAction(GoapAction action)
		{
			_availableActions.Remove(action);
		}

		private bool InterruptPlan(Fsm.Fsm fsm)
		{
			if (!PlanInterrupted)
				return false;
			VLog.Log(VLog.eFlag.AI, VLog.eLevel.Normal, $"<color=red>Interrupted</color>");
			GoapAction currentAction = _currentActions.Count == 0 ? null : _currentActions.Peek();
			_currentActions.Clear();
			fsm.PushState(_idleState);
			_dataProvider.PlanAborted(currentAction);
			OnPlanInterrupted?.Invoke();
			PlanInterrupted = false;
			return true;
		}
	}
}
