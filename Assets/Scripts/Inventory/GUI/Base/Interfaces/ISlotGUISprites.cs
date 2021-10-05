using UnityEngine;

namespace VEngine.Inventory.GUI
{
	public interface ISlotGUISprites
	{
		Sprite AvailableSprite { get; }
		Sprite UnavailableSprite { get; }
	}
}
