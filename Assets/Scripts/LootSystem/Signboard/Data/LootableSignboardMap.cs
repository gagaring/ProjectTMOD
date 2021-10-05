using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.LootSystem.Signboard
{
	[CreateAssetMenu(menuName = "SO/Loot/SignboardMap")]
    public class LootableSignboardMap : SerializedScriptableObject, ILootableSignboardMap
    {
		[ReadOnly][SerializeField] private Dictionary<ILootable, ILootableSignboard> _lootableMap = new Dictionary<ILootable, ILootableSignboard>();

		public void Clear() => _lootableMap.Clear();
		public bool ContainsKey(ILootable lootable) => _lootableMap.ContainsKey(lootable);
		public ILootableSignboard Get(ILootable lootable) => _lootableMap[lootable];
		public bool TryGet(ILootable lootable, out ILootableSignboard lootableSignboard) => _lootableMap.TryGetValue(lootable, out lootableSignboard);
		public void Add(ILootable lootable, ILootableSignboard signboard) => _lootableMap[lootable] = signboard;
		public void Remove(ILootable lootable) => _lootableMap.Remove(lootable);
    }

	[Serializable]
	public class LootableSignboardMapReference
	{
		[SerializeField] private LootableSignboardMap _map;

		public ILootableSignboardMapReference MapReference => _map;
	}
}
