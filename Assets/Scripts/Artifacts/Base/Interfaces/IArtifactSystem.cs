namespace VEngine.Artifacts
{
	public interface IArtifactSystem
	{
		IArtifact Pull(IArtifactData data);
		void Push(IArtifact artifact);
	}
}
