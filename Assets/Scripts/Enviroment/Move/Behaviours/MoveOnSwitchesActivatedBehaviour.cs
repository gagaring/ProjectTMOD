using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.Enviroment.Switch;

namespace VEngine.Enviroment.Move
{
    public class MoveOnSwitchesActivatedBehaviour : MonoBehaviour, MoveOnSwitchesActivated.IData
	{
		[SerializeField] private List<TriggerSwitchBehaviour> _switches;
		[SerializeField] private MovementsBehaviour _movements;
		
		private MoveOnSwitchesActivated _moveOnSwitchesActivated;

		public IReadOnlyList<ISwitch> Switches => _switches;
		public IMovements Movements => _movements.Movements;

		protected void Awake()
		{
			_moveOnSwitchesActivated = new MoveOnSwitchesActivated(this);
		}
	}
}
