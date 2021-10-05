using System;
using UnityEngine;

namespace VEngine.Interaction.Command
{
	public abstract class CommandBehaviour : MonoBehaviour
	{
		private ICommand _command = null;

		public ICommand Command 
		{ 
			get
			{
				if (_command == null)
					_command = CreateCommand();
				return _command;
			}
		}

		protected abstract ICommand CreateCommand();
	}
}