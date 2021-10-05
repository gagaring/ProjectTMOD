using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VEngine.Items
{
	[Serializable]
	public class ItemList : IItemList
	{
		[SerializeField] private List<Item> _items = new List<Item>();

		public IReadOnlyList<IItem> Items => _items.ToList<IItem>();

		public int Count => _items.Count;

		public void Init(int capacity)
		{
			for (int i = _items.Count; i < capacity; ++i)
				_items.Add(null);
			for (int i = _items.Count; i > capacity; --i)
				_items.RemoveAt(i - 1);
		}

		public void Add(IItem item)
		{
			if (!IsItem(item, out var realItem))
				return;
			_items.Add(realItem);
		}

		public void AddRange(IEnumerable<IItem> items)
		{
			foreach(var curr in items)
				Add(curr);
		}

		public void Clear()
		{
			_items.Clear();
		}

		public void ClearIndex(int index)
		{
			_items[index] = null;
		}

		public void Insert(IItem item, int index)
		{
			IsItem(item, out var realItem);
			_items[index] = realItem;
		}

		public void Remove(IItem item)
		{
			if (!IsItem(item, out var realItem))
				return;
			var index = _items.FindIndex( x => x == realItem);
			if (index == -1)
				return;
			ClearIndex(index);
		}

		public void RemoveAll(IEnumerable<IItem> items)
		{
			foreach (var curr in items)
				Remove(curr);
		}

		public int FindIndex(Predicate<IItem> match)
		{
			return _items.FindIndex(match);
		}

		private bool IsItem(IItem item, out Item result)
		{
			if(item is Item)
			{
				result = (Item)item;
				return true;
			}
			result = null;
			return false;
		}
	}
}
