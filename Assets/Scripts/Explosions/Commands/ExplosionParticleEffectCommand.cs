using UnityEngine;
using VEngine.Artifacts;
using VEngine.Particles;

namespace VEngine.Explosions
{
	[CreateAssetMenu(menuName = "SO/Explosions/Commands/ParticleEffect")]
	public class ExplosionParticleEffectCommand : ArtifactCommand
	{
		[SerializeField] private IParticleEffectSystem _system;
		[SerializeField] private ParticleEffectBehaviour _prefab;
		[SerializeField] private IParticleEffectData _data;

		public override void Use(IArtifact artifact)
		{
			_system.Play(_prefab, _data, artifact.Position);
		}
	}
}