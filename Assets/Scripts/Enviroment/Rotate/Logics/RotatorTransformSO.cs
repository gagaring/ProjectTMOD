using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Enviroment.Rotate
{
	public class RotatorTransformSO : IRotator
	{
		private readonly IData _data;
		private readonly IComponents _components;

		public RotatorTransformSO(IData data, IComponents components)
		{
			_data = data;
			_components = components;
		}

		public void Rotate()
		{
			RotateX();
			RotateY();
			RotateZ();
		}

		public void RotateX()
		{
			if (_data.RotateX == 0)
				return;
			_data.Target.Rotate(_data.Target.Right, _data.RotateX * _data.Speed * Time.deltaTime);
		}

		public void RotateY()
		{
			if (_data.RotateY == 0)
				return;
			_data.Target.Rotate(_data.Target.Up, _data.RotateY * _data.Speed * Time.deltaTime);
		}
		
		public void RotateZ()
		{
			if (_data.RotateZ == 0)
				return;
			_data.Target.Rotate(_data.Target.Forward, _data.RotateZ * _data.Speed * Time.deltaTime);
		}

		public interface IData
		{
			float Speed { get; }
			float RotateX { get; }
			float RotateY { get; }
			float RotateZ { get; }
			TransformSO Target { get; }
		}

		public interface IComponents
		{
		}
	}
}
