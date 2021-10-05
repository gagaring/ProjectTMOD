using VEngine.Enviroment.Move;

namespace VEngine.Interaction.Command
{
	public class OpenGateCommand : ICommand
	{
		private readonly IData _data;
		private bool _isOpened = true;

		public virtual string Name => GetType().Name;
		
		public OpenGateCommand(IData data)
		{
			_data = data;
			_isOpened = _data.Movements.IsOpened;
		}

		public void DoReset()
		{
		}

		public virtual void OnStart(IInteractor interactor)
		{
			_isOpened = !_isOpened;
			_data.Movements.SetDirection(_isOpened);
		}

		public virtual bool OnUpdate(IInteractor interactor, float deltaTime)
		{
			return _data.Movements.IsFinished;
		}

		public virtual void OnExit(IInteractor interactor)
		{
		}

		public interface IData
		{
			IMovements Movements { get; }
		}
	}
}