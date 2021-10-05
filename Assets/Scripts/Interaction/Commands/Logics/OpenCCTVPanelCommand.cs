using System.Collections;
using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.Interaction.Command
{
	public class OpenCCTVPanelCommand : ICommand
	{
		public string Name => GetType().Name;

		private bool _isWaitingForCCTV = false;

		public void OnStart(IInteractor interactor)
		{
			_isWaitingForCCTV = true;
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

		public interface IData
		{
			//IGameEvent<>
		}
	}
}