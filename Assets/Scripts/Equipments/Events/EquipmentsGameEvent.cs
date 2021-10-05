using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.Equipments
{
	[CreateAssetMenu(menuName = "SO/Equipments/Events/EquipmentsGameEvents", fileName = "EquipmentsGameEvent")]
	public class EquipmentsGameEvent : TGameEvent<IReadOnlyEquipmentList>
	{
	}
}
