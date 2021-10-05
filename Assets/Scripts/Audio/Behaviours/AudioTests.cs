using Sirenix.OdinInspector;
using UnityEngine;

namespace VEngine.Audio.Assets.Scripts.Audio.Behaviours
{
	public class AudioTests : SerializedMonoBehaviour
	{
		[SerializeField] private AudioSource _source;

		[SerializeField] private IDinamicSFXSystem _system;
		[SerializeField] private IDinamicSFXData _data;

		[Button("PlaySFX")]
		public void PlaySFX()
		{
			_system.PlaySfx(_data);
		}

		[Button("Play")]
		private void Play()
		{
			_source.Play();
		}

		[Button("PlayOneShot")]
		private void PlayOneShot(AudioClip clip)
		{
			_source.PlayOneShot(clip);
		}

		[Button("PlayDelayed")]
		private void PlayDelayed(float delay)
		{
			_source.PlayDelayed(delay);
		}

		[Button("PlayScheduled")]
		private void PlayScheduled(float delay)
		{
			_source.PlayScheduled(Time.time + delay);
		}

		[Button("Stop")]
		private void Stop()
		{
			_source.Stop();
		}

		[Button("Pause")]
		private void Pause()
		{
			_source.Pause();
		}

		[Button("UnPause")]
		private void UnPause()
		{
			_source.UnPause();
		}
	}
}