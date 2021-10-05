using VEngine.Inventory.GUI;

namespace VEngine.Crafting.GUI.InventoryExtension
{
	public interface ICraftingInventoryExtension
	{
		void StartCrafting(IInventoryItemGUI firstItem);
		void Close();
		void OnCraftFinished(IRecipe recipe, bool success, string error);
	}
}
