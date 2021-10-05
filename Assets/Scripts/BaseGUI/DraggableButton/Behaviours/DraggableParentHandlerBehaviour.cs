using UnityEngine;

namespace VEngine.GUI.Draggable
{
	public class DraggableParentHandlerBehaviour : MonoBehaviour
	{
		[SerializeField] private DraggableButtonBehaviour _draggable;
		[SerializeField] private DragParentReference _dragParent;

		private IDraggableParentHandler _draggableParentHandler;

		private void Start()
		{
			_draggableParentHandler = new DraggableParentHandler(_draggable.ParentHandler, _dragParent.Value);
			_draggable.Events.OnStateChanged += _draggableParentHandler.SetParent;
		}
	}
}
