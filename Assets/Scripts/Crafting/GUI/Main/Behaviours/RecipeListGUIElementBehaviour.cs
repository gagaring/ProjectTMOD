using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VEngine.SO.Variables;
using VEngine.GUI;

namespace VEngine.Crafting.GUI
{
	public class RecipeListGUIElementBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		private IRecipeListGUIElement _element;

		public IRecipeListGUIElement Element
		{
			get
			{
				if (_element == null)
					_element = new RecipeListGUIElement(_data, _components);
				return _element;
			}
		}

		[Serializable]
		public class Components : RecipeListGUIElement.IComponents
		{
			[SerializeField] private Image _resultItem;
			[SerializeField] private TextMeshProUGUI _name;
			[SerializeField] private Button _button;
			[SerializeField] private SelectionBehaviour _selection;

			public Sprite AvatarImage { set => _resultItem.sprite = value; }
			public string ItemName { set => _name.text = value; }
			public Button Button => _button;
			public ISelection Selection => _selection.Selection;
		}

		[Serializable]
		public class Data : RecipeListGUIElement.IData
		{
			[SerializeField] private SpriteReference _locked;

			public Sprite Locked => _locked.Value;
		}
	}
}
