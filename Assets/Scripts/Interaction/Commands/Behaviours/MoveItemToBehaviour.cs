using System.Collections.Generic;
using UnityEngine;
using VEngine.Enviroment.Move;

namespace VEngine.Interaction.Command
{
	public class MoveItemToBehaviour : CommandBehaviour, MoveItemToCommand.IData, MoveItemToCommand.IComponents
	{
		[SerializeField] private List<LinearMove> _moves;
		[SerializeField] private List<LinearRotate> _rotates;

		public IReadOnlyList<IMovement> Moves => _moves;
		public IReadOnlyList<IMovement> Rotates => _rotates;

		protected override ICommand CreateCommand() => new MoveItemToCommand(this, this);
	}
}