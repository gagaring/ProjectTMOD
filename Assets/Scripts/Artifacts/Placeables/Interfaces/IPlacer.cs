using UnityEngine;

namespace VEngine.Artifacts.Placeables
{
	public interface IPlacer
	{
		bool Place(IArtifact artifact, Vector3 position, Vector3 normal);
	}
}