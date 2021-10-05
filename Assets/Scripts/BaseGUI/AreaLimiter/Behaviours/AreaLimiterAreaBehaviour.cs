using UnityEngine;
using UnityEngine.UI;

namespace VEngine.GUI.Limiter
{
	public class AreaLimiterAreaBehaviour : MonoBehaviour, IAreaLimiterAreaHolder
	{
		[SerializeField] private RectTransform _rectTransform;

		public IAreaLimiterArea Area { get; set; }

		protected void Awake()
		{
			if (_rectTransform)
				_rectTransform = GetComponent<RectTransform>();
			Area = new AreaLimiterArea(_rectTransform);
		}
	}
}
