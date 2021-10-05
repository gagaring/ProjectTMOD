using Sirenix.OdinInspector;
using UnityEngine;
using VEngine.ObjectPool;

namespace VEngine.Artifacts
{
	[CreateAssetMenu(menuName = "SO/Artifacts/ArtifactSystemSO")]
	public class ArtifactSystemSO : SerializedScriptableObject, IArtifactSystem
	{
		[SerializeField] private ObjectPoolSystemSO _objectPoolSystem;
		[SerializeField] private IObjectPoolEntity _artifactEntity;

		private IObjectPoolSystem System => _objectPoolSystem.System;

		public IArtifact Pull(IArtifactData data)
		{
			var model = System.Pull<MonoBehaviour>(data.Entity);
			var artifact = System.Pull<ArtifactBehaviour>(_artifactEntity).Artifact;
			artifact.AttachModel = model;
			artifact.IsActive = true;
			return artifact;
		}

		public void Push(IArtifact artifact)
		{
			if (!artifact.IsActive)
				return;
			artifact.IsActive = false;
			System.Push(artifact.AttachModel);
			artifact.Reset();
			System.Push(artifact.GetComponent<ArtifactBehaviour>());
		}
	}
}
