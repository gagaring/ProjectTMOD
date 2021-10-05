using System;
using System.Collections.Generic;
using VEngine.Items;

namespace VEngine.Equipments.GUI
{
	public class EquipmentsSetterGUIController
	{
		private readonly IData _data;
		private readonly IComponents _components;

		public EquipmentsSetterGUIController(IData data, IComponents components)
		{
			_data = data;
			_components = components;
			RegisterOnDrops();
		}

		private void RegisterOnDrops()
		{
			for (int i = 0; i < _components.Handlers.Count; ++i)
			{
				_components.Handlers[i].Index = i;
				_components.Handlers[i].RegisterOnDrop(OnItemDroped);
				_components.Handlers[i].RegisterOnClear(OnClear);
			}
		}

		private void OnItemDroped(int index, IItem item)
		{
			_data.Equipments.SetSlot(index, item);
		}

		private void OnClear(int index)
		{
			_data.Equipments.SetSlot(index, null);
		}

		public interface IData 
		{
			IEquipmentList Equipments { get; }
		}

		public interface IComponents
		{
			IReadOnlyList<EquipmentGUIDropHandler> Handlers { get; }
		}
	}
}
