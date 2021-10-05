using UnityEngine;

namespace VEngine.Game.Player.AISound
{
	public class PlayerAISoundController : MonoBehaviour
	{
		//[SerializeField] private float _isMovingThreshold = 0.05f;
		[SerializeField] private AISoundEmitter _aiSoundEmitter;
		/*
		private eMoveState _moveType = eMoveState.None;
		private bool _isMoving = false;

		public void OnSpeedChanged(float speed, float maxSpeed)
		{
			bool currIsMoving = speed / maxSpeed > _isMovingThreshold;
			if (_isMoving == currIsMoving)
				return;
			_isMoving = currIsMoving;
			OnStateChanged();
		}

		public void OnMoveTypeChanged(eMoveState moveType)
		{
			if (_moveType == moveType)
				return;
			_moveType = moveType;
			OnStateChanged();
		}

		private void OnStateChanged()
		{
			_aiSoundEmitter.ChangeState(_moveType, _isMoving);
		}*/
	}
}