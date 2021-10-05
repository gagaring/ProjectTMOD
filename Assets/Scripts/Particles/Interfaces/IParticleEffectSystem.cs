using UnityEngine;

namespace VEngine.Particles
{
	public interface IParticleEffectSystem
	{
		void Play(ParticleEffectBehaviour prefab, IParticleEffectData data, Vector3 position);
	}
}