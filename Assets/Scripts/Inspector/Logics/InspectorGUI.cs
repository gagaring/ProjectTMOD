using TMPro;
using UnityEngine;
using VEngine.GUI;
using VEngine.Items;

namespace VEngine.Inspector.GUI
{
	public class InspectorGUI : Window, IInspectorGUI
	{
		private readonly IInspectorData _data;

		public InspectorGUI(IInspectorData data) : base(data)
		{
			_data = data;
		}

		public void Inspect(IItem item)
		{
			_data.NameText.text = item.Details.Name;
			_data.Desciption.text = item.Details.Description;
		}

		public interface IInspectorData : IWindowData
		{
			TMP_Text NameText { get; }
			TMP_Text Desciption { get; }
		}
	}
}
