using UnityEngine;
using VEngine.Artifacts;

namespace VTest.Throwables
{
    public class ThrowableGameTestListener : MonoBehaviour
    {
        public void OnThrown(IArtifact artifact)
		{
            Debug.LogError($"{artifact.Attached.Details.Name} is thrown");
		}

        public void OnThrowableColliderEnter(IArtifact artifact, Collision collision)
		{
            Debug.LogError($"{artifact.Attached.Details.Name} is collided with {collision.gameObject.name}");
        }
    }
}
