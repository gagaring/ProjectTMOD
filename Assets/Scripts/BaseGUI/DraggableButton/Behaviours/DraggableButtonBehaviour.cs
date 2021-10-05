using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using VEngine.SO.Variables;

namespace VEngine.GUI.Draggable
{
	[RequireComponent(typeof(CanvasGroup))]
	public class DraggableButtonBehaviour : MonoBehaviour, IDraggableButtonBehaviour, IDropSlotHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		[SerializeField] protected DraggableData _draggableData;
		[SerializeField] protected DraggableComponents _draggableComponents;

		protected IDraggableDropSlotHandler _dropSlotHandler;
		protected IDropSlotChangedEvent _dropSlotChangeEvent;

		public IDraggableButtonEvents Events { get; private set; }
		public IDraggableButtonHandler Handler { get; private set; }
		public IParentHandler ParentHandler { get; private set; }
		public IClickEvents ClickEvents { get => _draggableComponents.ClickEvents; }

		protected virtual void Awake()
		{
			GetDraggableComponents();
			CreateDraggableButton();
			CreateDraggableDropSlotComponent();
			RegisterOnDraggableButtonEvents();
			RegisterOnDraggableDropSlotChangeEvents();
		}

		private void GetDraggableComponents()
		{
			if (_draggableData == null)
				_draggableData = new DraggableData();
			if (_draggableComponents == null)
				_draggableComponents = new DraggableComponents();

			if (_draggableComponents.RectTransform == null)
				_draggableComponents.RectTransform = GetComponent<RectTransform>();
			if (_draggableComponents.CanvasGroup == null)
				_draggableComponents.CanvasGroup = GetComponentInParent<CanvasGroup>();
		}

		protected virtual void CreateDraggableButton()
		{
			var draggableButton = new DraggableButton(_draggableData, _draggableComponents);
			SetupDraggableInterfaces(draggableButton);
		}

		protected void SetupDraggableInterfaces(DraggableButton draggableButton)
		{
			Events = draggableButton;
			Handler = draggableButton;
			ParentHandler = draggableButton;
		}

		private void CreateDraggableDropSlotComponent()
		{
			var dropSlotComponent = new DraggableDropSlotComponent(Handler, Events);
			_dropSlotHandler = dropSlotComponent;
			_dropSlotChangeEvent = dropSlotComponent;
		}

		protected virtual void RegisterOnDraggableButtonEvents()
		{
			Events.OnStateChanged += (value) => _draggableComponents.CanvasGroup.blocksRaycasts = value != eState.OnDrag;
		}

		protected virtual void RegisterOnDraggableDropSlotChangeEvents() => _dropSlotChangeEvent.OnDropSlotChanged = (prev, curr) => Handler.Position = curr.Position;

		public void Update() => Handler.Update(Time.deltaTime);

		public void OnBeginDrag(PointerEventData eventData) => Handler.OnBeginDrag(eventData);
		public void OnPointerDown(PointerEventData eventData) => Handler.OnPointerDown(eventData);
		public void OnPointerUp(PointerEventData eventData) => Handler.OnPointerUp(eventData);
		public void OnDrag(PointerEventData eventData) => Handler.OnDrag(eventData);
		public void OnEndDrag(PointerEventData eventData) => Handler.OnEndDrag(eventData);
		public void OnPointerClick(PointerEventData eventData) => Handler.OnPointerClick(eventData);

		public IDropSlot DropSlot { get => _dropSlotHandler.DropSlot; set => _dropSlotHandler.DropSlot = value; }
		public Action<IDropSlot, IDropSlot> OnDropSlotChanged { get => _dropSlotChangeEvent.OnDropSlotChanged; set => _dropSlotChangeEvent.OnDropSlotChanged = value; }

		[Serializable]
		protected class DraggableData : DraggableButton.IDraggableData
		{
			[SerializeField] protected BoolReference _isDragEnabled;
			[SerializeField] protected FloatReference _dragPressWindowTime;
			[SerializeField] protected PointerEventData.InputButton _dragButtonType = PointerEventData.InputButton.Left;

			public PointerEventData.InputButton DragButton => _dragButtonType;
			public bool IsDragEnabled => _isDragEnabled.Value;
			public float DragPressWindowTime => _dragPressWindowTime.Value;

			public DraggableData()
			{
				_dragPressWindowTime = new FloatReference();
				_dragPressWindowTime.Init(0.1f);
			}
		}

		[Serializable]
		protected class DraggableComponents : DraggableButton.IDraggableComponents
		{
			[SerializeField] protected RectTransform _rectTransform;
			[SerializeField] private CanvasGroup _canvasGroup;
			[SerializeField] protected DraggableOnClickEvents _onClickEvents;

			public RectTransform RectTransform { get => _rectTransform; set => _rectTransform = value; }
			public CanvasGroup CanvasGroup { get => _canvasGroup; set => _canvasGroup = value; }

			public IClickEvents ClickEvents => _onClickEvents;
			public void SetClickEvents(DraggableOnClickEvents clickEvents) => _onClickEvents = clickEvents;
		}

		[Serializable]
		protected class DraggableOnClickEvents : IClickEvents
		{
			[SerializeField] private UnityEvent _onLeftClicked;
			[SerializeField] private UnityEvent _onRightClicked;
			[SerializeField] private UnityEvent _onMiddleClicked;

			public UnityEvent OnLeftClicked { get => _onLeftClicked; set => _onLeftClicked = value; }
			public UnityEvent OnRightClicked { get => _onRightClicked; set => _onRightClicked = value; }
			public UnityEvent OnMiddleClicked { get => _onMiddleClicked; set => _onMiddleClicked = value; }
		}
	}
}
