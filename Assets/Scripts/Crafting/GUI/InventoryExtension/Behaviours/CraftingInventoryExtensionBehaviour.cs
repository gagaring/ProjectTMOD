using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Events;
using VEngine.SO.Variables;
using VEngine.Inventory.GUI;

namespace VEngine.Crafting.GUI.InventoryExtension
{
    public class CraftingInventoryExtensionBehaviour : MonoBehaviour
    {
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		private ICraftingInventoryExtension _craftingInventoryExtension;

		protected void Awake()
		{
			_craftingInventoryExtension = new CraftingInventoryExtension(_data, _components);
		}

		public void StartCrafting(IInventoryItemGUI firstItem)
		{
			_craftingInventoryExtension.StartCrafting(firstItem);
		}

		public void CloseCrafting(IInventoryItemGUI firstItem)
		{
			_craftingInventoryExtension.Close();
		}

		public void OnCraftFinished(IRecipe recipe, bool success, string error)
		{
			_craftingInventoryExtension.OnCraftFinished(recipe, success, error);
		}

		[Serializable]
		public class Data : CraftingInventoryExtension.IData
		{
			[SerializeField] private CraftingBySlotsEvent _craftEvent;
			[SerializeField] private CombinatorSO _combinatorSO;

			public ICombinator Combinator => _combinatorSO.Combinator;
			public IGameEvent<List<int>> Craft => _craftEvent;
		}

		[Serializable]
		public class Components : CraftingInventoryExtension.IComponents
		{
			[SerializeField] private ElementsToDisabled _elementsToDisable;
			[SerializeField] private SlotsGUIContainerReference _slotContainerRef;

			public IReadOnlyList<ISlotGUI> SlotsContainer => _slotContainerRef.SlotGUIs;
			public CraftingInventoryExtension.IElementsToDisabled ElementToDisabled => _elementsToDisable;
		}

		[Serializable]
		public class ElementsToDisabled : CraftingInventoryExtension.IElementsToDisabled
		{
			[SerializeField] private List<BoolVariable> _varialbeToDisabledOnOpen;

			private List<bool> _originalVarialbeToDisabledOnOpen = new List<bool>();

			public void Store()
			{
				_originalVarialbeToDisabledOnOpen.Clear();
				foreach (var curr in _varialbeToDisabledOnOpen)
					_originalVarialbeToDisabledOnOpen.Add(curr.Value);
			}

			public void Restore()
			{
				for (int i = 0; i < _originalVarialbeToDisabledOnOpen.Count; ++i)
					_varialbeToDisabledOnOpen[i].Value = _originalVarialbeToDisabledOnOpen[i];
			}

			public void DisableElements()
			{
				foreach (var curr in _varialbeToDisabledOnOpen)
					curr.Value = false;
			}
		}
	}
}
