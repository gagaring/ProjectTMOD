using UnityEngine;
using VEngine.Game.Move;
using VEngine.SO.Variables;

namespace VEngine.Player
{
	public class PlayerMover : Mover_CharacterController
	{
		[SerializeField] private BoolReference _isJumpInProgress;
		
		protected override bool IsGravityEnabled()
		{
			return !_isJumpInProgress.Value;
		}
	}
}
