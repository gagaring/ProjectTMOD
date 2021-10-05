using System.Collections.Generic;
using VEngine.Items;

namespace VEngine.Crafting
{
    public interface ICombinator 
    {
        bool IsCombinatable(List<IItem> materials);
        bool IsCombinatable(List<IItem> materials, out IRecipe recipe);
        bool Combinate(List<IItem> material, out IResult craftedItem);
        bool IsCraftMaterial(IItem material);
    }
}
