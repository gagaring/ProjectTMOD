using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VEngine.Interaction.GUI
{
	public class PasswordButton : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _text;
		[SerializeField] private Button _button;

		private int _index;

		public Action<int> OnButtonPressed { get; set; }
		public int Index 
		{ 
			set
			{
				_index = value;
				_text.text = value.ToString();
			}		
		}

		private void Awake() => _button.onClick.AddListener(OnClicked);
		private void OnClicked() => OnButtonPressed?.Invoke(_index);
		public void OnValidate() => _button = GetComponent<Button>();
	}
}