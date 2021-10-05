using System;

namespace VEngine.TimerSystem
{
	public class Timable : ITimable
	{
		private readonly Action _onFinished;

		public float Duration { get; private set; }

		public Timable(float duration, Action onFinished)
		{
			_onFinished = onFinished;
			Duration = duration;
		}

		public void OnExpired()
		{
			_onFinished();
		}
	}
}