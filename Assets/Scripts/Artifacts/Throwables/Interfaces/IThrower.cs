using UnityEngine;
using VEngine.Items;

namespace VEngine.Artifacts.Throwables
{
	public interface IThrower
	{
		bool Throw(IArtifact artifact, IThrowableData component, Vector3 handPosition, Vector3 viewDirection, float force);
		bool Throw(Rigidbody rigidbody, IThrowableData component, Vector3 handPosition, Vector3 viewDirection, float force);
		void Reset(Rigidbody rigidbody);
	}
}
