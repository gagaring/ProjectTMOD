using VEngine.Interaction;
using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.Game.SO.Interaction
{
    [CreateAssetMenu(menuName = "SO/Events/InteractableBaseGameEvent")]
    public class InteractableBaseGameEvent : TGameEvent<IInteractable>
    {
    }
}
