using TMPro;
using UnityEngine;
using VEngine.Items;
using VEngine.GUI;

namespace VEngine.Inspector.GUI
{
	public class InspectorGUIBehaviour : WindowBehaviour, InspectorGUI.IInspectorData
	{
		[SerializeField] private TextMeshProUGUI _nameText;
		[SerializeField] private TextMeshProUGUI _desciption;

		private IInspectorGUI InspectorGUI => (IInspectorGUI)Window;

		public TMP_Text Desciption => _desciption;
		public TMP_Text NameText => _nameText;

		public void Inspect(IItem item) => InspectorGUI.Inspect(item);
		protected override IWindow CreateWindow() => new InspectorGUI(this);

		private void Start() => Close();
	}
}
