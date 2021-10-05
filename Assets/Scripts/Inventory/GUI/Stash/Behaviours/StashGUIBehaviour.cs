using System;
using UnityEngine;
using VEngine.GUI;
using VEngine.SO.Variables;

namespace VEngine.Inventory.GUI.Stash
{
	public class StashGUIBehaviour : InventoryGUIBehaviour, StashGUI.IStashData
	{
		[SerializeField] private GameObject _availableTitle;
		[SerializeField] private GameObject _notAvailableTitle;
		[SerializeField] private BoolReference _isStashEnabled;

		public GameObject AvailableTitle => _availableTitle;
		public GameObject NotAvailableTitle => _notAvailableTitle;

		public bool IsStashEnabled => _isStashEnabled.Value;

		protected override InventoryGUIBuilder CreateBuilder()
		{
			return new StashGUIBuilder(SlotPrefab);
		}
		
		protected override IPanel CreatePanel() => new StashGUI(this);
	}
}
