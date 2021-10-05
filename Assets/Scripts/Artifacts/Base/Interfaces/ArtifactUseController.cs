using UnityEngine;
using VEngine.Items;

namespace VEngine.Artifacts
{
	public interface IArtifactUseController
	{
		bool Use<T>(IItem item, bool pressed, Vector3 handPosition, Vector3 viewDirection) where T : IArtifactUseage;
	}
}