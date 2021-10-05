using UnityEngine;
using UnityEngine.EventSystems;

namespace VEngine.GUI.Draggable
{
	public class DropSlot : IDropSlot
	{
		protected readonly IDropSlotComponents _components;

		public Vector2 Position => _components.Position;

		public DropSlot(IDropSlotComponents components)
		{
			_components = components;
		}

		public virtual void OnDrop(PointerEventData eventData)
		{
			var dropSlotHandler = eventData.pointerDrag.GetComponent<IDropSlotHandler>();
			if (dropSlotHandler == null)
				return;
			OnDraggableButtonDropped(dropSlotHandler);
		}

		private void OnDraggableButtonDropped(IDropSlotHandler dropSlotHandler)
		{
			dropSlotHandler.DropSlot = this;
		}

		public interface IDropSlotComponents
		{
			Vector2 Position { get; }
		}
	}
}
