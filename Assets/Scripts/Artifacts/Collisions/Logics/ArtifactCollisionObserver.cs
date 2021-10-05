using UnityEngine;

namespace VEngine.Artifacts.Collisions
{
	public class ArtifactCollisionObserver : IArtifactCollisionObserver
	{
		public void OnCollisionEnter(IArtifactCollisionSystem system, IArtifact artifact, Collision collision)
		{
			OnCollision<OnCollisionEnterArtifactUseageEvent>(system, artifact, collision);
		}

		public void OnCollisionStay(IArtifactCollisionSystem system, IArtifact artifact, Collision collision)
		{
			OnCollision<OnCollisionStayArtifactUseageEvent>(system, artifact, collision);
		}

		public void OnCollisionExit(IArtifactCollisionSystem system, IArtifact artifact, Collision collision)
		{
			OnCollision<OnCollisionExitArtifactUseageEvent>(system, artifact, collision);
		}

		public void OnCollision<T>(IArtifactCollisionSystem system, IArtifact artifact, Collision collision) where T : CollisionArtifactUseageEvent
		{
			if (!ArtifactUtils.GetUseageEvent<T>(artifact, out var useageEvent))
				return;
			system.OnCollision(artifact, useageEvent, collision);
		}
	}
}
