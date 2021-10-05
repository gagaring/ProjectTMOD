using System;
using UnityEngine;
using VEngine.SO.Variables;
using VEngine.GUI.Split;
using VEngine.GUI;

namespace VEngine.Inventory.GUI
{
	public class InventoryGUIWithSplitBehaviour : InventoryGUIBehaviour, InventoryGUIWithSplit.IInventorySplitData
	{
		[SerializeField] protected BoolReference _splitModifier;
		[SerializeField] protected SplitSliderBehaviour _splitSliderBehaviour;

		public IReferenceWithConstant<bool, BoolVariable> SplitModifier => _splitModifier;
		public ISplitSliderReference SplitSlider => _splitSliderBehaviour.SplitSliderReference;

		protected override IPanel CreatePanel() => new InventoryGUIWithSplit(this);
	}
}
