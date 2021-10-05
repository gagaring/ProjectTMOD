using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Enviroment.Rotate
{
    public class RotatorTransformSOBehaviour : MonoBehaviour
    {
        [SerializeField] protected TransformSO _rotation;
        [SerializeField] protected FloatReference _speed;

		public void Rotate(float rotate)
		{
			rotate *= Time.deltaTime * _speed.Value;
			_rotation.Rotate(_rotation.Up, rotate);
		}

		public void RotateTo(Quaternion rotation)
		{
			_rotation.Rotation = rotation;
		}
	}
}
