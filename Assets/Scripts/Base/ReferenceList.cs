using System;
using System.Collections.Generic;

namespace VEngine
{
	[Serializable]
	public class ReferenceList<T> : ReferenceList<T, T>
	{
		public ReferenceList(Delegate1<T, T> getReference) : base(getReference) { }
	}

	[Serializable]
	public class ReferenceList<T, R>
	{
		private readonly List<T> _list = new List<T>();
		private readonly List<R> _referenceList = new List<R>();

		private bool _isDirty = true;

		public void SetDirty() => _isDirty = true;

		private Delegate1<R, T> _getReference = null;

		public ReferenceList(Delegate1<R, T> getReference)
		{
			_getReference = getReference;
		}

		public IReadOnlyList<R> References
		{
			get
			{
				if (_isDirty)
					RecreateReferences();
				return _referenceList;
			}
		}

		public void Add(T t)
		{
			_list.Add(t);
			SetDirty();
		}

		public void Remove(T t)
		{
			_list.Remove(t);
			SetDirty();
		}

		public void AddRange(IEnumerable<T> collection)
		{
			_list.AddRange(collection);
		}

		public void Insert(int index, T item)
		{
			_list.Insert(index, item);
			SetDirty();

		}

		public void InsertRange(int index, IEnumerable<T> collection)
		{
			_list.InsertRange(index, collection);
			SetDirty();
		}

		public int RemoveAll(Predicate<T> match)
		{
			var res = _list.RemoveAll(match);
			SetDirty();
			return res;
		}
		public void RemoveAt(int index)
		{
			_list.RemoveAt(index);
			SetDirty();
		}

		public void RemoveRange(int index, int count)
		{
			_list.RemoveRange(index, count);
			SetDirty();
		}

		public void Clear()
		{
			_list.Clear();
			SetDirty();
		}

		private void RecreateReferences()
		{
			_referenceList.Clear();
			foreach (var curr in _list)
				_referenceList.Add(_getReference(curr));
			_isDirty = false;
		}
	}
}
