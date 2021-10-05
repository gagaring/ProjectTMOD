using System.Collections.Generic;
using VEngine.Items;

namespace VEngine.Inventory
{
    public interface IInventory
    {
        IInventoryData Data { get; }
        IInventoryService Service { get; }
    }

    public interface IInventoryData
    {
        bool IsFull { get; }
        uint MaxCapacity { get; }
        uint AvailableCapacity { get; }
        int FreeSlotCount { get; }

        IReadOnlyList<IItemSlot> Slots { get; }

        uint AvailableFreeSpaceFor(IItem item);

        bool Contains(IItem item, uint requiredAmount = 1u);
        uint Contains(IItem item);

        bool IsSlotFree(int slotIndex);
        bool IsSlotAvailable(int slotIndex);
    }

    public interface IInventoryService
    {
        bool AddItem(IItem item, ref uint amount_intOut);
        bool AddItem(IItem item, int slotIndex, ref uint amount_intOut);

        bool Remove(IItem item, uint amount);
        bool Remove(int slotIndex, uint amount);

        bool MoveItem(int fromIndex, int toIndex);
        bool MoveItem(int fromIndex, int toIndex, uint amount);
    }
}
