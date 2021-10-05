using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.LootSystem
{
    [CreateAssetMenu(menuName = "SO/Loot/LootableEvent")]
    public class LootableGameEvent : TGameEvent<ILootable>
    {
    }
}
