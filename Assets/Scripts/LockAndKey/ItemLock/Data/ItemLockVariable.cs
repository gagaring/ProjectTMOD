using System;
using System.Collections;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.LockAndKey
{
	[CreateAssetMenu(menuName = "SO/LockAndKey/ItemLockVariable")]
	public class ItemLockVariable : TVariable<IItemLock>
	{
	}

	[Serializable]
	public class ItemLockReference : TReference<IItemLock, ItemLockVariable>, IItemLockReference
	{

	}

	public interface IItemLockReference : IReference<IItemLock, ItemLockVariable>
	{

	}
}