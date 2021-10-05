using UnityEngine;

namespace VEngine.Artifacts.Collisions
{
	[CreateAssetMenu(menuName = "SO/Artifacts/ArtifactCollisionSystemSO")]
	public class ArtifactCollisionSystemSO : ArtifactUseageEventSystem, IArtifactCollisionSystem
	{
		public void OnCollision(IArtifact artifact, CollisionArtifactUseageEvent useageEvent, Collision collision)
		{
			if (!artifact.IsActive)
				return;
			Use(artifact, useageEvent);
		}
	}
}
