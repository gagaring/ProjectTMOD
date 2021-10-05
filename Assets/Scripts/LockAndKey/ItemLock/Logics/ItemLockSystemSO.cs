using Sirenix.OdinInspector;
using System;
using UnityEngine;
using VEngine.Items;

namespace VEngine.LockAndKey
{
	[CreateAssetMenu(menuName = "SO/LockAndKey/ItemLockSystem")]
	public class ItemLockSystemSO : SerializedScriptableObject, IItemLockSystem
	{
		[SerializeField] private ItemLockReference _currentItemLock;
		[SerializeField] private IOnItemUsed _onItemUsed;

		public bool CanUse(IItem item)
		{
			return _currentItemLock.Value != null && _currentItemLock.Value.CanUnlockWith(item);
		}

		public bool Use(IItem item)
		{
			if (_currentItemLock.Value != null && !_currentItemLock.Value.Unlock(item))
				return false;
			OnItemUsed(item);
			return true;
		}

		private void OnItemUsed(IItem item)
		{
			var keyComponent = ItemComponent.FindOn<KeyComponent>(item);
			if (!keyComponent.RemoveItemOnUse)
				return;
			_onItemUsed.OnUsed(item);
		}
	}
}