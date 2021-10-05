using TMPro;

namespace VEngine.GUI
{
	public class TextSetter : ITextSetter
	{
		private readonly IData _data;
		private readonly IComponents _components;

		public TextSetter(IData data, IComponents components)
		{
			_data = data;
			_components = components;
		}

		public void RefreshFont()
		{
			_components.Text.font = _data.Font;
		}

		public void RefreshText()
		{
			if (!_data.IsTextRefreshEnabled || _data.Text == null)
				return;
			_components.Text.text = _data.Text;
		}

		public interface IData
		{
			TMP_FontAsset Font { get; }
			string Text { get; }
			bool IsTextRefreshEnabled { get; }
		}

		public interface IComponents
		{
			TextMeshProUGUI Text { get; }
		}
	}
}
