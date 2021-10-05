using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Inventory.GUI
{
	[CreateAssetMenu(menuName = "SO/Inventory/GUI/SlotSprites")]
	public class SlotGUISpriteReference : ScriptableObject, ISlotGUISprites
	{
		[SerializeField] private SpriteReference _availableSprite;
		[SerializeField] private SpriteReference _unavailableSprite;

		public Sprite AvailableSprite => _availableSprite.Value; 
		public Sprite UnavailableSprite => _unavailableSprite.Value;
	}
}
