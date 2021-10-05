using System.Collections;
using UnityEngine;

namespace VEngine.Interaction.Command
{
	public class WaitUntilTriggerEnterBehaviour : CommandBehaviour, WaitCommand.IData
	{
		protected override ICommand CreateCommand() => new WaitCommand(this);

		public bool IsWaiting { get; private set; }

		private void Awake() => IsWaiting = true;

		public void OnTriggerEnter(Collider other)
		{
			if (other.GetComponentInChildren<IInteractor>() == null)
				return;
			IsWaiting = false;
		}

		public void OnTriggerExit(Collider other)
		{
			if (other.GetComponent<IInteractor>() == null)
				return;
			IsWaiting = true;
		}
	}
}