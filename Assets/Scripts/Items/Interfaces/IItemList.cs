using System;
using System.Collections.Generic;

namespace VEngine.Items
{
	public interface IItemList
	{
		IReadOnlyList<IItem> Items { get; }
		int Count { get; }

		void Add(IItem item);
		void AddRange(IEnumerable<IItem> items);
		void Insert(IItem item, int index);
		void Remove(IItem item);
		void RemoveAll(IEnumerable<IItem> items);
		void Clear();
		void ClearIndex(int index);
		int FindIndex(Predicate<IItem> match);
	}
}
