using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VEngine.Crafting.GUI
{
	public class RecipeGUIBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		private IRecipeGUI _recipeGUI;

		public IRecipeGUI RecipeGUI
		{
			get
			{
				if (_recipeGUI == null)
					_recipeGUI = new RecipeGUI(_data, _components);
				return _recipeGUI;
			}
		}

		[Serializable]
		public class Data : RecipeGUI.IData
		{
			[SerializeField] private CraftingSO _crafting;
			public ICraftingQueries CraftingQueries => _crafting.CraftingQueries;
		}

		[Serializable]
		public class Components : RecipeGUI.IComponents
		{
			[SerializeField] private GameObject _main;
			[SerializeField] private TextMeshProUGUI _name;
			[SerializeField] private TextMeshProUGUI _description;
			[SerializeField] private TextMeshProUGUI _amount;
			[SerializeField] private Image _avatar;
			[SerializeField] private List<RecipeGUIMaterialBehaviour> _materials;

			public string Name { set => _name.text = value; }
			public string Description { set => _description.text = value; }
			public string Amount { set => _amount.text = value; }
			public Sprite Avatar { set => _avatar.sprite = value; }


			public IReadOnlyList<IRecipeGUIMaterial> Materials
			{
				get
				{
					var list = new List<IRecipeGUIMaterial>();
					foreach (var curr in _materials)
						list.Add(curr.Material);
					return list;
				}
			}

			public GameObject Main => _main;
		}
	}
}
