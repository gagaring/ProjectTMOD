using System;
using TMPro;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.GUI.Text
{
	public class TextSetterBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		private ITextSetter _textSetter;

		public ITextSetter TextSetter
		{
			get
			{
				if (_textSetter == null)
					_textSetter = new TextSetter(_data, _components);
				return _textSetter;
			}
		}

		private void Awake()
		{
			Refresh();
		}

		private void Refresh()
		{
			RefreshFont();
			RefreshText();
		}

		public void RefreshFont()
		{
			TextSetter.RefreshFont();
		}

		public void RefreshText()
		{
			TextSetter.RefreshText();
		}

		[Serializable]
		public class Data : TextSetter.IData
		{
			[SerializeField] private FontReference _font;
			[SerializeField] private StringReference _text;
			[SerializeField] private bool _isTextRefreshEnabled = true;

			public TMP_FontAsset Font => _font.Value;
			public string Text => _text == null || !_text.IsValid ? "" : _text.Value;
			public bool IsTextRefreshEnabled => _isTextRefreshEnabled;
		}

		[Serializable]
		public class Components : TextSetter.IComponents
		{
			[SerializeField] private TextMeshProUGUI _textMeshPro;

			TextMeshProUGUI TextSetter.IComponents.Text => _textMeshPro;
		}
	}
}
