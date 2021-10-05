using System;
using System.Collections.Generic;

namespace VEngine.Items
{
    public interface IItem 
    {
        IDetails Details { get; }

        ItemComponent Find(Type type);
        IReadOnlyList<ItemComponent> FindAll(Type type);
        IReadOnlyList<ItemComponent> FindAll(Predicate<ItemComponent> match);
        void AddComponent(ItemComponent components);
    }

    public interface IItemReference
	{
        IItem Value { get; }
	}

    public interface IDetails
	{
        string Name { get; }
        string Description { get; }
    }
}
