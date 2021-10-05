using System;
using VEngine.Items;

namespace VEngine.Inventory
{
	public interface IInventoryItemUser
	{
		void RegisterOnItemUsed(Action<IItem> callback);
		void UnregisterFromItemUsed(Action<IItem> callback);
	}
}
