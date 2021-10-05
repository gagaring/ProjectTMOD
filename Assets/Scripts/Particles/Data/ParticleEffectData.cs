using Sirenix.OdinInspector;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Particles
{
	[CreateAssetMenu(menuName = "SO/Particle/ParticleEffectData")]
	public class ParticleEffectData : SerializedScriptableObject, IParticleEffectData
	{
		[SerializeField] private FloatReference _duration;
		public float Duration => _duration.Value;
	}
}