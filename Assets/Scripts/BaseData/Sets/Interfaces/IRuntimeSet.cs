using System.Collections.Generic;
using UnityEngine;

namespace VEngine.SO.Sets
{
    public interface IRuntimeSet<T>
    {
        ICollection<T> Items { get; }
        void Add(T item);
        void Remove(T item);
    }
}
