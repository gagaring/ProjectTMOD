using UnityEngine;

namespace VEngine.Artifacts.Placeables
{
	public class Placer : IPlacer
	{
		public bool Place(IArtifact artifact, Vector3 position, Vector3 normal)
		{
			Reset(artifact);
			//todo: ezen kell rigidbody?
			var rigidbody = artifact.GetComponent<Rigidbody>();
			rigidbody.isKinematic = true;
			artifact.Position = position;
			artifact.Forward = normal;
			rigidbody.gameObject.SetActive(true);
			return true;
		}

		private void Reset(IArtifact artifact)
		{
			var rigidbody = artifact.GetComponent<Rigidbody>();
			rigidbody.gameObject.SetActive(false);
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.isKinematic = true;
		}
	}
}