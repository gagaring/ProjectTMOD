using Sirenix.OdinInspector;
using UnityEngine;
using VEngine.ObjectPool;
using VEngine.TimerSystem;

namespace VEngine.Particles
{
	[CreateAssetMenu(menuName = "SO/Particle/ParticleEffectSystem")]
	public class ParticleEffectSystem : SerializedScriptableObject, IParticleEffectSystem
	{
		[SerializeField] private ObjectPoolSystemSO _objectPoolSystem;
		[SerializeField] private TimerGameEvent _timerGameEvent;

		public void Play(ParticleEffectBehaviour prefab, IParticleEffectData data, Vector3 position)
		{
			var particle = _objectPoolSystem.System.Pull(prefab);
			particle.gameObject.SetActive(true);
			particle.Play(data, position);
			_timerGameEvent.Raise(new Timable(prefab.Logic.Duration, ()=> _objectPoolSystem.System.Push(particle)));
		}
	}
}
