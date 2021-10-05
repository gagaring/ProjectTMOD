using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using VEngine.Enviroment;
using VEngine.Items;

namespace VEngine.LockAndKey
{
	public class ItemLockBehaviour : SerializedMonoBehaviour, IItemLockBehaviour, ItemLock.IData
	{
		[SerializeField] private List<IItem> _requirements = new List<IItem>();
		
		private IItemLock _lock;

		public IItemLock Lock
		{
			get
			{
				CreateLock();
				return _lock;
			}
		}

		public ReadOnlyCollection<IItem> Requirements => _requirements.AsReadOnly();
		public Action<ISwitch, bool> OnChanged { get => Lock.OnChanged; set => Lock.OnChanged = value; }

		private void CreateLock()
		{
			if (_lock != null)
				return;
			_lock = new ItemLock(this);
		}
	}
}
