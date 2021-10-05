using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Inspector
{
	public class ObjectScalerBehaviour : MonoBehaviour
	{
		[SerializeField] private FloatReference _targetSize;

		private IObjectScaler _scaler;

		protected void Awake()
		{
			_scaler = new ObjectScaler(_targetSize);
		}

		public void Scale(GameObject target)
		{
			_scaler.Scale(target);
		}
	}
}
