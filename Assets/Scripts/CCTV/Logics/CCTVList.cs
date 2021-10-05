using System;
using System.Collections.Generic;

namespace VEngine.CCTV
{
	[Serializable]
	public abstract class CCTVList<T>
	{
		protected abstract List<T> GetList();

		private List<T> _list;

		private bool _isDirty = true;
		
		private List<T> SelectableList
		{
			get
			{
				if (_isDirty)
					RefreshSelectableList();
				return _list;
			}
		}

		public IReadOnlyList<T> Selectables => SelectableList;

		public bool SetDirty()=> _isDirty = true; 

		public bool Contain(T selectable) => SelectableList.Contains(selectable);

		private void RefreshSelectableList()
		{
			_list = GetList();
			_isDirty = false;
		}

	}
}
