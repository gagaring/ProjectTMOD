using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace VEngine.GUI.Draggable
{
	public class DraggableButton : IDraggableButtonHandler, IDraggableButtonEvents, IParentHandler
	{
		private readonly IDraggableData _data;
		private readonly IDraggableComponents _components;

		private readonly DelayedData _delayedSetOnDragData;

		private eState _state;

		public Action<Vector2> OnPositionChanged { get; set; }
		public Action<eState> OnStateChanged { get; set; }
		
		public Transform Parent { get => _components.RectTransform.parent; set => _components.RectTransform.SetParent(value); }
		public PointerEventData.InputButton DragButton { get => _data.DragButton; }

		public IClickEvents ClickEvents { get => _components.ClickEvents; }

		public eState State
		{
			get => _state;
			protected set
			{
				_state = value;
				_delayedSetOnDragData.Reset();
				OnStateChanged?.Invoke(_state);
			}
		}

		public Vector2 Position
		{
			get => _components.RectTransform.position;
			set
			{
				_components.RectTransform.position = value;
				OnPositionChanged?.Invoke(value);
			}
		}

		public DraggableButton(IDraggableData data, IDraggableComponents components)
		{
			_data = data;
			_components = components;
			_delayedSetOnDragData = new DelayedData(_data.DragPressWindowTime);
			State = eState.StandBy;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (!CanProcessStartDrag(eventData))
				return;
			_delayedSetOnDragData.Start(eventData);
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (!CanProcessStartDrag(eventData))
				return;
			StartDrag(eventData);
			_delayedSetOnDragData.Reset();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (!CanProcessDrag(eventData))
				return;
			State = eState.StandBy;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (!CanProcessDrag(eventData))
				return;
			State = eState.StandBy;
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (!CanProcessDrag(eventData))
				return;
			FollowPosition(eventData);
		}

		protected virtual void FollowPosition(PointerEventData eventData)
		{
			Position = eventData.position;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (State == eState.OnDrag)
				return;

			_delayedSetOnDragData.Reset();
			switch (eventData.button)
			{
				case PointerEventData.InputButton.Left: _components.ClickEvents.OnLeftClicked?.Invoke(); break;
				case PointerEventData.InputButton.Right: _components.ClickEvents.OnRightClicked?.Invoke(); break;
				case PointerEventData.InputButton.Middle: _components.ClickEvents.OnMiddleClicked?.Invoke(); break;
			}
		}

		private void StartDrag(PointerEventData eventData)
		{
			State = eState.OnDrag;
			FollowPosition(eventData);
			_delayedSetOnDragData.Reset();
		}

		private bool CanProcessStartDrag(PointerEventData eventData)
		{
			return _data.IsDragEnabled && _data.DragButton == eventData.button && State == eState.StandBy;
		}

		private bool CanProcessDrag(PointerEventData eventData)
		{
			return _data.DragButton == eventData.button && State == eState.OnDrag;
		}

		public void Update(float deltaTime)
		{
			RefreshState(deltaTime);
		}

		private void RefreshState(float deltaTime)
		{
			if (_state == eState.OnDrag)
				return;
			_delayedSetOnDragData.Update(deltaTime);
			if (_delayedSetOnDragData.OnDragAfter > 0.0f)
				return;
			StartDrag(_delayedSetOnDragData.EventData);
		}

		public bool IsDragEnabled(PointerEventData.InputButton button)
		{
			return _data.IsDragEnabled && button == DragButton;
		}

		private class DelayedData
		{
			public float DragPressWindowTime { get; private set; }
			public float OnDragAfter { get; set; }
			public PointerEventData EventData { get; private set; }

			public DelayedData(float dragPressWindowTime)
			{
				DragPressWindowTime = dragPressWindowTime;
			}

			public void Reset()
			{
				OnDragAfter = float.MaxValue;
				EventData = null;
			}

			public void Start(PointerEventData data)
			{
				OnDragAfter = DragPressWindowTime;
				EventData = data;
			}

			public void Update(float deltaTime)
			{
				if (OnDragAfter == float.MaxValue)
					return;
				OnDragAfter -= deltaTime;
			}
		}

		public interface IDraggableData
		{
			PointerEventData.InputButton DragButton { get; }
			bool IsDragEnabled { get; }
			float DragPressWindowTime { get; }
		}

		public interface IDraggableComponents
		{
			RectTransform RectTransform { get; }
			IClickEvents ClickEvents { get; }

		}
	}
}
