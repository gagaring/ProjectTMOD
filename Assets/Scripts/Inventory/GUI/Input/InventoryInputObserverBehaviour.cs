using VEngine.Input;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.InventoryGUI.Input
{
	public class InventoryInputObserverBehaviour : InputObserverBehaviour, InventoryInputObserver.IInventoryData
	{
		[SerializeField] private BoolVariable _split;

		public IVariable<bool> Split => _split;

		protected override IInputObserver CreateObserver()
		{
			return new InventoryInputObserver(this, name);
		}
	}
}
