namespace VEngine.Interaction
{
	public interface IInteractable
	{
		void OnInteracted(IInteractor _interactor);
		bool CanInteract(IInteractor interactor);
	}
}
