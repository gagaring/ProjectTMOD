using UnityEngine;
using VEngine.ObjectPool;

namespace VEngine.LootSystem.Signboard
{
    public class LootableSignboardBehaviour : MonoBehaviour, ILootableSignboardBehaviour, LootableSignboard.IData
    {
        [SerializeField] ObjectPoolEntity _entity;
		[SerializeField] private uint _currentAmount;

		public ILootableSignboard LootableObject { get; private set; }

		public Transform Transform => transform;
		public IObjectPoolEntity LootableEntity => _entity;

		public uint CurrentAmount { get => _currentAmount; set => _currentAmount = value; }

		private void Awake() => LootableObject = new LootableSignboard(this);
	}
}
