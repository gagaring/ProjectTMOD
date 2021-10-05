using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VEngine.SO.Variables;
using VEngine.Items;

namespace VEngine.Inventory.GUI.Stash
{
	public class StashItemGUI : InventoryItemGUI
	{
		private readonly IStashItemGUIComponents _components;

		public StashItemGUI(IStashItemGUIData data, IStashItemGUIComponents components) : base(data.ItemGUIData, components.ItemGUIComponents)
		{
			_components = components;
		}

		public override IItem Item
		{
			set
			{
				base.Item = value;
				if(value == null)
				{
					_components.ItemName.enabled = false;
					return;
				}
				_components.ItemName.enabled = true;
				_components.ItemName.text = value.Details.Name;
			}
		}

		protected override void FollowPosition(PointerEventData eventData)
		{
			var position = eventData.position;
			position.x = Position.x;
			Position = position;
		}

		public interface IStashItemGUIData
		{
			IItemGUIData ItemGUIData { get; }
		}

		public interface IStashItemGUIComponents
		{
			IItemGUIComponents ItemGUIComponents { get; }
			TMPro.TMP_Text ItemName { get; }
		}
	}
}
