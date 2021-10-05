using System.Collections.Generic;
using TMPro;
using VEngine.GUI;
using VEngine.Interaction.Command;
using VEngine.SO.Events;

namespace VEngine.Interaction.GUI
{
	public class PasswordWindow : Window, IPasswordWindow
	{
		private readonly IPasswordWindowData _data;

		private string _password;
		private IPasswordLock _requiredPassword;
		private bool _passwordSent = false;

		public PasswordWindow(IPasswordWindowData data) : base(data)
		{
			_data = data;
			RegisterOnButtons();
		}

		private void RegisterOnButtons()
		{
			var buttons = _data.Buttons;
			for (int i = 0; i < buttons.Count; ++i)
			{
				buttons[i].Index = i;
				buttons[i].OnButtonPressed += OnButtonPressed;
			}
		}

		public void OpenPanel(IPasswordLock password)
		{
			Open(password != null);
			if (!_isOpened)
				return;
			_passwordSent = false;
			_requiredPassword = password;
			SetPassword(password.IsUnlocked ? password.Password.ToString() : "");
		}

		public void OnOkClicked()
		{
			if (_password.Length == 0)
			{
				OnPasswordError();
				return;
			}
			var currentPassword = int.Parse(_password);
			if (currentPassword == _requiredPassword.Password)
			{
				SendPassword(currentPassword);
				ClosePanel();
			}
			else
				OnPasswordError();
		}

		private void ClosePanel()
		{
			base.Close();
		}

		private void OnPasswordError()
		{
			_data.PasswordText.text = "Error";
			_password = "";
		}

		public override void Close()
		{
			SendPassword(-1);
			ClosePanel();
		}

		public void OnCancelClicked()
		{
			Close();
		}

		private void SendPassword(int password)
		{
			if (_passwordSent)
				return;
			_data.OnPasswordEntered.Raise(password);
			_passwordSent = true;
		}

		public void OnClearClicked()
		{
			SetPassword("");
		}

		public void OnBackspacePressed()
		{
			var length = _password.Length;
			if (length == 0)
				return;
			SetPassword(_password.Substring(0, length - 1));
		}

		private void SetPassword(string password)
		{
			_password = password;
			_data.PasswordText.text = password + GetUnderLines(_requiredPassword.Password.ToString().Length - password.Length);
		}

		private string GetUnderLines(int count)
		{
			string underlines = "";
			for (int i = 0; i < count; ++i)
				underlines += "_";
			return underlines;
		}

		private void OnButtonPressed(int pressed)
		{
			if (_password.Length == _requiredPassword.Password.ToString().Length)
				return;
			SetPassword($"{_password}{pressed}");
		}

		public interface IPasswordWindowData : IWindowData
		{
			IReadOnlyList<PasswordButton> Buttons { get; }
			IGameEvent<int> OnPasswordEntered { get; }
			TMP_Text PasswordText { get; } 
		}
	}
}