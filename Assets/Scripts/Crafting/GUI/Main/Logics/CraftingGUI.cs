using UnityEngine;
using UnityEngine.UI;
using VEngine.GUI;
using VEngine.Input;
using VEngine.SO.Events;

namespace VEngine.Crafting.GUI
{
	public class CraftingGUI : Panel, ICraftingGUI
	{
		private readonly ICraftingData _data;

		private bool _isCraftInProgress = false;

		public CraftingGUI(ICraftingData data) : base(data)
		{
			_data = data;
			_data.CraftButton.onClick.AddListener(OnCraftClicked);
			_data.RecipeList.OnRecipeClicked += SelectRecipe;
		}

		public override void Open(bool open)
		{
			_data.InputActivator.Activate(open);
			if (!open)
			{
				Close();
				return;
			}
			Open(_data.CurrentRecipe.Recipe);
		}

		private void SelectRecipe(IRecipe recipe)
		{
			_data.RecipeList.Refresh(_data.AvailableRecipes);
			_data.CurrentRecipe.Recipe = recipe;
			_data.RecipeList.Selected = recipe;
			SetCractButtonInteractable(recipe);
		}

		private void SetCractButtonInteractable(IRecipe recipe)
		{
			if (_data.CurrentRecipe.Recipe != recipe)
				return;
			_data.CraftButton.interactable = recipe != null && _data.CraftingQueries.CanCraft(recipe);
		}

		private void OnCraftClicked()
		{
			_isCraftInProgress = true;
			_data.Craft.Raise(_data.CurrentRecipe.Recipe);
		}

		public void Open(IRecipe recipe)
		{
			base.Open();
			SelectRecipe(recipe);
		}

		public void OnCraftFinished(IRecipe recipe, bool success, string error)
		{
			if (!_isCraftInProgress)
				return;
			_isCraftInProgress = false;
			SetCractButtonInteractable(recipe);
			Debug.LogError($"Craft is finished: {success} - {error}");
		}

		public interface ICraftingData : IPanelData
		{
			TGameEvent<IRecipe> Craft { get; }
			IRecipes AvailableRecipes { get; }
			ICraftingQueries CraftingQueries { get; }
			IInputActivator InputActivator { get; }
			IRecipeListGUI RecipeList { get; }
			IRecipeGUI CurrentRecipe { get; }
			Button CraftButton { get; }
		}
	}
}
