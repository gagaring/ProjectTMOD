
namespace VEngine.CCTV
{
	public interface ICCTVRotateable
	{
		bool CanRotatePositive { get; }
		bool CanRotateNegative { get; }

		void Rotate(bool positivDir);
	}
}
