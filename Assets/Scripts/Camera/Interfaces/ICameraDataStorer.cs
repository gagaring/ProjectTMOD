using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Camera
{
	public interface ICameraDataStorer
	{
		Transform Camera { get; }
		CameraDataVariable Data { get; }
	}
}
