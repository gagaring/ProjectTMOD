using System.Collections.Generic;
using UnityEngine;

namespace VEngine.AI.Enemy
{
	public class EnemyBaseSoundController : MonoBehaviour
	{
		[SerializeField] private Vector2 _waitBetweenSounds;
		[SerializeField] private List<AudioSource> _audioSources;

		private AudioSource _currentSource;
		private int _currentIndex = -1;

		public void Init()
		{
			StartNewSound();
		}

		private void StartNewSound()
		{
			_currentIndex = GetRandomIndex();
			var delay = UnityEngine.Random.Range(_waitBetweenSounds.x, _waitBetweenSounds.y);
			_currentSource = _audioSources[_currentIndex];
			_currentSource.PlayDelayed(delay);
			var waitTime = delay + _currentSource.clip.length;
			Invoke(nameof(StartNewSound), waitTime);
		}

		public void OnGamePaused(bool paused)
		{
			if (paused)
				_currentSource?.Pause();
			else
				_currentSource?.UnPause();
		}

		private int GetRandomIndex()
		{
			for(int i = 0; i < 3; ++i)
			{
				var nextIndex = UnityEngine.Random.Range(0, _audioSources.Count);
				if (_currentIndex == nextIndex)
					continue;
				return nextIndex;
			}
			return UnityEngine.Random.Range(0, _audioSources.Count);
		}
	}
}