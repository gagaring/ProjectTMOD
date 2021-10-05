using VEngine.Items;
using VEngine.SO.Variables;

namespace VEngine.Artifacts
{
	public interface ITargetingController
	{
		bool Targeting<T>(IItem item, bool pressed, ITransformSOReference handPosition, ITransformSOReference viewDirection) where T : IArtifactUseage;
		void Update(float deltaTime);
	}
}
