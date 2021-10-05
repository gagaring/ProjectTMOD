using Sirenix.OdinInspector;
using UnityEngine;

namespace VEngine.Artifacts.Collisions
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(ArtifactBehaviour))]
	public class ArtifactCollisionBehaviour : SerializedMonoBehaviour
	{
		[SerializeField] protected ArtifactBehaviour _artifact;
		[SerializeField] protected IArtifactCollisionSystem _system;
		[SerializeField] protected IArtifactCollisionObserver _observer;

		protected IArtifact Artifact => _artifact.Artifact;

		public void OnValidate()
		{
			if (_artifact != null)
				return;
			_artifact = GetComponent<ArtifactBehaviour>();
		}
	}
}
