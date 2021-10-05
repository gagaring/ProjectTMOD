
namespace VEngine.GUI.Draggable
{
	public interface IDraggableButtonBehaviour
	{
		IDraggableButtonEvents Events { get; }
		IDraggableButtonHandler Handler { get; }
		IParentHandler ParentHandler { get; }
		IClickEvents ClickEvents { get; }
	}
}
