using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.Interaction.Command
{
	public class AskPasswordCommandBehaviour : CommandBehaviour, AskPasswordCommand.IData, AskPasswordCommand.IComponents
	{
		[SerializeField] private PasswordLockGameEvent _openCodePanelEvent;
		[SerializeField] private PasswordLock _doorPasswordLock;

		public IGameEvent<IPasswordLock> OpenPanel => _openCodePanelEvent;
		public IPasswordLock PasswordLock => _doorPasswordLock;

		protected override ICommand CreateCommand() => new AskPasswordCommand(this, this);
		public void OnPassword(int password) => ((AskPasswordCommand)Command).OnPasswordEntered(password);
	}
}