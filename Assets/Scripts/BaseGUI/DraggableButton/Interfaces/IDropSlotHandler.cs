using System;

namespace VEngine.GUI.Draggable
{
	public interface IDropSlotHandler
	{
		IDropSlot DropSlot { get; set; }
		Action<IDropSlot, IDropSlot> OnDropSlotChanged { get; set; }
	}
}
