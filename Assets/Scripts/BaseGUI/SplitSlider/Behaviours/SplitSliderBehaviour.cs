using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VEngine.GUI.Split
{
	public class SplitSliderBehaviour : WindowBehaviour, SplitSlider.ISplitSliderData
	{
		[SerializeField] private Button _decreaseBtn;
		[SerializeField] private Button _increaseBtn;
		[SerializeField] private Button _cancelBtn;
		[SerializeField] private Button _okBtn;
		[SerializeField] private Slider _slider;
		[SerializeField] private TextMeshProUGUI _minValueText;
		[SerializeField] private TextMeshProUGUI _maxValueText;
		[SerializeField] private TMP_InputField _currentValueText;

		private SplitSliderReference _splitSliderReference;
		private ISplitSlider _splitSlider;

		public ISplitSliderReference SplitSliderReference
		{
			get
			{
				if (_splitSliderReference == null)
					_splitSliderReference = new SplitSliderReference(_splitSlider);
				return _splitSliderReference;
			}
		}

		public Button DecreaseBtn => _decreaseBtn;
		public Button IncreaseBtn => _increaseBtn;
		public Button CancelBtn => _cancelBtn;
		public Button OkBtn => _okBtn;
		public TextMeshProUGUI MinValueText => _minValueText;
		public TextMeshProUGUI MaxValueText => _maxValueText;
		public TMP_InputField CurrentValueText => _currentValueText;
		public Slider Slider => _slider;

		private void SetSplitSliderReference(ISplitSlider value)
		{
			if (_splitSliderReference == null)
				_splitSliderReference = new SplitSliderReference(_splitSlider);
			else
				_splitSliderReference.Value = value;
		}

		protected override IWindow CreateWindow()
		{
			_splitSlider = new SplitSlider(this);
			SetSplitSliderReference(_splitSlider);
			_splitSlider.Close();
			return _splitSlider;
		}

		public void Open(uint minValue, uint maxValue, Action cancelCallback, Action<uint> okCallback) => _splitSlider.Open(minValue, maxValue, cancelCallback, okCallback);
	}
}
