using System;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Player.Camera
{
	public class CameraPositionerBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		private CameraPositioner _logic;

		protected void Start()
		{
			_logic = new CameraPositioner(_data, _components);
		}

		protected void Update()
		{
			_logic.Update(Time.deltaTime);
		}
		
		public void Transition(Transform target)
		{
			_logic.Transition(target);
		}

		[Serializable]
		public class Data : CameraPositioner.IData
		{
			[SerializeField] private Vector2Reference _positionChangeSpeed;
		
			public Vector2 Speed => _positionChangeSpeed.Value;
		}

		[Serializable]
		public class Components : CameraPositioner.IComponents
		{
			[SerializeField] private Transform _camera;
			[SerializeField] private Transform _defaultTarget;

			public Vector3 Camera { get => _camera.position; set => _camera.position = value; }
			public Transform DefaultTarget => _defaultTarget;
		}
	}
}
