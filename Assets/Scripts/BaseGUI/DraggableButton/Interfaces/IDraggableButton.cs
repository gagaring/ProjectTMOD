using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace VEngine.GUI.Draggable
{
	public enum eState
	{
		StandBy,
		OnDrag,
	}

	public interface IDraggableButtonHandler
	{
		eState State { get; }
		Vector2 Position { get; set; }

		void Update(float deltaTime);

		void OnPointerDown(PointerEventData eventData);
		void OnPointerUp(PointerEventData eventData);

		void OnBeginDrag(PointerEventData eventData);
		void OnDrag(PointerEventData eventData);
		void OnEndDrag(PointerEventData eventData);

		void OnPointerClick(PointerEventData eventData);
		
		PointerEventData.InputButton DragButton { get; }

		bool IsDragEnabled(PointerEventData.InputButton button);
	}

	public interface IClickEvents
	{
		UnityEvent OnLeftClicked { get; set; }
		UnityEvent OnRightClicked { get; set; }
		UnityEvent OnMiddleClicked { get; set; }
	}

	public interface IDraggableButtonEvents
	{
		Action<eState> OnStateChanged { get; set; }
		Action<Vector2> OnPositionChanged { get; set; }
	}

	public interface IDraggableDropSlotHandler
	{
		IDropSlot DropSlot { get; set; }
	}

	public interface IDropSlotChangedEvent
	{
		Action<IDropSlot, IDropSlot> OnDropSlotChanged { get; set; }
	}
}
