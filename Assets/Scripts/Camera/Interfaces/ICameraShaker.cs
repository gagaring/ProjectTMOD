using System.Collections.Generic;

namespace VEngine.Camera
{
	public interface ICameraShakerBehaviour
	{
		List<ICameraShakeDataReference> ShakeDataReferencePriorityList { get; }
		void DoResetAll();
	}

	public interface ICameraShaker
	{
		void DoResetAll();
		void ShakeFirstActive(float deltaTime);
	}
}
