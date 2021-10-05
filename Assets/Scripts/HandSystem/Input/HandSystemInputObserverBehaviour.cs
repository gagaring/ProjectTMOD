using UnityEngine;
using VEngine.Input;
using VEngine.SO.Events;

namespace VEngine.HandSystem.Input
{
	public class HandSystemInputObserverBehaviour : InputObserverBehaviour, HandSystemInputObserver.IHandData
	{
		[SerializeField] private IntGameEvent _onActiveEquipmentChanged;
		[SerializeField] private BoolGameEvent _useHand;
		[SerializeField] private BoolGameEvent _targetingHand;

		public int ActiveEquipmentSlot { set => _onActiveEquipmentChanged.Raise(value); }
		public bool UseHand { set => _useHand.Raise(value); }
		public bool TargetingHand { set => _targetingHand.Raise(value); }

		protected override IInputObserver CreateObserver() 
			=> new HandSystemInputObserver(this, name);
	}
}
