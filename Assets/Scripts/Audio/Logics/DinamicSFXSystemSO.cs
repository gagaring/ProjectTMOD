using Sirenix.OdinInspector;
using UnityEngine;
using VEngine.ObjectPool;
using VEngine.SO.Events;
using VEngine.TimerSystem;

namespace VEngine.Audio
{
	[CreateAssetMenu(menuName = "SO/Audio/DinamicSFXSystemSO")]
    public class DinamicSFXSystemSO : SerializedScriptableObject, IDinamicSFXSystem
    {
		[SerializeField] private ObjectPoolSystemSO _objectPool;
		[SerializeField] private IGameEvent<ITimable> _timer;

		public void PlaySfx(IDinamicSFXData audioData)
		{
			var dinamicSFX = _objectPool.System.Pull(audioData.Prefab);
			dinamicSFX.gameObject.SetActive(true);
			dinamicSFX.AudioSource.Play();
			_timer.Raise(new Timable(dinamicSFX.AudioSource.clip.length, () => _objectPool.System.Push(dinamicSFX)));
		}

		public interface IData
		{
			AudioSource GetEntity(IDinamicSFXData audio);
			void Push(IDinamicSFXData audio);
			IGameEvent<ITimable> StartTimer { get; }
		}
	}
}
