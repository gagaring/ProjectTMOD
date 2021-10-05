using UnityEngine;

namespace VEngine.Artifacts.Throwables
{
	public static class Thrower
	{
		public static bool Throw(IArtifact artifact, IThrowableData data, Vector3 handPosition, Vector3 viewDirection, float force)
		{
			var rigidbody = artifact.GetComponent<Rigidbody>();
			return Throw(rigidbody, data, handPosition, viewDirection, force);
		}

		public static bool Throw(Rigidbody rigidbody, IThrowableData data, Vector3 handPosition, Vector3 viewDirection, float force)
		{
			ResetRigidbody(rigidbody);
			SetupRigidbody(rigidbody, data, handPosition, viewDirection);
			rigidbody.AddForce(viewDirection * force, ForceMode.Impulse);
			return true;
		}

		private static void SetupRigidbody(Rigidbody rigidbody, IThrowableData data, Vector3 handPosition, Vector3 viewDirection)
		{
			rigidbody.transform.position = handPosition;
			rigidbody.transform.forward = viewDirection;
			SetupRigidbody(rigidbody, data);
		}

		public static void SetupRigidbody(Rigidbody rigidbody, IThrowableData data)
		{
			rigidbody.mass = data.Mass;
			rigidbody.drag = data.Drag;
			rigidbody.gameObject.SetActive(true);
		}

		public static void ResetRigidbody(Rigidbody rigidbody)
		{
			rigidbody.gameObject.SetActive(false);
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
	}
}
