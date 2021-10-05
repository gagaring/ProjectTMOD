using UnityEngine;

namespace VEngine.GUI.Draggable
{
	public class DraggableParentHandler : IDraggableParentHandler
	{
		private readonly IParentHandler _dragParentHandler;
		private readonly IDraggableButtonEvents _draggableButtonEvents;

		private readonly Transform _normalParent;
		private readonly Transform _dragParent;

		public DraggableParentHandler(IParentHandler dragParentHandler, Transform dragParent)
		{
			_dragParentHandler = dragParentHandler;
			_dragParent = dragParent;
			_normalParent = dragParentHandler.Parent;
		}

		public void SetParent(eState state)
		{
			_dragParentHandler.Parent = state == eState.OnDrag ? _dragParent : _normalParent;
		}
	}
}
