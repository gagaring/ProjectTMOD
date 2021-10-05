using VEngine.Log;
using VEngine.SO.Events;

namespace VEngine.Interaction.Command
{
	public class AskPasswordCommand : ICommand
	{
		private readonly IData _data;
		private readonly IComponents _components;

		private bool _isWaitingForPassword = false;

		public string Name => GetType().Name;

		public AskPasswordCommand(IData data, IComponents components)
		{
			_data = data;
			_components = components;
		}

		public void DoReset()
		{
			_isWaitingForPassword = false;
		}

		public void OnStart(IInteractor interactor)
		{
			_isWaitingForPassword = true;
			if (_data.PasswordLock.IsUnlocked || _data.OpenPanel.RegisteredCount == 0)
				OnPasswordEntered(_data.PasswordLock.Password);
			else
				_data.OpenPanel.Raise(_data.PasswordLock);
		}

		public bool OnUpdate(IInteractor interactor, float deltaTime)
		{
			return !_isWaitingForPassword;
		}

		public void OnExit(IInteractor interactor)
		{
		}

		public void OnPasswordEntered(int password)
		{
			if (!_isWaitingForPassword)
				return;
			_data.PasswordLock.IsUnlocked = password == _data.PasswordLock.Password;
			_isWaitingForPassword = false;
			VLog.Log(VLog.eFlag.Game, VLog.eLevel.Normal, $"Password entered ({_data.PasswordLock.IsUnlocked}): {password}, required: {_data.PasswordLock.Password}");
		}

		public interface IData
		{
			IPasswordLock PasswordLock { get; }
			IGameEvent<IPasswordLock> OpenPanel { get; }
		}

		public interface IComponents
		{
		}
	}
}