using System;
using VEngine.Items;

namespace VEngine.Inventory
{
	public interface IItemUser
	{
		void RegisterOnItemUsed(Action<IItem> callback);
		void UnregisterFromItemUsed(Action<IItem> callback);
	}
}
