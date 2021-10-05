using UnityEngine;

namespace VEngine.CCTV.Tests
{
	public class CCTVRotateableBehaviourTest : CCTVRotateableBehaviour, CCTVRotateableTest.ITestData
	{
		[SerializeField] private bool _canRPos;
		[SerializeField] private bool _canRNeg;

		public bool CanRotatePositive => _canRPos;
		public bool CanRotateNegative => _canRNeg;

		protected override void CreateRotateable() => new CCTVRotateableTest(this, this);
	}
}
