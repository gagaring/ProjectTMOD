using System;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Interaction.Command
{
	public class ActivateGameObjectBehaviour : CommandBehaviour
	{
		[SerializeField] private Components _components;

		protected override ICommand CreateCommand() => new ActivateGameObjectCommand(_components);

		[Serializable]
		public class Components : ActivateGameObjectCommand.IComponents
		{
			[SerializeField] private List<Activateable> _activateables;

			public IReadOnlyList<ActivateGameObjectCommand.IActivateable> Activateables => _activateables;
		}

		[Serializable]
		public class Activateable : ActivateGameObjectCommand.IActivateable
		{
			[SerializeField] private bool _activate;
			[SerializeField] private GameObject _target;

			public bool Activate => _activate;
			public GameObject Target => _target;
		}
	}
}
