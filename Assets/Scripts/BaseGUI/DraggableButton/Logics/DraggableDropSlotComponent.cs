using System;

namespace VEngine.GUI.Draggable
{
	public class DraggableDropSlotComponent : IDraggableDropSlotHandler, IDropSlotChangedEvent
	{
		private IDropSlot _dropSlot = null;
		private IDraggableButtonHandler _draggableButtonHandler;

		public Action<IDropSlot, IDropSlot> OnDropSlotChanged { get; set; }

		public virtual IDropSlot DropSlot
		{
			get => _dropSlot;
			set
			{
				var prev = _dropSlot;
				_dropSlot = value;
				OnDropSlotChanged?.Invoke(prev, value);
			}
		}

		public DraggableDropSlotComponent(IDraggableButtonHandler draggableButtonHandler, IDraggableButtonEvents draggableButtonEvents)
		{
			_draggableButtonHandler = draggableButtonHandler;
			draggableButtonEvents.OnStateChanged += OnDraggableStateChanged;
		}

		private void OnDraggableStateChanged(eState state)
		{
			if (state != eState.StandBy || DropSlot == null)
				return;
			_draggableButtonHandler.Position = DropSlot.Position;
		}
	}
}
