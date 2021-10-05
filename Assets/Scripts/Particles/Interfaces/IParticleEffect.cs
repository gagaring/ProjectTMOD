using UnityEngine;

namespace VEngine.Particles
{
	public interface IParticleEffect
	{
		float Duration { get; }
		void Use(IParticleEffectData data, Vector3 position);
	}
}
