using System.Collections;
using UnityEngine;
using VEngine.Items;
using VEngine.Log;
using VEngine.SO.Variables;

namespace VEngine.LockAndKey
{
	public class ItemLockDetector : IItemLockDetector
	{
		private readonly IData _data;

		private IItemLock CurrentLock
		{
			get => _data.CurrentItemLock.Value;
			set => _data.CurrentItemLock.Value = value;
		}

		public ItemLockDetector(IData data)
		{
			_data = data;
		}

		public void OnItemLockReached(IItemLock itemLock)
		{
			if(CurrentLock != null)
			{
				VLog.Log(VLog.eFlag.Game, VLog.eLevel.Warning, $"CurrentLock is not null. Only one itemLock is handable in one time.");
				return;
			}
			CurrentLock = itemLock;
		}

		public void OnItemLockLeft(IItemLock itemLock)
		{
			if (CurrentLock != itemLock)
				return;
			CurrentLock = null;
		}

		public interface IData
		{
			IVariable<IItemLock> CurrentItemLock { get; }
		}
	}
}