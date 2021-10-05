using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using VEngine.Equipments;
using VEngine.Items;
using VEngine.SO.Variables;

namespace VEngine.HandSystem
{
	public class HandBehaviour : SerializedMonoBehaviour, Hand.IData, Hand.IComponents
	{
		[Title("Data")]
		[SerializeField] private TransformSO _handPosition;
		[SerializeField] private TransformSO _viewDirection;

		[Title("Components")]
		[SerializeField] private List<IUseHandComponent> _useHandComponents = new List<IUseHandComponent>();
		[SerializeField] private List<ITargetingHandComponent> _targetingHandComponents = new List<ITargetingHandComponent>();
		[SerializeField] public IOnItemUsed OnItemUsed { get; private set; }

		private Hand _hand;
		public IHand Hand
		{
			get
			{
				CreateHand();
				return _hand;
			}
		}

		public IReadOnlyList<IUseHandComponent> UseHandComponents => _useHandComponents;
		public IReadOnlyList<ITargetingHandComponent> TargetingHandComponents => _targetingHandComponents;
		public ITransformSOReference HandPosition => _handPosition;
		public ITransformSOReference ViewDirection => _viewDirection;


		public void UseHand(bool pressed) => Hand.Use(pressed);
		public void TargetingHand(bool pressed) => Hand.Targeting(pressed);

		public void EquipItem(IReadOnlyEquipmentSlot slot) => Hand.Equip(slot == null ? null : slot.Item);
		public void EquipItem(IItem item) => Hand.Equip(item);

		protected void CreateHand()
		{
			if (_hand != null)
				return;
			_hand = new Hand(this, this);
		}
	}
}
