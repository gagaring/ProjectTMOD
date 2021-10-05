using UnityEngine;
using VEngine.ObjectPool;

namespace VEngine.LootSystem.Signboard
{
	public interface ILootableSignboard
	{
		string Name { get; }
		GameObject GameObject { get; }
		Vector3 Position { get; }
		IObjectPoolEntity LootableEntity { get; }

		LootableBehaviour AttachedModel { get; set; }
	}
}
