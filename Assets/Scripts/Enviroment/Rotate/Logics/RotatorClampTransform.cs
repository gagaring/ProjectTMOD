using UnityEngine;

namespace VEngine.Enviroment.Rotate
{
	public class RotatorClampTransform : IRotatorClamp
	{
		private readonly IData _data;
		private readonly IComponents _components;

		public RotatorClampTransform(IData data, IComponents components)
		{
			_data = data;
			_components = components;
		}

		public void Rotate(Vector3 value, float deltaTime)
		{
			//it may be not good
			RotateX(value.x, deltaTime);
			RotateY(value.y, deltaTime);
			RotateZ(value.z, deltaTime);
		}

		public void RotateX(float value, float deltaTime)
		{
			value *= deltaTime * _data.Speed;
			var rotation = _components.TargetX.localRotation.eulerAngles;
			var clampedValue = GetClampedValue(rotation.x);
			rotation.x = Mathf.Clamp(clampedValue + value, _data.LimitX.x, _data.LimitX.y);
			_components.TargetX.localRotation = Quaternion.Euler(rotation);
		}

		public void RotateY(float value, float deltaTime)
		{
			value *= deltaTime * _data.Speed;
			var rotation = _components.TargetY.localRotation.eulerAngles;
			var clampedValue = GetClampedValue(rotation.y);
			rotation.y = Mathf.Clamp(clampedValue + value, _data.LimitY.x, _data.LimitY.y);
			_components.TargetY.localRotation = Quaternion.Euler(rotation);
		}

		public void RotateZ(float value, float deltaTime)
		{
			value *= deltaTime * _data.Speed;
			var rotation = _components.TargetZ.localRotation.eulerAngles;
			var clampedValue = GetClampedValue(rotation.z);
			rotation.z = Mathf.Clamp(clampedValue + value, _data.LimitZ.x, _data.LimitZ.y);
			_components.TargetZ.localRotation = Quaternion.Euler(rotation);
		}

		private float GetClampedValue(float x)
		{
			if (x > 180)
				x -= 360;
			else if (x < -180)
				x += 360;
			return x;
		}

		public interface IData
		{
			Vector2 LimitX { get; }
			Vector2 LimitY { get; }
			Vector2 LimitZ { get; }
			float Speed { get; }
		}

		public interface IComponents
		{
			Transform TargetX { get; }
			Transform TargetY { get; }
			Transform TargetZ { get; }
		}
	}
}
