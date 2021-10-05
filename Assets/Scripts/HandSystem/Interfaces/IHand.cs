using VEngine.Items;

namespace VEngine.HandSystem
{
	public interface IHand
	{
		void Equip(IItem item);
		void Use(bool start);
		void Targeting(bool pressed);
	}
}
