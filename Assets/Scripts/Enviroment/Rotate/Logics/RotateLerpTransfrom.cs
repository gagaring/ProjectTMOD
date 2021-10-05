using UnityEngine;

namespace VEngine.Enviroment.Rotate
{
	public class RotateLerpTransfrom : IRotatorLerp
	{
		private readonly IData _data;
		private readonly IComponents _components;

		public RotateLerpTransfrom(IData data, IComponents components)
		{
			_data = data;
			_components = components;
		}

		public void Rotate(float ratio)
		{
			_components.Target.localRotation = Quaternion.Euler(Vector3.Lerp(_data.From, _data.To, ratio));
		}

		public interface IData
		{
			Vector3 From { get; }
			Vector3 To { get; }
		}

		public interface IComponents
		{
			Transform Target { get; }
		}
	}
}
