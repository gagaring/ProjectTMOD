using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Game.SO.MoveState
{
	[CreateAssetMenu(menuName = "SO/MoveState/StandUpMoveStateSO")]
	public class StandUpMoveStateSO : MoveStateSO
	{
		[SerializeField] private BoolReference _wantToCrouch;
		[SerializeField] private BoolReference _canStandUp;

		public override bool Check() => !_wantToCrouch.Value && _canStandUp.Value;
	}
}