using System;
using System.Collections.Generic;

namespace VEngine.Items
{
	public interface IItemComponents
	{
		ItemComponent Find(Type type);
		IReadOnlyList<ItemComponent> FindAll(Type type);
		IReadOnlyList<ItemComponent> FindAll(Predicate<ItemComponent> match);
	}
}
