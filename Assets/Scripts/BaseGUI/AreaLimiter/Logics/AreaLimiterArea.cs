using UnityEngine;

namespace VEngine.GUI.Limiter
{
	public class AreaLimiterArea : IAreaLimiterArea
	{
		private readonly RectTransform _rectTransform;

		public AreaLimiterArea(RectTransform rectTransform)
		{
			_rectTransform = rectTransform;
		}

		public float XMin => _rectTransform.position.x - _rectTransform.rect.width;
		public float XMax => _rectTransform.position.x + _rectTransform.rect.width;
		public float YMin => _rectTransform.position.y - _rectTransform.rect.height;
		public float YMax => _rectTransform.position.y + _rectTransform.rect.height;
	}
}
