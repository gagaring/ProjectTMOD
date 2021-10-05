using VEngine.Items;

namespace VEngine.Inventory
{
    public interface IConnector<I> where I : IItem 
    {
        bool Move(IInventory from, IInventory to, I item, uint amount);  
        bool Move(IInventory from, IInventory to, I item, int toIndex, uint amount);

        bool Move(IInventory from, IInventory to, int fromIndex, uint amount);
        bool Move(IInventory from, IInventory to, int fromIndex, int toIndex, uint amount);
    }
}
