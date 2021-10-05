using Sirenix.OdinInspector;
using UnityEngine;
using VEngine;
using VEngine.Interaction;


namespace VEngine.Game.SO.Interaction
{
	[CreateAssetMenu(menuName = "SO/Interaction/InteractionData")]
	public class InteractionData : SerializedScriptableObject
	{
		[ReadOnly][SerializeField] private IInteractable _selectedInteractable;
		[SerializeField] private InteractableBaseGameEvent _onSelectionChanged;

		public IInteractable Interactable
		{
			get => _selectedInteractable;
			set
			{
				if (_selectedInteractable == value)
					return;
				_selectedInteractable = value;
				_onSelectionChanged.Raise(value);
			}
		}

		public bool IsEmpty
		{
			get => _selectedInteractable == null;
		}
	}
}
