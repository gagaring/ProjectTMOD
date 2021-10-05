using System;
using UnityEngine;
using VEngine;

namespace VEngine.Player.Camera
{
	public class CameraPositioner
	{
		private readonly IData _data;
		private readonly IComponents _components;

		private Transform _target;

		public CameraPositioner(IData data, IComponents components)
		{
			_data = data;
			_components = components;
			_target = _components.DefaultTarget;
		}

		public void Update(float deltaTime)
		{
			if (_components.Camera == _target.position)
				return;
			var position = Vector3.MoveTowards(_components.Camera, _target.position, _data.Speed.x * deltaTime);
			position.y = Mathf.MoveTowards(_components.Camera.y, _target.position.y, _data.Speed.y * deltaTime);
			_components.Camera = position;
		}

		public void Transition(Transform target)
		{
			_target = target;
		}

		public interface IData
		{
			Vector2 Speed { get; }
		}

		public interface IComponents 
		{
			Vector3 Camera { get; set; }
			Transform DefaultTarget { get; }
		}
	}
}
