namespace VEngine.LootSystem.Signboard
{
	public interface ILootableSignboardSystem
	{
		void ActivateLootableObject(ILootableSignboard obj);
		void DeactivateLootableObject(ILootableSignboard obj);
	}
}
