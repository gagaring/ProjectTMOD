using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.LootSystem
{
	[CreateAssetMenu(menuName = "SO/Loot/LootableContainer")]
	public class LootableContainer : SerializedScriptableObject, ILootableCollection
	{
		[ReadOnly][SerializeField] private HashSet<ILootable> _lootables = new HashSet<ILootable>();

		public bool IsEmpty => _lootables.Count == 0;
		public void Clear() => _lootables.Clear();
		public void Add(ILootable lootable) => _lootables.Add(lootable);
		public void Remove(ILootable lootable) => _lootables.Remove(lootable);
	}
}
