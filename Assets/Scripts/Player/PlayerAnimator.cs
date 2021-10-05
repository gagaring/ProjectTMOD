using VEngine.Anim;
using UnityEngine;

namespace VEngine.Player
{
	public class PlayerAnimator : CAnimatorBase
	{
		private float _tmpSpeedRate;
		private bool _tmpIsMoving;

		protected override void RegisterHashes()
		{
			SetHash(eFloat.Speed);
			SetHash(eBool.Crouch);
			SetHash(eBool.Jump);
			SetHash(eBool.Interacting1);
		}

		public void OnSpeedChanged(float speed, float maxSpeed)
		{
			_tmpSpeedRate = speed / maxSpeed;
			Set(eFloat.Speed, _tmpIsMoving ? _tmpSpeedRate : 0.0f);
		}

		public void OnMoveVectorChanged(Vector3 move)
		{
			_tmpIsMoving = Mathf.Abs(move.x) > 0.01f || Mathf.Abs(move.z) > 0.01f;
			Set(eFloat.Speed, _tmpIsMoving ? _tmpSpeedRate : 0.0f);
		}

		public void OnJump(bool jump)
		{
			Set(eBool.Jump, jump);
		}

		public void OnInteraction(bool started)
		{
			Set(eBool.Interacting1, started);
		}

		public void OnCrouch(bool crouch)
		{
			Set(eBool.Crouch, crouch);
		}
	}
}
