using System;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Crafting.GUI
{
	public class RecipeListGUI : IRecipeListGUI
	{
		private readonly IComponents _components;
		private readonly IData _data;

		private List<IRecipeListGUIElement> _elements = new List<IRecipeListGUIElement>();

		public Action<IRecipe> OnRecipeClicked { get; set; }

		public RecipeListGUI(IData data, IComponents components)
		{
			_data = data;
			_components = components;
		}

		public IRecipe Selected
		{
			set
			{
				DeselectAllRecipe();
				if(value == null || !SelectRecipe(value))
				{
					SelectFirstRecipe();
					return;
				}
				OnRecipeSelected(true);
			}
		}

		private bool SelectRecipe(IRecipe value)
		{
			foreach(var curr in _elements)
			{
				if (curr.Recipe != value)
					continue;
				curr.Selected = true;
				return true;
			}
			return false;
		}

		private void SelectFirstRecipe()
		{
			if (_elements.Count == 0 || !GetFirstNotNullRecipe(out var recipe))
			{
				OnRecipeSelected(false);
				return;
			}
			OnElementClicked(recipe);
		}

		private void OnRecipeSelected(bool selected)
		{
			_components.NoAvailableRecipe.SetActive(!selected);
			_components.Recipes.SetActive(selected);
		}

		private void DeselectAllRecipe()
		{
			foreach (var curr in _elements)
				curr.Selected = false;
		}

		private bool GetFirstNotNullRecipe(out IRecipe recipe)
		{
			foreach (var curr in _elements)
			{
				if (curr.Recipe == null)
					continue;
				recipe = curr.Recipe;
				return true;
			}
			recipe = null;
			return false;
		}

		public void Refresh(IRecipes availableRecipes)
		{
			CreateElements(availableRecipes);
			RefreshElements(availableRecipes);
			//ShowLockedElements(availableRecipes);
		}

		private void CreateElements(IRecipes availableRecipes)
		{
			for (int i = _elements.Count; i < availableRecipes.List.Count; ++i)
				CreateElement();
		}

		private void CreateElement()
		{
			var elementGO = UnityEngine.Object.Instantiate(_components.ElementPrefab, _components.Parent.transform);
			elementGO.gameObject.SetActive(true);
			_elements.Add(elementGO.Element);
			elementGO.Element.OnClicked += OnElementClicked;
		}

		private void RefreshElements(IRecipes availableRecipes)
		{
			for (int i = 0; i < availableRecipes.List.Count; ++i)
				_elements[i].Recipe = availableRecipes.List[i];
		}

		private void ShowLockedElements(IRecipes availableRecipes)
		{
			for (int i = availableRecipes.List.Count - 1; i < _elements.Count; ++i)
			{
				_elements[i].Recipe = null;
			}
		}

		private void OnElementClicked(IRecipe recipe)
		{
			OnRecipeClicked(recipe);
		}

		public interface IComponents
		{
			GameObject Recipes { get; }
			GameObject NoAvailableRecipe { get; }
			GameObject Parent { get; }
			RecipeListGUIElementBehaviour ElementPrefab { get; }

			int MinimumElementCount { get; }
		}

		public interface IData
		{
		}
	}
}
