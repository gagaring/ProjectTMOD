using System;
using UnityEngine;

namespace VEngine.Crafting.GUI
{
	public class RecipeListGUIBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		private IRecipeListGUI _recipeListGUI;

		public IRecipeListGUI RecipeListGUI
		{
			get
			{
				if (_recipeListGUI == null)
					_recipeListGUI = new RecipeListGUI(_data, _components);
				return _recipeListGUI;
			}
		}

		[Serializable]
		public class Components : RecipeListGUI.IComponents
		{
			[SerializeField] private GameObject _parent;
			[SerializeField] private GameObject _noAvailableRecipe;
			[SerializeField] private GameObject _recipes;
			[SerializeField] private int _minimumElementCount;
			[SerializeField] private RecipeListGUIElementBehaviour _elementPrefab;


			public GameObject Parent => _parent;
			public GameObject NoAvailableRecipe => _noAvailableRecipe;
			public GameObject Recipes => _recipes;
			public RecipeListGUIElementBehaviour ElementPrefab => _elementPrefab;
			public int MinimumElementCount => _minimumElementCount;
		}

		[Serializable]
		public class Data : RecipeListGUI.IData
		{
			[SerializeField] private Recipes _availableRecipes;

			public IRecipes AvailableRecipes => _availableRecipes;
		}
	}
}
