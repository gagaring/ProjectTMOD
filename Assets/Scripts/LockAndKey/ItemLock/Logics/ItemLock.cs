using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using VEngine.Enviroment;
using VEngine.Items;

namespace VEngine.LockAndKey
{
	public class ItemLock : IItemLock
	{
		private readonly IData _data;

		private HashSet<IItem> _unlockedComponents = new HashSet<IItem>();

		public ItemLock(IData data)
		{
			_data = data;
		}

		public Action<ISwitch, bool> OnChanged { get; set; }

		public bool Unlock(IItem item)
		{
			_unlockedComponents.Add(item);
			OnRequirementChanged();
			return true;
		}

		private void OnRequirementChanged()
		{
			var requirements = _data.Requirements;
			foreach (var curr in requirements)
			{
				if (_unlockedComponents.Contains(curr))
					continue;
				OnChanged?.Invoke(this, false);
			}
			OnChanged?.Invoke(this, true);
		}

		public bool CanUnlockWith(IItem item)
		{
			return _data.Requirements.Contains(item) && !_unlockedComponents.Contains(item);
		}

		public interface IData
		{
			ReadOnlyCollection<IItem> Requirements { get; }
		}
	}
}