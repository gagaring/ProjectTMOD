using System;
using UnityEngine;

namespace VEngine.Artifacts.Commands
{
	[CreateAssetMenu(menuName = "SO/Artifacts/Useage/Commands/PushBackToObjectPool")]
	public class PushBackToObjectPool : ArtifactCommand
	{
		[SerializeField] private IArtifactSystem _system;

		public override void Use(IArtifact artifact)
		{
			_system.Push(artifact);
		}
	}
}
