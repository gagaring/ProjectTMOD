using System;
using UnityEngine;
using UnityEngine.UI;
using VEngine.GUI;
using VEngine.GUI.Draggable;
using VEngine.GUI.Limiter;

namespace VEngine.Inventory.GUI
{
	public class InventoryItemGUIBehaviour : DraggableButtonBehaviour, IItemGUIBehaviour
	{
		[SerializeField] protected ItemGUIData _itemGUIData;
		[SerializeField] protected ItemGUIComponents _itemGUIComponents;

		public InventoryItemGUI ItemGUI { get; private set; }

		IInventoryItemGUI IItemGUIBehaviour.ItemGUI { get => ItemGUI; }
		IAreaLimiterTarget IItemGUIBehaviour.AreaLimiterTarget { get => ItemGUI; }
	
		protected override void Awake()
		{
			GetItemGUIComponents();
			base.Awake();
		}

		private void GetItemGUIComponents()
		{ 
			if (_itemGUIData == null)
				_itemGUIData = new ItemGUIData();
			if (_itemGUIComponents == null)
				_itemGUIComponents = new ItemGUIComponents();

			if (_itemGUIComponents.Avatar == null)
				_itemGUIComponents.Avatar = GetComponent<Image>();
		}

		protected override void CreateDraggableButton()
		{
			ItemGUI = CreateItemGUI();
			SetupDraggableInterfaces(ItemGUI);
		}

		protected virtual InventoryItemGUI CreateItemGUI()
		{
			SetupData();
			SetupComponents();
			return new InventoryItemGUI(_itemGUIData, _itemGUIComponents);
		}

		protected virtual void SetupData()
		{
			_itemGUIData.DraggableData = _draggableData;
		}

		protected virtual void SetupComponents()
		{
			_itemGUIComponents.DraggableComponents = _draggableComponents;
		}

		protected override void RegisterOnDraggableButtonEvents()
		{
			base.RegisterOnDraggableButtonEvents();
			Events.OnStateChanged += OnStateChanged;
		}

		private void OnStateChanged(eState state)
		{
			if (state == eState.OnDrag)
				return;
			_draggableComponents.RectTransform.position = DropSlot.Position;
		}

		[Serializable]
		protected class ItemGUIData : InventoryItemGUI.IItemGUIData
		{
			public DraggableButton.IDraggableData DraggableData { get; set; }
		}

		[Serializable]
		protected class ItemGUIComponents : InventoryItemGUI.IItemGUIComponents
		{
			[SerializeField] private Image _avatar;

			public DraggableButton.IDraggableComponents DraggableComponents { get; set; }
			public Image Avatar { get => _avatar; set => _avatar = value; }

		}
	}
}
