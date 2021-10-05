using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VEngine.GUI
{
	public interface IDropSlot
	{
		Vector2 Position { get; }

		void OnDrop(PointerEventData eventData);
	}
}
