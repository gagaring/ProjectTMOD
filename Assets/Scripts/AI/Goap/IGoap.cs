using System.Collections.Generic;

namespace VEngine.AI.Goap
{
	public interface IGoap
	{
		HashSet<KeyValuePair<eGoapEffects, object>> GetWorldStates();
		HashSet<KeyValuePair<eGoapEffects, object>> CreateGoalStates();

		void ActionsFinished();

		void PlanFailed(HashSet<KeyValuePair<eGoapEffects, object>> failedGoal);
		void PlanFound(HashSet<KeyValuePair<eGoapEffects, object>> goal, Queue<GoapAction> actions);
		void PlanAborted(GoapAction aborter);

		bool MoveAgent(GoapAction nextAction);
	}
}
