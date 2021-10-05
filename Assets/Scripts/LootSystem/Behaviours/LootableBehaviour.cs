using System;
using UnityEngine;
using VEngine.Items;

namespace VEngine.LootSystem
{
	public class LootableBehaviour : MonoBehaviour, ILootable, ILootableBehaviour
	{
		[SerializeField] private Item _item;
		[SerializeField] private uint _currentAmount;

		public IItem Item => _item;
		public GameObject GameObject => gameObject;
		public ILootable Lootable => this;

		public uint CurrentAmount 
		{
			get => _currentAmount;
			set
			{
				_currentAmount = value;
				OnCurrentAmountChanged?.Invoke(value);
			}
		}

		public Action<uint> OnCurrentAmountChanged { get; set; }
	}
}
