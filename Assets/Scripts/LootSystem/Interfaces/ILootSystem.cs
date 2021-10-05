namespace VEngine.LootSystem
{
	public interface ILootSystem
	{
		void OnLootableSelected(ILootable lootable);
		void PickUpLootable();
	}
}
