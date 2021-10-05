using Sirenix.OdinInspector;
using UnityEngine;

namespace VEngine.Artifacts
{
	public sealed class ArtifactBehaviour : SerializedMonoBehaviour, Artifact.IData
	{
		[SerializeField] private Artifact _artifact;

		public GameObject GameObject => gameObject;
		public IArtifact Artifact => _artifact;

		private void Awake() => _artifact.Init(this);
	}
}
