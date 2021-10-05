using VEngine.GUI;

namespace VEngine.Crafting.GUI
{
    public interface ICraftingGUI : IPanel
    {
        void Open(IRecipe recipe);
		void OnCraftFinished(IRecipe recipe, bool success, string error);
	}
}
