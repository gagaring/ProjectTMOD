using UnityEngine;
using VEngine.Log;

namespace VEngine.TimeManagement
{
	public class TimeVariable : ITimeManager
	{
		private readonly IData _data;

		public TimeVariable(IData data) => _data = data;

		public void Activate(IGameSpeed gameSpeed)
		{
			Set(gameSpeed);
		}

		public void Deactivate(IGameSpeed gameSpeed)
		{
			Set(_data.DefaultSpeed);
		}

		private void Set(IGameSpeed gameSpeed)
		{
			Time.timeScale = gameSpeed.TimeScale;
			Time.fixedDeltaTime = gameSpeed.FixedTimeScale;
			VLog.Log(VLog.eFlag.Game, VLog.eLevel.None, "New timeScale: " + Time.timeScale + ", fixedDeltaTime: " + Time.fixedDeltaTime);
		}

		public interface IData
		{
			GameSpeed DefaultSpeed { get; }
		}
	}
}
