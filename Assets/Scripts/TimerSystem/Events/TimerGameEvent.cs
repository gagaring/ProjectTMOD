using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.TimerSystem
{
	[CreateAssetMenu(menuName = "SO/Timer/TimerEvent")]
	public class TimerGameEvent : TGameEvent<ITimable>
	{
	}
}