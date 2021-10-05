using UnityEngine;

namespace VEngine.Interaction
{
	public abstract class InteractorBaseBehaviour : MonoBehaviour, IInteractor
	{
		public abstract Vector3 Position { get; set; }
		public abstract Quaternion Rotation { get; set; }
	}
}
