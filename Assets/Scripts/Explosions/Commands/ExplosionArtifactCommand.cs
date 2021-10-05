using UnityEngine;
using VEngine.Explosions;

namespace VEngine.Artifacts.Commands
{
	[CreateAssetMenu(menuName = "SO/Artifacts/Useage/Commands/Explosion/ExplosionCommand")]
	public class ExplosionArtifactCommand : ArtifactCommand
	{
		[SerializeField] private IExplosionData _data;

		public override void Use(IArtifact artifact) 
		{
			foreach (var curr in _data.Commands)
				curr.Use(artifact);
		}
	}
}
