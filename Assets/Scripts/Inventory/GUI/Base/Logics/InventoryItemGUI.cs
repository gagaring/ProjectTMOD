using UnityEngine.UI;
using VEngine.GUI;
using VEngine.GUI.Draggable;
using VEngine.GUI.Limiter;
using VEngine.Items;

namespace VEngine.Inventory.GUI
{
	public class InventoryItemGUI : DraggableButton, IInventoryItemGUI, IAreaLimiterTarget
	{
		private readonly IItemGUIComponents _itemGUIComponents;
		public IItem _item;

		public ISlotGUI SlotGUI { get; private set; }

		public Image Avatar => _itemGUIComponents.Avatar;

		public InventoryItemGUI(IItemGUIData data, IItemGUIComponents components) : base(data.DraggableData, components.DraggableComponents)
		{
			_itemGUIComponents = components;
		}

		public virtual IItem Item 
		{
			get => _item;
			set
			{
				_item = value;
				if(value == null)
				{
					Avatar.enabled = false;
				}
				else
				{
					Avatar.enabled = true;
					var component = ((InventoryGUIItemComponent)value.Find(typeof(InventoryGUIItemComponent)));
					Avatar.sprite = component == null ? null : component.Avatar;
				}
			}
		}

		public void SetSlot(ISlotGUI slotGUI)
		{
			SlotGUI = slotGUI;
		}

		public void ClearItem()
		{
			Item = null;
			Avatar.enabled = false;
		}

		public interface IItemGUIData 
		{
			IDraggableData DraggableData { get; }
		}

		public interface IItemGUIComponents
		{
			IDraggableComponents DraggableComponents { get; }
			Image Avatar { get; }
		}
	}
}
