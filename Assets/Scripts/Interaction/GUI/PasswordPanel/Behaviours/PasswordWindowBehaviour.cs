using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Events;
using TMPro;
using VEngine.Interaction.Command;
using VEngine.GUI;

namespace VEngine.Interaction.GUI
{
	public class PasswordWindowBehaviour : WindowBehaviour, PasswordWindow.IPasswordWindowData
	{
		[SerializeField] private IntGameEvent _onPasswordEntered;
		[SerializeField] private List<PasswordButton> _buttons;
		[SerializeField] private TextMeshProUGUI _passwordText;

		public IReadOnlyList<PasswordButton> Buttons => _buttons;
		public IGameEvent<int> OnPasswordEntered => _onPasswordEntered;
		public TMP_Text PasswordText => _passwordText;

		private IPasswordWindow PasswordWindow => (IPasswordWindow)Window;

		protected override IWindow CreateWindow() => new PasswordWindow(this);

		public void OnOkClicked() => PasswordWindow.OnOkClicked();
		public void OnCancelClicked() => PasswordWindow.OnCancelClicked();
		public void OnClearClicked() => PasswordWindow.OnClearClicked();
		public void OnBackspacePressed() => PasswordWindow.OnBackspacePressed();
		public void OpenPanel(IPasswordLock password) => PasswordWindow.OpenPanel(password);
	}
}
