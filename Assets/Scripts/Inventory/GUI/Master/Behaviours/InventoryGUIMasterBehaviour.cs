using System;
using UnityEngine;
using VEngine.Input;
using VEngine.SO.Variables;

namespace VEngine.Inventory.GUI
{
	public class InventoryGUIMasterBehaviour : MonoBehaviour, InventoryGUIMaster.IData
	{
		[SerializeField] private InventoryGUIBehaviour _inventoryGUI;
		[SerializeField] private InventoryGUIBehaviour _stash;
		[SerializeField] private BoolReference _stashAvailable;
		[SerializeField] private InputActivator _inputActivator;

		private IInventoryGUIMaster _master;

		public Action<bool> OpenInventory => _inventoryGUI.Open;
		public Action<bool> OpenStash => _stash.Open;
		public bool StashAvailable => _stashAvailable.Value;
		public IInputActivator InputActivator => _inputActivator;

		public IInventoryGUIMaster Master
		{
			get
			{
				if(_master == null)
					_master = new InventoryGUIMaster(this);
				return _master;
			}
		}

		protected void Awake() => Open(false);
		protected void OnDestroy() => _inputActivator.Deactivate();

		public void Open(bool open)
		{
			Master.Open(open);
		}
	}
}
