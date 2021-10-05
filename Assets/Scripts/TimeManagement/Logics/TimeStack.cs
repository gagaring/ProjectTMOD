using System.Collections.Generic;
using UnityEngine;
using VEngine.Log;

namespace VEngine.TimeManagement
{
	public class TimeStack : ITimeManager
	{
		private readonly IData _data;
		private LinkedList<IGameSpeed> _gameSpeeds = new LinkedList<IGameSpeed>();

		public TimeStack(IData data) => _data = data;

		public void Activate(IGameSpeed gameSpeed)
		{
			Set(gameSpeed);
		}

		public void Deactivate(IGameSpeed gameSpeed)
		{
			var node = _gameSpeeds.Last;
			while (node != null)
			{
				if (node.Value == gameSpeed)
				{
					_gameSpeeds.Remove(node);
					return;
				}
				node = node.Previous;
			}
			ActivateTop();
		}

		private void ActivateTop()
		{
			Set(_gameSpeeds.Count == 0 ? _data.DefaultSpeed : _gameSpeeds.Last.Value);
		}

		private void Set(IGameSpeed gameSpeed)
		{
			_gameSpeeds.AddLast(gameSpeed);
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
