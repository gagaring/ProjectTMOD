using System;
using UnityEngine;
using UnityEngine.UI;
using VEngine.GUI;
using VEngine.Inventory.GUI;

namespace VEngine.Crafting.GUI
{
	public class RecipeListGUIElement : IRecipeListGUIElement
	{
		private readonly IData _data;
		private readonly IComponents _components;
		private IRecipe _recipe;

		public bool Selected { set => _components.Selection.IsSelected = value; }

		public Action<IRecipe> OnClicked { get; set; }

		public IRecipe Recipe 
		{ 
			get => _recipe; 
			set
			{
				_recipe = value;
				var hasRecipe = _recipe != null;
				var details = InventoryGUIItemComponent.FindOn(_recipe.Result.Item);
				_components.AvatarImage = hasRecipe ? details.Avatar : _data.Locked;
				_components.ItemName = hasRecipe ? _recipe.Result.Item.Details.Name : "";
				_components.Button.interactable = hasRecipe;
			}
		}

		public RecipeListGUIElement(IData data, IComponents components)
		{
			_data = data;
			_components = components;
			_components.Button.onClick.AddListener(OnButtonClicked);
		}

		private void OnButtonClicked()
		{
			OnClicked(Recipe);
		}

		public interface IComponents
		{
			Sprite AvatarImage { set; }
			public string ItemName { set; }
			Button Button { get; }
			ISelection Selection { get; }
		}

		public interface IData
		{
			Sprite Locked { get; }
		}
	}
}
