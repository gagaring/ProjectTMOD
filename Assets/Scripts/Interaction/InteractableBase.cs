using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.Interaction.Command;
using VEngine.Log;
using VEngine.SO.Variables;

namespace VEngine.Interaction
{
	public class InteractableBase : MonoBehaviour, IInteractable
	{
		[SerializeField] private List<CommandBehaviour> _commands;
		[SerializeField] private List<BoolReference> _requirements;

		private bool _inProgress = false;
		private int _currentIndex = 0;
		private IInteractor _interactor = null;
		private ICommand CurrentCommand { get => _commands[_currentIndex].Command; }

		public Action OnInteractionStarted { get; set; }
		public Action OnInteractionFinished { get; set; }

		public virtual void OnInteracted(IInteractor interactor)
		{
			if (_inProgress)
				return;
			_interactor = interactor;
			StartInteract();
		}

		private void StartInteract()
		{
			_currentIndex = 0;
			_inProgress = true;
			VLog.Log(VLog.eFlag.Interaction, VLog.eLevel.Normal, $"Started: {CurrentCommand.Name}");
			CurrentCommand.OnStart(_interactor);
		}

		private void Update()
		{
			if (!_inProgress)
				return;
			if (!CurrentCommand.OnUpdate(_interactor, Time.deltaTime))
				return;
			OnCommandFinished();
		}

		private void OnCommandFinished()
		{
			VLog.Log(VLog.eFlag.Interaction, VLog.eLevel.Normal, $"Finished: {CurrentCommand.Name}, Next Index: {_currentIndex + 1}, CommandCount: {_commands.Count}");
			CurrentCommand.OnExit(_interactor);
			++_currentIndex;
			if(_currentIndex >= _commands.Count)
			{
				VLog.Log(VLog.eFlag.Interaction, VLog.eLevel.Normal, $"All command finished.");
				_inProgress = false;
				_interactor = null;
				return;
			}
			VLog.Log(VLog.eFlag.Interaction, VLog.eLevel.Normal, $"Started: {CurrentCommand.Name}");
			CurrentCommand.OnStart(_interactor);
		}

		public bool CanInteract(IInteractor interactor)
		{
			foreach(var curr in _requirements)
			{
				if (curr.Value)
					continue;
				return false;
			}
			return true;
		}
	}
}
