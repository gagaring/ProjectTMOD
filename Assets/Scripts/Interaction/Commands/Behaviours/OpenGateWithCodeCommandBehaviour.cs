using UnityEngine;

namespace VEngine.Interaction.Command
{
	public class OpenGateWithCodeCommandBehaviour : OpenGateCommandBehaviour, OpenGateWithCodeCommand.ICodeData
	{
		[SerializeField] private PasswordLock _doorPasswordLock;
		public IPasswordLock PasswordLock => _doorPasswordLock;

		protected override ICommand CreateCommand() => new OpenGateWithCodeCommand(this);
	}
}