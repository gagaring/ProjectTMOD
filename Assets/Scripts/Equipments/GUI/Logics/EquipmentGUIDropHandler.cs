using System;
using UnityEngine.UI;
using VEngine.Items;

namespace VEngine.Equipments.GUI
{
	public class EquipmentGUIDropHandler
	{
		public int Index { get; set; } = 0;
		private Action<int, IItem> _onItemDroped { get; set; }
		private Action<int> _onClear { get; set; }

		public EquipmentGUIDropHandler(IComponents components)
		{
			components.Clear.onClick.AddListener(OnClearClicked);
		}

		public void OnDrop(IItem item) => _onItemDroped?.Invoke(Index, item);
		public void RegisterOnDrop(Action<int, IItem> functor) => _onItemDroped += functor;
		public void RegisterOnClear(Action<int> functor) => _onClear += functor;

		private void OnClearClicked()
		{
			_onClear?.Invoke(Index);
		}

		public interface IComponents
		{
			Button Clear { get; }
		}
	}
}
