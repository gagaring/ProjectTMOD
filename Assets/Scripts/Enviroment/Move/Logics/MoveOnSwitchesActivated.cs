using System;
using System.Collections.Generic;

namespace VEngine.Enviroment.Move
{
    public class MoveOnSwitchesActivated 
    {
		private readonly IData _data;

		private HashSet<ISwitch> _activeSwitches = new HashSet<ISwitch>();

		public MoveOnSwitchesActivated(IData data)
		{
			_data = data;
			RegisterOnSwitches();
		}

		~MoveOnSwitchesActivated()
		{
			UnregisterOnSwitches();
		}

		private void RegisterOnSwitches()
		{
			foreach (var curr in _data.Switches)
				curr.OnChanged += OnSwitchChanged;
		}

		private void UnregisterOnSwitches()
		{
			foreach (var curr in _data.Switches)
				curr.OnChanged -= OnSwitchChanged;
		}

		private void OnSwitchChanged(ISwitch swtch, bool active)
		{
			if (active)
			{
				_activeSwitches.Add(swtch);
				SetTargetPosition(_activeSwitches.Count == _data.Switches.Count);
			}
			else
			{
				_activeSwitches.Remove(swtch);
				SetTargetPosition(false);
			}
		}

		private void SetTargetPosition(bool active)
		{
			_data.Movements.SetDirection(active);
		}

		public interface IData
		{
			IReadOnlyList<ISwitch> Switches { get; }
			IMovements Movements { get; }
		}
    }
}
