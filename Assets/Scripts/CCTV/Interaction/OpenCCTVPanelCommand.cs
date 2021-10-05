using VEngine.Interaction;
using VEngine.Interaction.Command;

namespace VEngine.CCTV.Interaction
{
	public class OpenCCTVPanelCommand : ICommand
	{
		private IData _data;

		public string Name => GetType().Name;

		private bool _isWaitingForCCTV = false;

		public OpenCCTVPanelCommand(IData data) => _data = data;

		public void OnStart(IInteractor interactor)
		{
			_isWaitingForCCTV = true;
			_data.Controller.Open(OnCCTVControllerDone);
		}

		public bool OnUpdate(IInteractor interactor, float deltaTime)
		{
			return !_isWaitingForCCTV;
		}

		public void OnExit(IInteractor interactor)
		{

		}

		public void DoReset()
		{
		}

		public void OnCCTVControllerDone()
		{
			_isWaitingForCCTV = false;
		}

		public interface IData
		{
			ICCTVController Controller { get; }
		}
	}
}