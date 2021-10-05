namespace VEngine.CCTV.Tests
{
	public class CCTVRotateableTest : CCTVRotateable
	{
		private ITestData _data;

		public CCTVRotateableTest(ITestData data, IComponents components) : base(data, components)
			=> _data = data;

		public override bool CanRotateNegative => _data.CanRotateNegative;
		public override bool CanRotatePositive => _data.CanRotatePositive;

		public interface ITestData : IData
		{
			bool CanRotatePositive { get; }
			bool CanRotateNegative { get; } 
		}
	}
}