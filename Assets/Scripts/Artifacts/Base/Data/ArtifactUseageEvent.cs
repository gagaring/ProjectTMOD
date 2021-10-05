using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Artifacts
{
	//[CreateAssetMenu(menuName = "SO/Artifacts/Useage/Event/...")]
	public abstract class ArtifactUseageEvent : SerializedScriptableObject, IArtifactUseageEvent
	{
		[SerializeField] private List<IArtifactCommand> _commands = new List<IArtifactCommand>();

		public void Use(IArtifact artifact)
		{
			foreach (var curr in _commands)
				curr.Use(artifact);
		}
	}
}
