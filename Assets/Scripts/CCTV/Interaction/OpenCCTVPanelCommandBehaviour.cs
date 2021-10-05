using System.Collections;
using UnityEngine;
using VEngine.Interaction.Command;

namespace VEngine.CCTV.Interaction
{
	public class OpenCCTVPanelCommandBehaviour : CommandBehaviour, OpenCCTVPanelCommand.IData
	{
		[SerializeField] private CCTVControllerBehaviour _controller;
		public ICCTVController Controller => _controller.Controller;

		protected override ICommand CreateCommand() => new OpenCCTVPanelCommand(this);
	}
}