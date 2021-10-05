using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VEngine.GUI.Draggable
{
	public class DropSlotBehaviour : MonoBehaviour, IDropHandler
	{
		[SerializeField] protected DropSlotComponents _dropSlotComponents;

		protected IDropSlot _dropSlotHandler;

		public Vector2 SlotPosition { get => _dropSlotComponents.RectTransform.position; set => _dropSlotComponents.RectTransform.position = value; }

		protected virtual void Awake()
		{
			if (_dropSlotComponents == null)
				_dropSlotComponents = new DropSlotComponents();
			if (_dropSlotComponents.RectTransform == null)
				_dropSlotComponents.RectTransform = GetComponent<RectTransform>();
		}

		protected virtual void Start()
		{
			CreateDropSlot();
		}

		protected virtual void CreateDropSlot()
		{
			var dropSlot = new DropSlot(_dropSlotComponents);
			_dropSlotHandler = dropSlot;
		}

		public void OnDrop(PointerEventData eventData) => _dropSlotHandler.OnDrop(eventData);

		[Serializable]
		protected class DropSlotComponents : DropSlot.IDropSlotComponents
		{
			[SerializeField] private RectTransform _rectTransform;

			public Vector2 Position => _rectTransform.position;
			public RectTransform RectTransform { get => _rectTransform; set => _rectTransform = value; }
		}
	}
}
