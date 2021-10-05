using UnityEngine;

namespace VEngine.Artifacts.Collisions
{
	public interface IArtifactCollisionSystem
	{
		void OnCollision(IArtifact artifact, CollisionArtifactUseageEvent component, Collision collision);
	}
}
