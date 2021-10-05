using UnityEngine;
using System.Collections.Generic;

namespace VEngine.AI.Goap
{
	[DisallowMultipleComponent]
	public class GoapPlanner
	{
		public Queue<GoapAction> Plan(GameObject agent, HashSet<GoapAction> availableActions, HashSet<KeyValuePair<eGoapEffects, object>> worldState, HashSet<KeyValuePair<eGoapEffects, object>> goal)
		{
			ResetAvailableActions(availableActions);

			var usableActions = GetUsableActions(agent, availableActions);
			var leaves = new List<Node>();
			var start = new Node(null, 0, worldState, null);
			var success = BuildGraph(start, leaves, usableActions, goal);
			if (!success)
			{
				//VLog.Log( VLog.eFlag.AI, VLog.eLevel.Warning, $"NO PLAN");
				return null;
			}
			var cheapest = GetCheapestLeaf(leaves);
			var result = CreateReverseResult(cheapest);
			return CreateResultQueue(result);
		}

		#region Create plan
		private Queue<GoapAction> CreateResultQueue(List<GoapAction> result)
		{
			return new Queue<GoapAction>(result);
		}

		private void ResetAvailableActions(HashSet<GoapAction> availableActions)
		{
			foreach (GoapAction current in availableActions)
				current.DoReset();
		}

		private HashSet<GoapAction> GetUsableActions(GameObject agent, HashSet<GoapAction> availableActions)
		{
			var usableActions = new HashSet<GoapAction>();
			foreach (GoapAction a in availableActions)
			{
				if (a.CheckProceduralPrecondition(agent))
					usableActions.Add(a);
			}
			return usableActions;
		}

		private Node GetCheapestLeaf(List<Node> leaves)
		{
			Node cheapest = null;
			foreach (Node leaf in leaves)
			{
				if (cheapest == null)
				{
					cheapest = leaf;
					continue;
				}
				if (leaf.RunningCost < cheapest.RunningCost)
					cheapest = leaf;
			}
			return cheapest;
		}

		private List<GoapAction> CreateReverseResult(Node cheapest)
		{
			//TODO helyes tarolos hasznalata
			var result = new List<GoapAction>();
			Node n = cheapest;
			while (n != null)
			{
				if (n.Action != null)
					result.Insert(0, n.Action);
				n = n.Parent;
			}
			return result;
		}
		#endregion

		#region Create graph
		private bool BuildGraph(Node parent, List<Node> leaves, HashSet<GoapAction> usableActions, HashSet<KeyValuePair<eGoapEffects, object>> goals)
		{
			var foundOne = false;
			foreach (GoapAction action in usableActions)
			{
				if (!AllInStates(action.Preconditions, parent.State))
					continue;

				var currentState = PopulateState(parent.State, action.Effects);
				var node = new Node(parent, parent.RunningCost + action.Cost, currentState, action);

				if (AtleaseOneInStates(goals, currentState))
				{
					leaves.Add(node);
					foundOne = true;
					continue;
				}

				var subset = ActionSubset(usableActions, action);
				if (BuildGraph(node, leaves, subset, goals))
					foundOne = true;
			}
			return foundOne;
		}

		private HashSet<GoapAction> ActionSubset(HashSet<GoapAction> actions, GoapAction removeMe)
		{
			var subset = new HashSet<GoapAction>();
			foreach (GoapAction a in actions)
			{
				if (!a.Equals(removeMe))
					subset.Add(a);
			}
			return subset;
		}

		#region InStates
		private bool AllInStates(HashSet<KeyValuePair<eGoapEffects, object>> tests, HashSet<KeyValuePair<eGoapEffects, object>> states)
		{
			foreach (var test in tests)
			{
				if (!InStates(test, states))
					return false;
			}
			return true;
		}

		private bool AtleaseOneInStates(HashSet<KeyValuePair<eGoapEffects, object>> tests, HashSet<KeyValuePair<eGoapEffects, object>> states)
		{
			foreach (var test in tests)
			{
				if (InStates(test, states))
					return true;
			}
			return false;
		}

		private bool InStates(KeyValuePair<eGoapEffects, object> test, HashSet<KeyValuePair<eGoapEffects, object>> states)
		{
			foreach (var state in states)
			{
				if (state.Equals(test))
					return true;
			}
			return false;
		}
		#endregion

		#region Populate state
		private HashSet<KeyValuePair<eGoapEffects, object>> PopulateState(HashSet<KeyValuePair<eGoapEffects, object>> currentStates, HashSet<KeyValuePair<eGoapEffects, object>> stateChanges)
		{
			var states = new HashSet<KeyValuePair<eGoapEffects, object>>(currentStates);
			foreach (var change in stateChanges)
			{
				if (InStates(change, states))
					states.RemoveWhere((KeyValuePair<eGoapEffects, object> kvp) => { return kvp.Key.Equals(change.Key); });

				states.Add(new KeyValuePair<eGoapEffects, object>(change.Key, change.Value));
			}
			return states;
		}
		#endregion
		#endregion

		private class Node
		{
			public Node Parent;
			public float RunningCost;
			public HashSet<KeyValuePair<eGoapEffects, object>> State;
			public GoapAction Action;

			public Node(Node parent, float runningCost, HashSet<KeyValuePair<eGoapEffects, object>> state, GoapAction action)
			{
				Parent = parent;
				RunningCost = runningCost;
				State = state;
				Action = action;
			}
		}
	}
}
