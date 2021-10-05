using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace VEngine.Artifacts
{
	//[CreateAssetMenu(menuName = "SO/Artifacts/Data/Command/...")]
	public abstract class ArtifactCommand : SerializedScriptableObject, IArtifactCommand
	{
		public abstract void Use(IArtifact artifact);
	}
}
