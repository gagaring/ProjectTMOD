using VEngine.Input;

namespace VEngine.Interaction.Command
{
	public class TurnInputsEnabledCommand : ICommand
	{
		public string Name => GetType().Name;
		private readonly IData _data;

		private bool _isEnabled = false;

		public TurnInputsEnabledCommand(IData data)
		{
			_data = data;
		}

		public void OnStart(IInteractor interactor)
		{
			_isEnabled = !_isEnabled;
			_data.InputActivator.Activate(_isEnabled);
		}

		public bool OnUpdate(IInteractor interactor, float deltaTime)
		{
			return true;
		}

		public void OnExit(IInteractor interactor)
		{
		}

		public void DoReset()
		{
			_data.InputActivator.Deactivate();
			_isEnabled = false;
		}

		public interface IData
		{
			IInputActivator InputActivator { get; }
		}
	}
}
