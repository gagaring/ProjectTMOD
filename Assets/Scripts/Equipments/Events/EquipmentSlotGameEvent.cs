using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.Equipments
{
    [CreateAssetMenu(menuName = "SO/Equipments/Events/EquipmentSlotGameEvent")]
    public class EquipmentSlotGameEvent : TGameEvent<IReadOnlyEquipmentSlot>
    {
    }
}
