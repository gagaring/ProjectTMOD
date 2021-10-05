using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Camera
{
	public class CCameraDataStorer : MonoBehaviour, ICameraDataStorer
	{
		[SerializeField] private Transform _camera;
		[SerializeField] private CameraDataVariable _cameraDataVariable;

		public Transform Camera
		{
			get => _camera;
			set
			{
				_camera = value;
				_cameraDataVariable?.AssignTransform(_camera);
			}
		}
		public CameraDataVariable Data
		{
			get => _cameraDataVariable;
			set
			{ 
				_cameraDataVariable = value;
				_cameraDataVariable?.AssignTransform(Camera);
			}
		}

		public void Awake()
		{
			Data?.AssignTransform(Camera);
		}
	}
}