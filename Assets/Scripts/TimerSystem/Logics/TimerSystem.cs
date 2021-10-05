using System.Collections.Generic;
using VEngine.Log;

namespace VEngine.TimerSystem
{
	public class TimerSystem : ITimerSystem
	{
		private LinkedList<Timer> _timers = new LinkedList<Timer>();

		public void StartTimer(ITimable timable)
		{
			_timers.AddLast(new Timer(timable));
		}

		public void Update(float deltaTime)
		{
			if (_timers.Count == 0)
				return;
			var node = _timers.First;
			while (node != null)
			{
				var curr = node;
				node = node.Next;
				curr.Value.RemainingDuration -= deltaTime;
				if (curr.Value.RemainingDuration > 0)
				{
					continue;
				}
				curr.Value.Timable.OnExpired();
				_timers.Remove(curr);
			}
		}

		private class Timer
		{
			public ITimable Timable { get; private set; }
			public float RemainingDuration { get; set; }

			public Timer(ITimable timable)
			{
				Timable = timable;
				RemainingDuration = timable.Duration;
			}
		}
	}
}