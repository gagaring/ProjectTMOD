using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VEngine.Items;

namespace VEngine.Inventory.GUI.Stash
{
	public class StashSlotGUI : SlotGUI
	{
		private readonly IStashComponents _stashComponents;

		public StashSlotGUI(ISlotData data, IStashComponents stashComponents)
			: base(data, stashComponents.SlotComponents)
		{
			_stashComponents = stashComponents;
		}

		public override void SetItem(IItem item, uint amount)
		{
			base.SetItem(item, amount);
			_stashComponents.ItemHolder.SetActive(true);
			if (Item == null)
			{
				_stashComponents.ItemName.text = "";
			}
			else
			{
				_stashComponents.ItemName.text = Item.Details.Name;
			}
		}

		public override void ClearItem()
		{
			base.ClearItem();
			_stashComponents.ItemHolder.SetActive(false);
			_stashComponents.ItemName.text = "";
		}
		
		protected override void SetAmountText(uint value)
		{
			base.SetAmountText(value);
			SetAmountTextActive(value, true);
		}


		public interface IStashComponents 
		{
			GameObject ItemHolder { get; }
			TMP_Text ItemName { get; }
			ISlotComponents SlotComponents { get; }
		}
	}
}
