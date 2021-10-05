using UnityEngine.InputSystem;
using VEngine.Input;
using VEngine.Log;
using VEngine.SO.Events;
using VEngine.SO.Variables;

namespace VEngine.InventoryGUI.Input
{
	public class InventoryInputObserver : InputObserver
	{
		private readonly IInventoryData _data;

		public InventoryInputObserver(IInventoryData data, string name = "") : base(data, name)
		{
			_data = data;
			Register(_input.Inventory.Split, ctx => _data.Split.Value = IsPushed(ctx), false);

			VLog.Log(VLog.eFlag.Input, VLog.eLevel.Normal, $"InspectorInput Inited");
		}

		protected override void Reset()
		{
			_data.Split.Value = false;
		}

		public interface IInventoryData : IData
		{
			IVariable<bool> Split { get; }
		}
	}
}
