using UnityEngine.InputSystem;
using VEngine.Input;
using VEngine.Log;
using UnityEngine;
using VEngine.SO.Variables;
using System;

namespace VEngine.Inspector.Input
{
	public class InspectorInputObserverBehaviour : InputObserverBehaviour, InspectorInputObserver.IInspectorData
	{
		[SerializeField] private FloatVariable _rotateX;
		[SerializeField] private FloatVariable _rotateY;
		[SerializeField] private BoolVariableWithOnChangeEvent _close;

		public Vector2 Rotate
		{
			set
			{
				_rotateX.Value = value.x;
				_rotateY.Value = value.y;
			}
		}
		public bool Close { set => _close.Value = value; }

		protected override IInputObserver CreateObserver()
		{
			return new InspectorInputObserver(this, name);
		}
	}
}
