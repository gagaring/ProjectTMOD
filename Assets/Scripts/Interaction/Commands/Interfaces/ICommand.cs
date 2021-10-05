namespace VEngine.Interaction.Command
{
	public interface ICommand
	{
		string Name { get; }

		void OnStart(IInteractor interactor);
		bool OnUpdate(IInteractor interactor, float deltaTime);
		void OnExit(IInteractor interactor);
		void DoReset();
	}
}
