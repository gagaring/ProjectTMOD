using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static VEngine.GUI.Context.ContextMenuElement;

namespace VEngine.GUI.Context
{
	public class ContextMenuElementBehaviour : MonoBehaviour
	{
		[SerializeField] private Components _components;

		public IContextMenuElement ContextMenuElement { get; private set; }

		protected void Awake()
		{
			ContextMenuElement = new ContextMenuElement(_components);
		}

		public void OnPressed()
		{
			ContextMenuElement.OnPressed();
		}

		[Serializable]
		private class Components : IComponents
		{
			[SerializeField] private TextMeshProUGUI _text;
			[SerializeField] private GameObject _gameObject;
			[SerializeField] private Button _button;

			public TMP_Text Text => _text;
			public GameObject Main => _gameObject;
			public Button Button => _button;
		}
	}
}
