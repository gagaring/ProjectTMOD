using System.Collections.Generic;
using UnityEngine;
using VEngine.Equipments;
using VEngine.Items;
using VEngine.Log;
using VEngine.SO.Variables;

namespace VEngine.HandSystem
{
	public class Hand : IHand
	{
		private readonly IData _data;
		private readonly IComponents _components;

		private IItem _currentItem = null;
		private EquippableComponent _currentComponent;

		public Hand(IData data, IComponents components)
		{
			_data = data;
			_components = components;
		}

		public void Equip(IItem item)
		{
			if (_currentItem == item)
				return;
			_currentItem = item;
			OnCurrentItemChanged();
		}

		public void Use(bool start)
		{
			if (_currentComponent == null)
				return;
			foreach(var curr in _components.UseHandComponents)
			{
				if (!curr.Use(_currentItem, start, _data.HandPosition, _data.ViewDirection))
					continue;
				_components.OnItemUsed.OnUsed(_currentItem);
				break;
			}
		}

		public void Targeting(bool start)
		{
			if (_currentComponent == null)
				return;
			foreach (var curr in _components.TargetingHandComponents)
			{
				if (!curr.Targeting(_currentItem, start, _data.HandPosition, _data.ViewDirection))
					continue;
				_components.OnItemUsed.OnUsed(_currentItem);
				break;
			}
		}

		private void OnCurrentItemChanged()
		{
			_currentComponent = _currentItem == null ? null : ItemComponent.FindOn<EquippableComponent>(_currentItem);
			VLog.Log(VLog.eFlag.Game, VLog.eLevel.None, $"Item in hand changed: {(_currentItem == null ? "Empty" : _currentItem.Details.Name)}");
		}

		public interface IData
		{
			ITransformSOReference HandPosition { get; }
			ITransformSOReference ViewDirection { get; }
		}

		public interface IComponents
		{
			IReadOnlyList<IUseHandComponent> UseHandComponents { get; }
			IReadOnlyList<ITargetingHandComponent> TargetingHandComponents { get; }
			IOnItemUsed OnItemUsed { get; }
		}
	}
}
