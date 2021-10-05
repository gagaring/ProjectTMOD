using UnityEngine;
using VEngine.Inventory.GUI;
using VEngine.Items;

namespace VEngine.Crafting.GUI
{
	public class RecipeGUIMaterial : IRecipeGUIMaterial
	{
		private IComponents _components;

		public RecipeGUIMaterial(IComponents components)
		{
			_components = components;
		}

		public IItem Set
		{
			set
			{
				var hasItem = value != null;
				_components.Main.SetActive(hasItem);
				if (!hasItem)
					return;
				var details = ScriptableObject.CreateInstance<InventoryGUIItemComponent>();
				_components.Avatar = details.Avatar;
				_components.Name = value.Details.Name;
			}
		}

		public interface IComponents
		{
			GameObject Main { get; }
			Sprite Avatar { set; }
			string Name { set; }
		}
	}
}
