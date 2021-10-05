using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace VEngine.GUI.Split
{
	public interface ISplitSliderReference
	{
		public ISplitSlider Value { get; }
	}

	public class SplitSliderReference : ISplitSliderReference
	{
		public ISplitSlider Value { get; set; }

		public SplitSliderReference(ISplitSlider splitSlider = null)
		{
			Value = splitSlider;
		}
	}

	public class SplitSlider : Window, ISplitSlider
	{
		private readonly ISplitSliderData _data;

		private uint _minValue;
		private uint _maxValue;
		private uint _currentValue;

		private bool _updateSliderEnabled;
		private bool _updateInputTextEnabled;

		private Action _cancelCallback;
		private Action<uint> _okCallback;

		public uint MinValue
		{
			get => _minValue;
			private set
			{
				_minValue = value;
				_data.MinValueText.text = value.ToString();
				_data.Slider.minValue = value;
			}
		}

		public uint MaxValue
		{
			get => _maxValue;
			private set
			{
				_maxValue = value;
				_data.MaxValueText.text = value.ToString();
				_data.Slider.maxValue = value;
			}
		}

		public uint CurrentValue
		{
			get => _currentValue;
			private set
			{
				if (MinValue > value)
					value = MinValue;
				else if (MaxValue < value)
					value = MaxValue;
				_data.DecreaseBtn.interactable = value > MinValue;
				_data.IncreaseBtn.interactable = value < MaxValue;
				_currentValue = value;
				_data.CurrentValueText.text = value.ToString();
				if(_updateSliderEnabled)
					_data.Slider.value = value;
			}
		}

		public SplitSlider(ISplitSliderData data) : base(data)
		{
			_data = data;
			RegisterEvents();
		}

		~SplitSlider()
		{
			UnregisterEvents();
		}

		public void Open(uint minValue, uint maxValue, Action cancelCallback, Action<uint> okCallback)
		{
			base.Open();
			MinValue = minValue;
			MaxValue = maxValue;
			_updateInputTextEnabled = true;
			_updateSliderEnabled = true;
			CurrentValue = (uint)Mathf.RoundToInt((minValue + maxValue) * 0.5f);
			_okCallback = okCallback;
			_cancelCallback = cancelCallback;
		}

		private void RegisterEvents()
		{
			_data.DecreaseBtn.onClick.AddListener(OnDecreaseClicked);
			_data.IncreaseBtn.onClick.AddListener(OnIncreaseClicked);
			_data.CancelBtn.onClick.AddListener(OnCancelClicked);
			_data.OkBtn.onClick.AddListener(OnOkClicked);

			_data.CurrentValueText.onValueChanged.AddListener(OnInputFieldValueChanged);
			_data.Slider.onValueChanged.AddListener(OnSliderValueChanged);
		}

		private void UnregisterEvents()
		{
			_data.DecreaseBtn.onClick.RemoveListener(OnDecreaseClicked);
			_data.IncreaseBtn.onClick.RemoveListener(OnIncreaseClicked);
			_data.CancelBtn.onClick.RemoveListener(OnCancelClicked);
			_data.OkBtn.onClick.RemoveListener(OnOkClicked);
			_data.CurrentValueText.onValueChanged.RemoveListener(OnInputFieldValueChanged);
		}

		private void OnOkClicked()
		{
			Close();
			_okCallback.Invoke(CurrentValue);
		}

		private void OnCancelClicked()
		{
			Close();
			_cancelCallback.Invoke();
		}

		private void OnIncreaseClicked()
		{
			if (CurrentValue == uint.MaxValue)
				return;
			++CurrentValue;
		}

		private void OnDecreaseClicked()
		{
			if (CurrentValue == uint.MinValue)
				return;
			--CurrentValue;
		}

		private void OnInputFieldValueChanged(string newValue)
		{
			if (!_updateInputTextEnabled)
				return;
			_updateInputTextEnabled = false;
			if (uint.TryParse(newValue, out var number))
				CurrentValue = number;
			_updateInputTextEnabled = true;
		}

		private void OnSliderValueChanged(float value)
		{
			_updateSliderEnabled = false;
			CurrentValue = (uint)Mathf.RoundToInt(value);
			_updateSliderEnabled = true;
		}

		public interface ISplitSliderData : IWindowData
		{
			Button DecreaseBtn { get; }
			Button IncreaseBtn { get; }
			Button CancelBtn { get; }
			Button OkBtn { get; }
			TextMeshProUGUI MinValueText { get; }
			TextMeshProUGUI MaxValueText { get; }
			TMP_InputField CurrentValueText { get; }
			Slider Slider { get; }
		}
	}
}
