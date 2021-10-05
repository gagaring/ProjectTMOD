using UnityEngine;
using VEngine.GUI.Draggable;

namespace VEngine.GUI.Limiter
{
	public class DraggableAreaLimiterBehaviour : MonoBehaviour
	{
		[SerializeField] private DraggableButtonBehaviour _draggable;

		private IAreaLimiter _limiter;

		private void Start()
		{
			var areaHolder = GetComponentInParent<IAreaLimiterAreaHolder>();
			CreateLimiter(areaHolder.Area);
		}

		private void CreateLimiter(IAreaLimiterArea area)
		{
			_limiter = new DraggableAreaLimiter(area, _draggable.Handler, _draggable.Events);
		}
	}
}
