using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.GUI.Context
{
    public class ContextMenuBehaviour : MonoBehaviour
    {
		[SerializeField] protected ContextMenuData _data;
		[SerializeField] protected ContextMenuComponents _components;

		protected ContextMenu _contextMenu;

		private ReferenceList<ContextMenuElementBehaviour, IContextMenuElement> _contextMenuElements;

		protected void Awake()
		{
			_contextMenuElements = new ReferenceList<ContextMenuElementBehaviour, IContextMenuElement>( x => x.ContextMenuElement );
			InitData();
			InitComponents();
			CreateContextMenu();
		}

		protected virtual void InitData()
		{
			_data.AddToElelements += CreateElementBehaviours;
		}

		protected virtual void InitComponents()
		{
			_components.GetElements += () => _contextMenuElements.References;
		}

		protected virtual void CreateContextMenu()
		{
			CreateElementBehaviours(_data.ContextMenuElementDefaultNumber);
			_contextMenu = new ContextMenu(_data, _components);
		}

		protected void CreateElementBehaviours(int value)
		{
			for(int i = 0; i < value; ++i)
				CreateElementBehaviour();
		}

		private ContextMenuElementBehaviour CreateElementBehaviour()
		{
			var obj = Instantiate(_components.ElementPrefab, _components.ElementParent);
			_contextMenuElements.Add(obj);
			_components.Footer?.SetAsLastSibling();
			return obj;
		}

		public void Close()
		{
			_contextMenu.Close();
		}

		[Serializable]
		public class ContextMenuData : ContextMenu.IData
		{
			[SerializeField] protected BoolReference _isContextMenuEnabled;
			[SerializeField] protected IntReference _maxContextMenuElementDefaultNumber;

			public bool IsContextMenuEnabled => _isContextMenuEnabled.Value;
			public Delegate1<int> AddToElelements { get; set; }
			public int ContextMenuElementDefaultNumber => _maxContextMenuElementDefaultNumber.Value;
		}

		[Serializable]
		public class ContextMenuComponents : ContextMenu.IComponents
		{
			[SerializeField] protected GameObject _main;
			[SerializeField] protected RectTransform _elementParent;
			[SerializeField] protected ContextMenuElementBehaviour _elementPrefab;
			[SerializeField] protected RectTransform _footer;

			public IReadOnlyList<IContextMenuElement> Elements { get => GetElements(); }
			public GameObject Main => _main;
			public RectTransform ElementParent => _elementParent;
			public Delegate0<IReadOnlyList<IContextMenuElement>> GetElements { get; set; }
			public ContextMenuElementBehaviour ElementPrefab => _elementPrefab;
			public RectTransform Footer => _footer;
		}

	}
}
