using UnityEngine;

namespace VEngine.GUI.Limiter
{
	public class AreaLimiter : IAreaLimiter
	{
		private float XMin { get => _area.XMin; }
		private float XMax { get => _area.XMax; }

		private float YMin { get => _area.YMin; }
		private float YMax { get => _area.YMax; }

		private IAreaLimiterArea _area;

		public AreaLimiter(IAreaLimiterArea limitArea)
		{
			_area = limitArea;
		}

		public void OnPositionChanged(IAreaLimiterTarget target)
		{
			var position = target.Position;
			bool limitedY = LimitY(ref position);
			if (!LimitX(ref position) && !limitedY)
				return;
			target.Position = position;
		}

		private bool LimitX(ref Vector2 position)
		{
			if (position.x > XMax)
			{
				position.x = XMax;
				return true;
			}
			if (position.x < XMin)
			{
				position.x = XMin;
				return true;
			}
			return false;
		}

		private bool LimitY(ref Vector2 position)
		{
			if (position.y > YMax)
			{
				position.y = YMax;
				return true;
			}
			if (position.y < YMin)
			{
				position.y = YMin;
				return true;
			}
			return false;
		}
	}
}
