using NSubstitute;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using VEngine.SO.Variables;
using VEngine.GUI;
using VEngine.GUI.Draggable;

namespace VTest.GUI.Draggable
{
	public class Builder
	{
		private List<Canvas> _canvases = new List<Canvas>();
		private List<RectTransform> _rects = new List<RectTransform>();

		public static Builder Create()
		{
			return new Builder();
		}

		public void Destory()
		{
			foreach (var curr in _canvases)
				Object.DestroyImmediate(curr.gameObject);
			foreach (var curr in _rects)
				Object.DestroyImmediate(curr.gameObject);
		}

		public Builder CreateCanvas(out Canvas canvas)
		{
			canvas = new GameObject("Canvas").AddComponent<Canvas>();
			_canvases.Add(canvas);
			return this;
		}

		public Builder CreateSubstituteListener(IDraggableButtonEvents draggableButton, IClickEvents clickEvents, out IFakeListenerForDraggableButtonEvents fakeListener)
		{
			fakeListener = Substitute.For<IFakeListenerForDraggableButtonEvents>();
			clickEvents.OnLeftClicked.AddListener(fakeListener.OnLeftClicked);
			clickEvents.OnRightClicked.AddListener(fakeListener.OnRightClicked);
			clickEvents.OnMiddleClicked.AddListener(fakeListener.OnMiddleClicked);
			draggableButton.OnPositionChanged += fakeListener.OnPositionChanged;
			draggableButton.OnStateChanged += fakeListener.OnStateChanged;
			return this;
		}

		public Builder CreateSubstituteListener(IDropSlotChangedEvent dropSlotEvents, out IFakeListenerForDropSlotEvents fakeListener)
		{
			fakeListener = Substitute.For<IFakeListenerForDropSlotEvents>();
			dropSlotEvents.OnDropSlotChanged = fakeListener.OnDropSlotChanged;
			return this;
		}

		public Builder CreateDraggableButton(out DraggableButton draggableButton, out BoolReference isDragEnabledRef, PointerEventData.InputButton dragButton = PointerEventData.InputButton.Left, float dragPressWindowTime = 0.1f, bool isDragEnabled = true)
		{
			var timeWindow = new VEngine.SO.Variables.FloatReference();
			timeWindow.Init(0.1f);
			var rect = (new GameObject("Rect")).AddComponent<RectTransform>();
			_rects.Add(rect);
			isDragEnabledRef = new BoolReference();
			isDragEnabledRef.Init(isDragEnabled);
			var data = new DraggableData(dragButton, isDragEnabled, dragPressWindowTime);
			var clickEvents = new DraggableOnClickEvents();
			var comp = new DraggableComponents(rect, clickEvents);
			draggableButton = new DraggableButton(data, comp);
			return this;
		}

		public Builder CreateDraggableDropSlotComponent(out DraggableDropSlotComponent draggableButtonWithDropSlot, IDraggableButtonHandler draggableButtonHandler, IDraggableButtonEvents draggableButtonEvents)
		{
			draggableButtonWithDropSlot = new DraggableDropSlotComponent(draggableButtonHandler, draggableButtonEvents);
			return this;
		}

		public Builder CreateFakeDropSlot(out IDropSlot dropSlot)
		{
			dropSlot = Substitute.For<IDropSlot>();
			return this;
		}

		protected class DraggableData : DraggableButton.IDraggableData
		{
			public PointerEventData.InputButton DragButton { get; set; }
			public bool IsDragEnabled { get; set; }
			public float DragPressWindowTime { get; set; }

			public DraggableData(PointerEventData.InputButton dragButton, bool isDragEnabled, float dragPressWindowTime)
			{
				DragButton = dragButton;
				IsDragEnabled = isDragEnabled;
				DragPressWindowTime = dragPressWindowTime;
			}
		}

		protected class DraggableComponents : DraggableButton.IDraggableComponents
		{
			public RectTransform RectTransform { get; set; }
			public IClickEvents ClickEvents { get; set; }

			public DraggableComponents(RectTransform rect, DraggableOnClickEvents clickEvents)
			{
				RectTransform = rect;
				ClickEvents = clickEvents;
			}
		}

		protected class DraggableOnClickEvents : IClickEvents
		{
			public UnityEvent OnLeftClicked { get; set; }
			public UnityEvent OnRightClicked { get; set; }
			public UnityEvent OnMiddleClicked { get; set; }

			public DraggableOnClickEvents()
			{
				OnLeftClicked = new UnityEvent();
				OnRightClicked = new UnityEvent();
				OnMiddleClicked = new UnityEvent();
			}
		}
	}

	public interface IFakeListenerForDraggableButtonEvents
	{
		void OnLeftClicked();
		void OnRightClicked();
		void OnMiddleClicked();
		void OnPositionChanged(Vector2 arg0);

		void OnStateChanged(eState state);
	}

	public interface IFakeListenerForDropSlotEvents
	{
		void OnDropSlotChanged(IDropSlot prev, IDropSlot curr);
	}
}
