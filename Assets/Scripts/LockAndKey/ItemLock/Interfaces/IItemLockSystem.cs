using System.Collections;
using UnityEngine;
using VEngine.Items;

namespace VEngine.LockAndKey
{
	public interface IItemLockSystem
	{ 
		bool Use(IItem item);
		bool CanUse(IItem item);
	}
}