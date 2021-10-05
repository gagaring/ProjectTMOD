using System.Collections.Generic;
using VEngine.Items;

namespace VEngine.Crafting
{
    public interface IRecipes 
    {
        List<IRecipe> List { get; }
        bool Contains(List<IItem> materials, out IRecipe recipe);
    }
}
