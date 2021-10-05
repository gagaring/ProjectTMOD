using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.LootSystem.Signboard
{
    [CreateAssetMenu(menuName = "SO/Loot/LootableSignboardEvent")]
    public class LootableSignboardGameEvent : TGameEvent<ILootableSignboard>
    {
    }
}
