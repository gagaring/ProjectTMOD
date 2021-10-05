using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Game.SO.MoveState
{
	[CreateAssetMenu(menuName = "SO/MoveState/SprintMoveStateSO")]
	public class SprintMoveStateSO : MoveStateSO
	{
		[SerializeField] private BoolReference _wantToSprint;
		[SerializeField] private BoolReference _canStandUp;

		public override bool Check() => _wantToSprint.Value && _canStandUp.Value;
	}
}