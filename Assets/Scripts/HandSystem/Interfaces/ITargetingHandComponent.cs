using VEngine.Items;
using VEngine.SO.Variables;

namespace VEngine.HandSystem
{
	public interface ITargetingHandComponent
	{
		bool Targeting(IItem item, bool pressed, ITransformSOReference handPosition, ITransformSOReference viewDirection);
	}
}
