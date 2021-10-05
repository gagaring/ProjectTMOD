using UnityEngine;

namespace VEngine.Interaction
{
	public interface IInteractor 
	{
		Vector3 Position { get; set; }
		Quaternion Rotation { get; set; }
	}
}
