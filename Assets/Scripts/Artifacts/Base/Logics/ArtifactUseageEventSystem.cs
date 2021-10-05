using Sirenix.OdinInspector;

namespace VEngine.Artifacts
{
	public class ArtifactUseageEventSystem : SerializedScriptableObject
	{
		protected void Use(IArtifact artifact, IArtifactUseageEvent useageEvent)
		{
			useageEvent.Use(artifact);
		}
	}
}