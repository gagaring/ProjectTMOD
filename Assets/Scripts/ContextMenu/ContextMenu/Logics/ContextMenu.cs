using System;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.GUI.Context
{
    public class ContextMenu : IContextMenu
    {
		private readonly IData _data;
		private readonly IComponents _components;

		private Action _canceled;

		public ContextMenu(IData data, IComponents components)
		{
			_data = data;
			_components = components;
			ShowMain(false);
		}

		public void Open(Vector2 position, List<IContextMenuElementData> menuData, Action canceled, Action<int> ok)
		{
			if (!_data.IsContextMenuEnabled)
				return;
			_components.ElementParent.position = position;
			ShowMain(true);
			_canceled = canceled;
			CreateElementIfNeed(menuData.Count);
			int max = Mathf.Min(menuData.Count, _components.Elements.Count);
			for (int i = 0; i < max; ++i)
			{
				_components.Elements[i].Show(menuData[i], i, ok);
			}
			for(int i = max; i < _components.Elements.Count; ++i)
			{
				_components.Elements[i].Hide();
			}
		}

		private void CreateElementIfNeed(int count)
		{
			if (_components.Elements.Count >= count)
				return;
			count -= _components.Elements.Count;
			_data.AddToElelements(count);
		}

		public void Close()
		{
			ShowMain(false);
			_canceled?.Invoke();
		}

		private void ShowMain(bool show)
		{
			_components.Main.SetActive(show);
		}

		public interface IData
		{
			public bool IsContextMenuEnabled { get; }
			public Delegate1<int> AddToElelements { get; }

		}

		public interface IComponents
		{
			public IReadOnlyList<IContextMenuElement> Elements { get; }
			public GameObject Main { get; }
			public RectTransform ElementParent { get; }
		}

	}
}
