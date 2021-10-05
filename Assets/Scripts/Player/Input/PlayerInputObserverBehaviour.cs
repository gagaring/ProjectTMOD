using System;
using UnityEngine;
using VEngine.Input;
using VEngine.SO.Events;
using VEngine.SO.Variables;

namespace VEngine.Player.Input
{
	public class PlayerInputObserverBehaviour : InputObserverBehaviour, PlayerInputObserver.IPlayerData
	{
		[Header("Movement")]
		[SerializeField] private Vector2VariableWithOnChangeEvent _move;
		[SerializeField] private BoolVariableWithOnChangeEvent _crouch;
		[SerializeField] private BoolVariableWithOnChangeEvent _sprint;
		[Header("Rotate")]
		[SerializeField] private FloatVariableWithOnChangeEvent _tilt;
		[SerializeField] private FloatVariableWithOnChangeEvent _rotate;
		[Header("Other")]
		[SerializeField] private BoolVariableWithOnChangeEvent _interact;
		[SerializeField] private BoolVariableWithOnChangeEvent _jump;
		[SerializeField] private GameEvent _loot;


		public Vector2 Move { set => _move.Value = value; }
		public Vector2 Rotate
		{
			set
			{
				_rotate.Value = value.x;
				_tilt.Value = value.y;
			}
		}

		public bool Crouch { set => _crouch.Value = value; }
		public bool Sprint { set => _sprint.Value = value; }
		public bool Interact { set => _interact.Value = value; }
		public bool Jump { set => _jump.Value = value; }

		public IGameEvent Loot => _loot;

		protected override IInputObserver CreateObserver()
		{
			return new PlayerInputObserver(this,  name);
		}
	}
}
