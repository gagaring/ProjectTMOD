using UnityEngine;
using System.Collections.Generic;
using VEngine.Input;
using System;

namespace VEngine.Interaction.Command
{
	public class TurnInputsEnabledBehaviour : CommandBehaviour, TurnInputsEnabledCommand.IData
	{
		[SerializeField] private InputActivator _inputActivator;

		public IInputActivator InputActivator => _inputActivator;

		protected override ICommand CreateCommand() => new TurnInputsEnabledCommand(this);

		[Serializable]
		public class Data 
		{
			[SerializeField] private InputStack _inputStack;
			[SerializeField] private List<InputEnabledWithOnChangeEvent> _enableInputs;

			public IInputStack InputStack => _inputStack;
			public IReadOnlyList<InputEnabledWithOnChangeEvent> EnableInputs => _enableInputs;
		}
	}
}
