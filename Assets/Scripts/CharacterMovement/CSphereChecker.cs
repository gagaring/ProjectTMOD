using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Game.Entity
{
	public class CSphereChecker : MonoBehaviour
	{
		[SerializeField] private float _radius;
		[SerializeField] private bool _negate = false;
		[SerializeField] private LayerMaskReference _checkMask;
		[SerializeField] private BoolVariable _isCollided;

		private bool IsCollided
		{
			set
			{
				if (_isCollided.Value == value)
					return;
				_isCollided.Value = value;
			}
		}

		protected void Awake()
		{
			_isCollided.Value = !_negate;
		}

		public void Update()
		{
			var check = Physics.CheckSphere(transform.position, _radius, _checkMask.Value);
			IsCollided = _negate ? !check : check;
		}
	}
}