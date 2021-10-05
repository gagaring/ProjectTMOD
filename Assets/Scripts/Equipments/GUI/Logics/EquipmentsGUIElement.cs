using System;
using UnityEngine;
using UnityEngine.UI;
using VEngine.Inventory.GUI;
using VEngine.Items;

namespace VEngine.Equipments.GUI
{
	public class EquipmentsGUIElement
	{
		private readonly IData _data;
		private readonly IComponents _components;

		private IItem _item = null;

		public IComponents Components => _components;

		public IItem Item 
		{
			get => _item;
			set
			{
				if (_item == value)
					return;
				_item = value;
				OnItemChanged(value);
			}
		}

		public EquipmentsGUIElement(IData data, IComponents components)
		{
			_data = data;
			_components = components;
			ClearGUI();
		}

		private void OnItemChanged(IItem item)
		{
			if (item == null)
			{
				ClearGUI();
				return;
			}
			SetGUI(item);
		}

		private void ClearGUI()
		{
			_components.Avatar.sprite = null;
			OnItemChanged(false);
		}

		private void SetGUI(IItem item)
		{
			var component = ItemComponent.FindOn<InventoryGUIItemComponent>(item);
			_components.Avatar.sprite = component.Avatar;
			OnItemChanged(true);
		}

		private void OnItemChanged(bool active)
		{
			_components.Avatar.enabled = active;
			_components.Remove?.SetActive(active);
		}


		public interface IData
		{

		}

		public interface IComponents
		{
			Image Avatar { get; }
			GameObject Remove { get; }
		}
	}
}
