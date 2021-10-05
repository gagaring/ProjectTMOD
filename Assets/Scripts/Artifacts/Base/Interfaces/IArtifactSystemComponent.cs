namespace VEngine.Artifacts
{
	public interface IArtifactSystemComponent
	{
		void Activate(IArtifact equipment);
		void Reset();
	}
}
