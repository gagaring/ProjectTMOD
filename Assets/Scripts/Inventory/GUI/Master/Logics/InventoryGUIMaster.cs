using System;
using VEngine.Input;

namespace VEngine.Inventory.GUI
{
	public class InventoryGUIMaster : IInventoryGUIMaster
	{
		private readonly IData _data;

		public InventoryGUIMaster(IData data)
		{
			_data = data;
		}

		public void Open(bool open)
		{
			_data.OpenInventory(open);
			_data.OpenStash(open && _data.StashAvailable);
			_data.InputActivator.Activate(open);
		}

		public interface IData
		{
			Action<bool> OpenInventory { get; }
			Action<bool> OpenStash { get; }
			bool StashAvailable { get; }
			IInputActivator InputActivator { get; }
		}
	}
}
