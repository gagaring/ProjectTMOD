using System;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Enviroment.Move
{
	public class Movements : IMovements
	{
		public readonly IData _data;

		public bool IsFinished { get; set; }

		public bool IsOpened => _data.CurrentStateOpen;

		public Movements(IData data)
		{
			_data = data;
			DoSetDirection(_data.CurrentStateOpen);
			Do(float.MaxValue);
		}

		public void SetDirection(bool open)
		{
			if (_data.CurrentStateOpen == open)
				return;
			DoSetDirection(open);
		}

		private void DoSetDirection(bool open)
		{
			IsFinished = false;
			_data.CurrentStateOpen = open;
			foreach (var curr in _data.Moveables)
				curr.SetDirection(open);
			_data.Enabled = true;
		}

		public void Do(float deltaTime)
		{
			bool allGood = true;
			foreach (var curr in _data.Moveables)
			{
				curr.Do(deltaTime);
				if (!curr.IsFinished())
					allGood = false;
			}
			if (allGood)
				IsFinished = true;
		}

		public interface IData
		{
			bool CurrentStateOpen { get; set; }
			IReadOnlyList<IMovement> Moveables { get; }
			bool Enabled { set; }
		}
	}
}