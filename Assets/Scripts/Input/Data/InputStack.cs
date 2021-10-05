using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.Log;

namespace VEngine.Input
{
	[CreateAssetMenu(menuName = "SO/Sets/InputEnabledSet")]
	public class InputStack : ScriptableObject, IInputStack
	{
		private LinkedList<IReadOnlyList<InputEnabledWithOnChangeEvent>> _stack = new LinkedList<IReadOnlyList<InputEnabledWithOnChangeEvent>>();

		public void Clear() => _stack.Clear();

		public int Activate(IReadOnlyList<InputEnabledWithOnChangeEvent> active)
		{
			var copy = new List<InputEnabledWithOnChangeEvent>(active);
			ActivateTop(false);
			Activate(true, copy);
			_stack.AddFirst(copy);
			return copy.GetHashCode();
		}

		public void Deactivate(int hash)
		{
			if (_stack.Count == 0)
			{
				VLog.Log(VLog.eFlag.Input, VLog.eLevel.Normal, $"Nem maradt input, amit engedelyezni lehetne");
				return;
			}
			if (_stack.First.Value.GetHashCode() == hash)
			{
				ActivateTop(false);
				_stack.RemoveFirst();
			}
			else
			{
				if (!Find(hash, out var list))
					return;
				Activate(false, list);
				_stack.Remove(list);
			}
			ActivateTop(true);
		}

		private bool Find(int hash, out IReadOnlyList<InputEnabledWithOnChangeEvent> list)
		{
			foreach (var curr in _stack)
			{
				if (curr.GetHashCode() != hash)
					continue;
				list = curr;
				return true;
			}
			list = null;
			return false;
		}

		private bool ActivateTop(bool active)
		{
			if (_stack.Count == 0)
				return false;
			Activate(active, _stack.First.Value);
			return true;
		}

		private void Activate(bool active, IReadOnlyList<InputEnabledWithOnChangeEvent> list)
		{
			foreach (var curr in list)
			{
				VLog.Log(VLog.eFlag.Input, VLog.eLevel.Normal, $"Input ({curr.name}) activated: {active}");
				curr.Value = active;
			}
		}
	}
}
