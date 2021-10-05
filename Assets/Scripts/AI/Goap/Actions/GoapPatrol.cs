using UnityEngine;

namespace VEngine.AI.Goap
{
	public class GoapPatrol : GoapAction
	{
		[SerializeField] private AIWaypointNetwork _network;

		private int _currentIndex;

		public GoapPatrol()
		{
			//AddPrecondition(WANT_TO_PANTROL, true);
			//AddEffect(PATROL, true);
		}

		public override bool CheckProceduralPrecondition(GameObject agent)
		{
			throw new System.NotImplementedException();
		}

		public override bool IsDone()
		{
			throw new System.NotImplementedException();
		}

		public override void OnMove()
		{
			throw new System.NotImplementedException();
		}

		public override bool Perform(GameObject agent)
		{
			throw new System.NotImplementedException();
		}

		public override bool RequiresInRange()
		{
			throw new System.NotImplementedException();
		}
	}
}
