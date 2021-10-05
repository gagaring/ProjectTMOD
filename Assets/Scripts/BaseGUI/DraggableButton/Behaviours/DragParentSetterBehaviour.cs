using UnityEngine;

namespace VEngine.GUI.Draggable
{
	public class DragParentSetterBehaviour : MonoBehaviour
	{
		[SerializeField] private DragParentSO _dragParentSO;
		[SerializeField] private Transform _parent;

		protected void Awake()
		{
			_dragParentSO.Value = _parent;
		}
	}
}
