using Sirenix.OdinInspector;
using UnityEngine;

namespace VEngine.TimerSystem
{
	public class TimerSystemBehaviour : SerializedMonoBehaviour
	{
		private ITimerSystem _system = new TimerSystem();

		private void Update()
		{
			_system.Update(Time.deltaTime);
		}

		public void StartTimer(ITimable timable) => _system.StartTimer(timable);
	}
}