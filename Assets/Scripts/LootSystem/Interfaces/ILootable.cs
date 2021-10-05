using System;
using UnityEngine;
using VEngine.Items;

namespace VEngine.LootSystem
{
	public interface ILootable
	{
		IItem Item { get; }
		uint CurrentAmount { get; set; }
		GameObject GameObject { get; }

		Action<uint> OnCurrentAmountChanged { get; set; }
	}
}