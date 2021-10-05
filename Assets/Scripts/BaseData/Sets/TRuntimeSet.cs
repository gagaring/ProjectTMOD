using System.Collections.Generic;
using UnityEngine;

namespace VEngine.SO.Sets
{
    public abstract class TRuntimeSet<T> : ScriptableObject, IRuntimeSet<T>
    {
        private List<T> _items = new List<T>();

        public ICollection<T> Items { get => _items; }

        public void Add(T item)
        {
            if (!Items.Contains(item))
                Items.Add(item);
        }

        public void Remove(T item)
        {
            if (Items.Contains(item))
                Items.Remove(item);
        }
    }
}
