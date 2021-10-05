using UnityEngine;
using UnityEngine.UI;
using VEngine.GUI;
using VEngine.Input;
using VEngine.SO.Events;

namespace VEngine.Crafting.GUI
{
    public class CraftingGUIBehaviour : PanelBehaviour, CraftingGUI.ICraftingData
	{
		[SerializeField] private RecipesReference _availableRecipes;
		[SerializeField] private RecipeGameEvent _craftEvent;
		[SerializeField] private CraftingSO _craftingSO;

		[SerializeField] private RecipeListGUIBehaviour _recipeListGUI;
		[SerializeField] private RecipeGUIBehaviour _recipeGUI;
		[SerializeField] private Button _craftButton;
		[SerializeField] private InputActivator _inputActivator;

		public IRecipeListGUI RecipeList => _recipeListGUI.RecipeListGUI;
		public IRecipeGUI CurrentRecipe => _recipeGUI.RecipeGUI;
		public Button CraftButton => _craftButton;
		public IRecipes AvailableRecipes => _availableRecipes.Variable;
		public TGameEvent<IRecipe> Craft => _craftEvent;
		public ICraftingQueries CraftingQueries => _craftingSO.CraftingQueries;

		public IInputActivator InputActivator => _inputActivator;

		private ICraftingGUI _craftingGUI;

		protected override void Awake()
		{
			base.Awake();
			Open(false);
		}

        public void Open(IRecipe recipe) => _craftingGUI.Open(recipe);

		public void OnCraftFinished(IRecipe recipe, bool success, string error)
			=> _craftingGUI.OnCraftFinished(recipe, success, error);

		protected override IPanel CreatePanel()
		{
			_craftingGUI = new CraftingGUI(this);
			return _craftingGUI;
		}
	}
}
