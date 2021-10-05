namespace VEngine.LootSystem.Signboard
{
    public interface ILootableSignboardMap : ILootableSignboardMapReference
    {
        void Clear();
        void Add(ILootable lootable, ILootableSignboard signboard);
        void Remove(ILootable lootable);
    }

    public interface ILootableSignboardMapReference
    {
        bool ContainsKey(ILootable lootable);
        ILootableSignboard Get(ILootable lootable);
        bool TryGet(ILootable lootable, out ILootableSignboard lootableSignboard);
    }
}
