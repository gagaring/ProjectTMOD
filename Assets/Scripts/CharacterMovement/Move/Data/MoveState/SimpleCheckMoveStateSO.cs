using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Game.SO.MoveState
{
	[CreateAssetMenu(menuName = "SO/MoveState/SimpleCheckMoveStateSO")]
	public class SimpleCheckMoveStateSO : MoveStateSO
	{
		[SerializeField] private BoolReference _value;

		public override bool Check() => _value.Value;
	}
}