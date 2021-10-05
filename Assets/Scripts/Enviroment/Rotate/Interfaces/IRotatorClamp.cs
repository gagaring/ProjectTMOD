using UnityEngine;

namespace VEngine.Enviroment.Rotate
{
	public interface IRotatorClamp
	{
		void Rotate(Vector3 value, float deltaTime);
		void RotateX(float value, float deltaTime);
		void RotateY(float value, float deltaTime);
		void RotateZ(float value, float deltaTime);
	}
}
