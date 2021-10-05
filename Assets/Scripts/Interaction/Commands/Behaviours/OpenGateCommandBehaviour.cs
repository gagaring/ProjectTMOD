using System.Collections;
using UnityEngine;
using VEngine.Enviroment.Move;

namespace VEngine.Interaction.Command
{
	public class OpenGateCommandBehaviour : CommandBehaviour, OpenGateCommand.IData
	{
		[SerializeField] public MovementsBehaviour _movements;
		[SerializeField] public IMovements Movements => _movements.Movements;

		protected override ICommand CreateCommand() => new OpenGateCommand(this);
	}
}