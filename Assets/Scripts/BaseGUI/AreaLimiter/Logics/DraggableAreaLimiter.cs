using UnityEngine;
using VEngine.GUI.Draggable;

namespace VEngine.GUI.Limiter
{
	public class DraggableAreaLimiter : AreaLimiter, IAreaLimiterTarget
	{
		private readonly IDraggableButtonHandler _handler;
		private readonly IDraggableButtonEvents _events;

		public Vector2 Position { get => _handler.Position; set => _handler.Position = value; }

		private IAreaLimiter _limiter;

		public DraggableAreaLimiter(IAreaLimiterArea area, IDraggableButtonHandler handler, IDraggableButtonEvents events) : base(area)
		{
			_handler = handler;
			_events = events;
			_limiter = new AreaLimiter(area);
			_events.OnPositionChanged += OnDraggablePositionChanged;
		}

		private void OnDraggablePositionChanged(Vector2 value)
		{
			_limiter.OnPositionChanged(this);
		}
	}
}
