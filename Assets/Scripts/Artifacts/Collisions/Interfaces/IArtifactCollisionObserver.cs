using UnityEngine;

namespace VEngine.Artifacts.Collisions
{
	public interface IArtifactCollisionObserver
	{
		void OnCollisionEnter(IArtifactCollisionSystem system, IArtifact artifact, Collision collision);
		void OnCollisionStay(IArtifactCollisionSystem system, IArtifact artifact, Collision collision);
		void OnCollisionExit(IArtifactCollisionSystem system, IArtifact artifact, Collision collision);
		void OnCollision<T>(IArtifactCollisionSystem system, IArtifact artifact, Collision collision) where T : CollisionArtifactUseageEvent;
	}
}
