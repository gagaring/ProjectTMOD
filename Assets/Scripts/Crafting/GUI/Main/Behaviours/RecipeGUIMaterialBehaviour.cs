using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VEngine.Crafting.GUI
{
	public class RecipeGUIMaterialBehaviour : MonoBehaviour
	{
		[SerializeField] private Components _components;

		private IRecipeGUIMaterial _material;

		public IRecipeGUIMaterial Material 
		{ 
			get
			{
				if (_material == null)
					_material = new RecipeGUIMaterial(_components);
				return _material;
			}
		}

		[Serializable]
		public class Components : RecipeGUIMaterial.IComponents
		{
			[SerializeField] private GameObject _main;
			[SerializeField] private Image _image;
			[SerializeField] private TextMeshProUGUI _name;

			public Sprite Avatar { set => _image.sprite = value; }
			public string Name { set => _name.text = value; }
			public GameObject Main => _main;
		}
	}
}
