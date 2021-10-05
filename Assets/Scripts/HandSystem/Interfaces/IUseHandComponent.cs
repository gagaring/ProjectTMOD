using VEngine.SO.Variables;

namespace VEngine.HandSystem
{
	public interface IUseHandComponent
	{
		bool Use(Items.IItem item, bool pressed, ITransformSOReference handPosition, ITransformSOReference viewDirection);
	}
}
