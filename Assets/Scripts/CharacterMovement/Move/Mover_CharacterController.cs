using System;
using UnityEngine;
using VEngine.SO.Events;
using VEngine.SO.Variables;

namespace VEngine.Game.Move
{
	public class Mover_CharacterController : Mover
	{
		[SerializeField] private CharacterController _characterContoller;
		[SerializeField] private BoolReference _grounded;
		[SerializeField] private Vector2Reference _moveDirection;
		[SerializeField] private Vector3GameEvent _onMoveVectorChanged;

		private float _velocityY = 0.0f;

		public void OnPositionOverrided()
		{
			Physics.SyncTransforms();
		}

		protected Vector3 Position
		{
			get => _characterContoller.transform.position;
			set
			{
				_characterContoller.transform.position = value;
			}
		}

		protected virtual void Update()
		{
			UpdateGravity();
			var moveDir = _moveDirection.Value;
			Vector3 move = transform.right * moveDir.x + transform.forward * moveDir.y;
			move *= _speed.Value;
			move.y = _velocityY;
			_onMoveVectorChanged.Raise(move);
			_characterContoller.Move(move * Time.deltaTime);
		}

		private void UpdateGravity()
		{
			if (!IsGravityEnabled())
				_velocityY = 0.0f;
			else if (_grounded.Value)
				_velocityY = -2.0f;
			else
				_velocityY += Physics.gravity.y * Time.deltaTime;
		}

		protected virtual bool IsGravityEnabled()
		{
			return true;
		}
	}
}
