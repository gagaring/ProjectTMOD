using System.Collections.Generic;
using UnityEngine;
using VEngine.Inventory;

namespace VEngine.Equipments.GUI
{
	public class EquipmentsGUI
	{
		private readonly IData _data;
		private readonly IComponents _components;

		public EquipmentsGUI(IData data, IComponents components)
		{
			_data = data;
			_components = components;
		}

		public void OnEquipmentsChanged(IReadOnlyEquipmentList equipments)
		{
			for (int i = 0; i < equipments.Count; ++i)
			{
				var curr = equipments.ReadOnlyList[i];
				_components.Elements[i].Item = curr == null ? null : curr.Item;
			}
		}

		public void OnInventoryChanged(IInventoryData data)
		{
			foreach(var curr in _components.Elements)
			{
				SetColor(curr, data.Contains(curr.Item) > 0);
			}
		}

		private void SetColor(EquipmentsGUIElement element, bool available)
		{
			var color = element.Components.Avatar.color;
			var alpha = color.a;
			color = available ? _data.AvailableColor : _data.UnavailableColor;
			color.a = alpha;
			element.Components.Avatar.color = color;
		}

		public interface IData
		{
			Color AvailableColor { get; }
			Color UnavailableColor { get; }
		}

		public interface IComponents
		{
			IReadOnlyList<EquipmentsGUIElement> Elements { get; }
		}
	}
}
