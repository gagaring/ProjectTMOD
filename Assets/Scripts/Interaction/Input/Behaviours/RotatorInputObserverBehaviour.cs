using System;
using UnityEngine;
using VEngine.Input;
using VEngine.SO.Events;
using VEngine.SO.Variables;

namespace VEngine.Interaction.Input
{
	public class RotatorInputObserverBehaviour : InputObserverBehaviour, RotatorInputObserver.IRotatorData
	{
		[SerializeField] private FloatVariable _rotateX;
		[SerializeField] private FloatVariable _rotateY;
		[SerializeField] private GameEvent _interrupt;

		protected override IInputObserver CreateObserver()
		{
			return new RotatorInputObserver(this, gameObject.name);
		}

		public Vector2 Rotate
		{
			set
			{
				_rotateX.Value = value.y;
				_rotateY.Value = value.x;
			}
		}

		public bool Close { set => _interrupt.Raise(); }
	}
}
