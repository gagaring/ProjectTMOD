namespace VEngine.LootSystem
{
	public interface ILootableCollection : ILootableCollectionReference
	{
		void Clear();
		void Add(ILootable lootable);
		void Remove(ILootable lootable);
	}

	public interface ILootableCollectionReference
	{
		bool IsEmpty { get; }
	}
}