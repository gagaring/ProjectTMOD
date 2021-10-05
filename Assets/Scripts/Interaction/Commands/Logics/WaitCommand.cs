namespace VEngine.Interaction.Command
{
	public class WaitCommand : ICommand
	{
		private IData _data;

		public string Name => GetType().Name;

		public WaitCommand(IData data) => _data = data;

		public interface IData
		{
			bool IsWaiting { get; }
		}

		public bool OnUpdate(IInteractor interactor, float deltaTime) => !_data.IsWaiting;
		public void DoReset() { }
		public void OnExit(IInteractor interactor) { }
		public void OnStart(IInteractor interactor) { }
	}
}