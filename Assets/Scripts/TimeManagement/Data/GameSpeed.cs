using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.TimeManagement
{
	[CreateAssetMenu(menuName = "SO/Time/GameSpeed")]
	public class GameSpeed : TVariable<float>, IGameSpeed
	{
		public float TimeScale => Value;
		public float FixedTimeScale => Time.timeScale * 0.02f;
	}
}
