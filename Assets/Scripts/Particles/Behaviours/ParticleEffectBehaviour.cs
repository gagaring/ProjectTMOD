using Sirenix.OdinInspector;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Particles
{
    public class ParticleEffectBehaviour : SerializedMonoBehaviour, ParticleEffect.IData
    {
		[SerializeField] public ParticleSystem ParticleSystem { get; private set; }
		[SerializeField] public FloatReference _duration;

		public float Duration => _duration.Value;

		private IParticleEffect _logic = null;

		public GameObject GameObject => gameObject;

		public IParticleEffect Logic
		{
			get
			{
				Create();
				return _logic;
			}
		}

		private void Create()
		{
			if (_logic != null)
				return;
			_logic = new ParticleEffect(this);
		}

		public void Play(IParticleEffectData data, Vector3 position)
		{
			Logic.Use(data, position);
		}

	}
}
