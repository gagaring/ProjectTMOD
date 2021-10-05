using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Interaction.Command
{
	public class ActivateGameObjectCommand : ICommand
	{
		public string Name => GetType().Name;
		private readonly IComponents _components;

		public ActivateGameObjectCommand(IComponents components)
		{
			_components = components;
		}


		public void DoReset()
		{
		}

		public void OnExit(IInteractor interactor)
		{
		}

		public void OnStart(IInteractor interactor)
		{
			foreach (var curr in _components.Activateables)
				curr.Target.SetActive(curr.Activate);
		}

		public bool OnUpdate(IInteractor interactor, float deltaTime)
		{
			return true;
		}

		public interface IComponents
		{
			IReadOnlyList<IActivateable> Activateables { get; }
		}

		public interface IActivateable
		{
			bool Activate { get; }
			GameObject Target { get; }
		}
	}
}
