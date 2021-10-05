using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Events;
using VEngine.SO.Variables;
using VEngine.Inventory.GUI;
using VEngine.Items;

namespace VEngine.Crafting.GUI.InventoryExtension
{
	public class CraftingInventoryExtension : ICraftingInventoryExtension
	{
		private readonly IData _data;
		private readonly IComponents _components; 

		private bool _isActive = false;
		private IInventoryItemGUI _firstItem;
		private bool _isCraftInProgress = false;

		private IInventoryItemGUI FirstItem
		{
			get => _firstItem;
			set
			{
				if (_firstItem != null)
					_firstItem.SlotGUI.Select = false;
				if (value != null)
					value.SlotGUI.Select = true;
				_firstItem = value;
			}
		}

		public CraftingInventoryExtension(IData data, IComponents components)
		{
			_data = data;
			_components = components;
		}

		~CraftingInventoryExtension()
		{
			if(_isActive)
				_components.ElementToDisabled.Restore();
		}

		public void StartCrafting(IInventoryItemGUI firstItem)
		{
			_components.ElementToDisabled.Store();
			_components.ElementToDisabled.DisableElements();
			FirstItem = firstItem;
			RegisterOnClicks();
			_isActive = true;
		}

		public void Close()
		{
			_isActive = false;
			UnregisterOnClicks();
			FirstItem = null;
			_components.ElementToDisabled.Restore();
		}

		private void RegisterOnClicks()
		{
			if(FirstItem != null)
				FirstItem.ClickEvents.OnRightClicked.AddListener(Close);
			foreach(var curr in _components.SlotsContainer)
				RegisterOnClick(curr.ItemGUI);
		}

		private void UnregisterOnClicks()
		{
			if (FirstItem != null)
				FirstItem.ClickEvents.OnRightClicked.RemoveListener(Close);
			foreach (var curr in _components.SlotsContainer)
				UnregisterOnClick(curr.ItemGUI);
		}

		private void RegisterOnClick(IInventoryItemGUI itemGUI)
		{
			itemGUI.ClickEvents.OnLeftClicked.AddListener(() => OnSecondItemSelected(itemGUI));
		}

		private void UnregisterOnClick(IInventoryItemGUI itemGUI)
		{
			itemGUI.ClickEvents.OnLeftClicked.RemoveListener(() => OnSecondItemSelected(itemGUI));
		}

		private void OnSecondItemSelected(IInventoryItemGUI item)
		{
			if (FirstItem == null)
				return;
			if (FirstItem == item)
			{
				Close();
				return;
			}
			if (!HasRecipeWithMaterials(item))
				return;
			Craft(item);
			Close();
		}

		private void Craft(IInventoryItemGUI item)
		{
			var materialSlots = new List<int>();
			materialSlots.Add(FirstItem.SlotGUI.SlotIndex);
			materialSlots.Add(item.SlotGUI.SlotIndex);
			_isCraftInProgress = true;
			_data.Craft.Raise(materialSlots);
		}

		private bool HasRecipeWithMaterials(IInventoryItemGUI item)
		{
			var materials = new List<IItem>();
			materials.Add(FirstItem.Item);
			materials.Add(item.Item);
			return _data.Combinator.IsCombinatable(materials);
		}

		public void OnCraftFinished(IRecipe recipe, bool success, string error)
		{
			if (!_isCraftInProgress)
				return;
			Debug.LogError($"Craft is finished: {success} - {error}");
			_isCraftInProgress = false;
		}

		public interface IData
		{
			ICombinator Combinator { get; }
			IGameEvent<List<int>> Craft { get; }
		}

		public interface IComponents
		{
			IReadOnlyList<ISlotGUI> SlotsContainer { get; }
			IElementsToDisabled ElementToDisabled { get; }
		}

		public interface IElementsToDisabled
		{
			void Store();
			void Restore();
			void DisableElements();
		}
	}
}
