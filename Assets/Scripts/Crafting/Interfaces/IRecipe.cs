using System.Collections.Generic;
using VEngine.Items;

namespace VEngine.Crafting
{
    public interface IRecipe
    {
        IResult Result { get; }
        List<IItem> Materials { get; }

        bool IsEqual(List<IItem> materials);
    }

    public interface IResult
    {
        IItem Item { get; }
        uint Amount { get; }
    }
}
