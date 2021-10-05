using UnityEngine;

namespace VEngine.Artifacts.Collisions
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(ArtifactBehaviour))]
	public class ArtifactCollisionEnterBehaviour : ArtifactCollisionBehaviour
	{
		public void OnCollisionEnter(Collision collision)
		{
			_observer.OnCollisionEnter(_system, Artifact, collision);
		}
	}
}
