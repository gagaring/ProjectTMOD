using System;
using UnityEngine;

namespace VEngine.Enviroment.Rotate
{
	public class RotatorTransform : IRotator
	{
		private readonly IData _data;
		private readonly IComponents _components;

		public RotatorTransform(IData data, IComponents components)
		{
			_data = data;
			_components = components;
		}

		public void Rotate()
		{
			RotateX(_data.RotateX);
			RotateY(_data.RotateY);
			RotateZ(_data.RotateZ);
		}

		public void RotateX()
		{
			RotateX(_data.RotateX);
		}

		public void RotateY()
		{
			RotateY(_data.RotateY);
		}

		public void RotateZ()
		{
			RotateZ(_data.RotateZ);
		}

		private void RotateX(float value)
		{
			if (value == 0)
				return;
			Rotate(_components.Target.up * value);
		}

		private void RotateY(float value)
		{
			if (value == 0)
				return;
			Rotate(_components.Target.right * value);
		}

		private void RotateZ(float value)
		{
			if (value == 0)
				return;
			Rotate(_components.Target.forward * value);
		}

		public void Rotate(Vector3 rotate)
		{
			_components.Target.Rotate(rotate * _data.Speed, Space.World);
		}

		public interface IData
		{
			float Speed { get; }
			float RotateX { get; }
			float RotateY { get; }
			float RotateZ { get; }
		}

		public interface IComponents
		{
			Transform Target { get; }
		}
	}
}
