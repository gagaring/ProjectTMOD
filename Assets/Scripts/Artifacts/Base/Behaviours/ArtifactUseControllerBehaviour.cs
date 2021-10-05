using Sirenix.OdinInspector;
using UnityEngine;
using VEngine.Items;
using VEngine.SO.Variables;

namespace VEngine.Artifacts
{
	public abstract class ArtifactUseControllerBehaviour : SerializedMonoBehaviour, ArtifactUseController.IData
	{
		[Title("ObjectPool")]
		[SerializeField] private ArtifactSystemSO _system;

		public IArtifact GetArtifact(IArtifactData data)
			=> _system.Pull(data);

		public void PushArtifact(IArtifact artifact)
			=> _system.Push(artifact);

		public abstract bool Use(IItem item, bool pressed, ITransformSOReference handPosition, ITransformSOReference viewDirection);
	}
}