using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Inspector
{
    public class RotatorGUIBehaviour : MonoBehaviour
    {
        [SerializeField] private BoolVariable _rotateActive;

		protected void Awake()
		{
			_rotateActive.Value = false;
		}

		public void RotateActive(bool active)
		{
            _rotateActive.Value = active;
		}
	}
}
