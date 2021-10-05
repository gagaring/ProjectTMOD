using UnityEngine;

namespace VEngine.Particles
{
	public class ParticleEffect : IParticleEffect
	{
		private readonly IData _data;
		public float Duration => _data.Duration;

		public ParticleEffect(IData data)
		{
			_data = data;
		}


		public void Use(IParticleEffectData data, Vector3 position)
		{
			_data.GameObject.transform.position = position;
			_data.ParticleSystem.Play();
		}

		public interface IData
		{
			ParticleSystem ParticleSystem { get; }
			float Duration { get; }
			GameObject GameObject { get; }
		}
	}
}
