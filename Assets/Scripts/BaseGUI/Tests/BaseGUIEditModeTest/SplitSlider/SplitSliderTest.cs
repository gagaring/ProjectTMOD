using NSubstitute;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VEngine.GUI;
using VEngine.GUI.Split;
using VEngine.SO.Events;

namespace VTest.GUI.SplitSliderTest
{
	public class SplitSliderTest
	{
		[Test]
		public void gameobject_is_active_after_open()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(0, 100, fakeListener.Cancel, fakeListener.Ok);
			Assert.IsTrue(builder.Main.activeSelf);
			builder.Destory();
		}

		[Test]
		public void gameobject_is_not_active_after_cancel_btn_pressed()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(0, 100, fakeListener.Cancel, fakeListener.Ok);
			Assert.IsTrue(builder.Main.activeSelf);

			builder.CancelBtn.onClick.Invoke();

			Assert.IsFalse(builder.Main.activeSelf);
			builder.Destory();
		}

		[Test]
		public void gameobject_is_not_active_after_ok_btn_pressed()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(0, 100, fakeListener.Cancel, fakeListener.Ok);
			Assert.IsTrue(builder.Main.activeSelf);

			builder.OkBtn.onClick.Invoke();

			Assert.IsFalse(builder.Main.activeSelf);
			builder.Destory();
		}

		[Test]
		public void gameobject_is_not_active_after_closed()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(0, 100, fakeListener.Cancel, fakeListener.Ok);
			Assert.IsTrue(builder.Main.activeSelf);

			splitSlider.Close();

			Assert.IsFalse(builder.Main.activeSelf);
			builder.Destory();
		}

		[Test]
		public void CurrentValue_is_50_if_MinValue_is_0_and_MaxValue_is_100()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(0, 100, fakeListener.Cancel, fakeListener.Ok);
			Assert.AreEqual(50, splitSlider.CurrentValue);
			builder.Destory();
		}

		[Test]
		public void CurrentValue_is_increased_when_increase_button_is_pressed_if_CurrentValue_is_less_then_MaxValue()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(0, 100, fakeListener.Cancel, fakeListener.Ok);

			Assert.AreEqual(50, splitSlider.CurrentValue);
			builder.IncreaseBtn.onClick.Invoke();
			Assert.AreEqual(51, splitSlider.CurrentValue);
			builder.IncreaseBtn.onClick.Invoke();
			Assert.AreEqual(52, splitSlider.CurrentValue);

			builder.Destory();
		}

		[Test]
		public void CurrentValue_is_not_increased_when_increase_button_is_pressed_if_CurrentValue_is_equal_as_MaxValue()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(0, 1, fakeListener.Cancel, fakeListener.Ok);

			Assert.AreEqual(0, splitSlider.CurrentValue);
			builder.IncreaseBtn.onClick.Invoke();
			Assert.AreEqual(1, splitSlider.CurrentValue);
			builder.IncreaseBtn.onClick.Invoke();
			Assert.AreEqual(1, splitSlider.CurrentValue);

			builder.Destory();
		}


		[Test]
		public void CurrentValue_is_decreased_when_increase_button_is_pressed_if_CurrentValue_is_more_then_MinValue()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(0, 100, fakeListener.Cancel, fakeListener.Ok);

			Assert.AreEqual(50, splitSlider.CurrentValue);
			builder.DecreaseBtn.onClick.Invoke();
			Assert.AreEqual(49, splitSlider.CurrentValue);
			builder.DecreaseBtn.onClick.Invoke();
			Assert.AreEqual(48, splitSlider.CurrentValue);

			builder.Destory();
		}

		[Test]
		public void CurrentValue_is_not_decreased_when_increase_button_is_pressed_if_CurrentValue_is_equal_as_MinValue()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(0, 2, fakeListener.Cancel, fakeListener.Ok);

			Assert.AreEqual(1, splitSlider.CurrentValue);
			builder.DecreaseBtn.onClick.Invoke();
			Assert.AreEqual(0, splitSlider.CurrentValue);
			builder.DecreaseBtn.onClick.Invoke();
			Assert.AreEqual(0, splitSlider.CurrentValue);

			builder.Destory();
		}

		[Test]
		public void CurrentValue_follow_the_slider_value()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(10, 100, fakeListener.Cancel, fakeListener.Ok);

			Assert.AreEqual(55, splitSlider.CurrentValue);

			var value = 56.0f;
			builder.Slider.value = value;
			Assert.AreEqual(Mathf.RoundToInt(value), splitSlider.CurrentValue);

			builder.Slider.value = 155;
			Assert.AreEqual(100, splitSlider.CurrentValue);

			builder.Slider.value = 0;
			Assert.AreEqual(10, splitSlider.CurrentValue);

			value = 75.978f;
			builder.Slider.value = value;
			Assert.AreEqual(Mathf.RoundToInt(value), splitSlider.CurrentValue);

			builder.Destory();
		}

		[Test]
		public void CurrentValue_follow_the_inputfield_value()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(10, 100, fakeListener.Cancel, fakeListener.Ok);

			Assert.AreEqual(55, splitSlider.CurrentValue);

			var value = 56;
			builder.CurrentValueText.text = value.ToString();
			Assert.AreEqual(Mathf.RoundToInt(value), splitSlider.CurrentValue);

			value = 155;
			builder.CurrentValueText.text = value.ToString();
			Assert.AreEqual(100, splitSlider.CurrentValue);

			value = 0;
			builder.CurrentValueText.text = value.ToString();
			Assert.AreEqual(10, splitSlider.CurrentValue);

			value = 78;
			builder.CurrentValueText.text = value.ToString();
			Assert.AreEqual(Mathf.RoundToInt(value), splitSlider.CurrentValue);

			builder.Destory();
		}


		[Test]
		public void InputField_follow_CurrentValue_on_slider_value_changed()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(10, 100, fakeListener.Cancel, fakeListener.Ok);

			Assert.AreEqual(55, splitSlider.CurrentValue);

			var value = 56.0f;
			builder.Slider.value = value;
			Assert.AreEqual(Mathf.RoundToInt(value), splitSlider.CurrentValue);
			Assert.AreEqual(splitSlider.CurrentValue.ToString(), builder.CurrentValueText.text);

			builder.Slider.value = 155;
			Assert.AreEqual(100, splitSlider.CurrentValue);
			Assert.AreEqual(splitSlider.CurrentValue.ToString(), builder.CurrentValueText.text);

			builder.Slider.value = 0;
			Assert.AreEqual(10, splitSlider.CurrentValue);
			Assert.AreEqual(splitSlider.CurrentValue.ToString(), builder.CurrentValueText.text);

			value = 75.978f;
			builder.Slider.value = value;
			Assert.AreEqual(Mathf.RoundToInt(value), splitSlider.CurrentValue);
			Assert.AreEqual(splitSlider.CurrentValue.ToString(), builder.CurrentValueText.text);

			builder.Destory();
		}

		[Test]
		public void Slider_follow_the_CurrentValue_on_inputFieldChanged()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(10, 100, fakeListener.Cancel, fakeListener.Ok);

			Assert.AreEqual(55, splitSlider.CurrentValue);

			var value = 56;
			builder.CurrentValueText.text = value.ToString();
			Assert.AreEqual(Mathf.RoundToInt(value), splitSlider.CurrentValue);
			Assert.AreEqual(splitSlider.CurrentValue, builder.Slider.value);

			value = 155;
			builder.CurrentValueText.text = value.ToString();
			Assert.AreEqual(100, splitSlider.CurrentValue);
			Assert.AreEqual(splitSlider.CurrentValue, builder.Slider.value);

			value = 0;
			builder.CurrentValueText.text = value.ToString();
			Assert.AreEqual(10, splitSlider.CurrentValue);
			Assert.AreEqual(splitSlider.CurrentValue, builder.Slider.value);

			value = 78;
			builder.CurrentValueText.text = value.ToString();
			Assert.AreEqual(Mathf.RoundToInt(value), splitSlider.CurrentValue);
			Assert.AreEqual(splitSlider.CurrentValue, builder.Slider.value);

			builder.Destory();
		}

		[Test]
		public void cancel_is_invoke_on_cancel_btn_pressed_if_CurrentValue_is_equal_as_MinValue()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(10, 100, fakeListener.Cancel, fakeListener.Ok);

			builder.CurrentValueText.text = (0).ToString();
			Assert.AreEqual(splitSlider.MinValue, splitSlider.CurrentValue);
			builder.Slider.value = 0;
			Assert.AreEqual(splitSlider.MinValue, splitSlider.CurrentValue);

			fakeListener.ClearReceivedCalls();
			builder.CancelBtn.onClick.Invoke();
			fakeListener.Received().Cancel();
			fakeListener.DidNotReceive().Ok(0);

			builder.Destory();
		}

		[Test]
		public void cancel_is_invoke_on_cancel_btn_pressed_if_CurrentValue_is_equal_as_MaxValue()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(0, 100, fakeListener.Cancel, fakeListener.Ok);

			builder.CurrentValueText.text = 1000.ToString();
			builder.Slider.value = 110;
			Assert.AreEqual(splitSlider.MaxValue, splitSlider.CurrentValue);

			fakeListener.ClearReceivedCalls();
			builder.CancelBtn.onClick.Invoke();
			fakeListener.Received().Cancel();
			fakeListener.DidNotReceive().Ok(0);

			builder.Destory();
		}

		[Test]
		public void cancel_is_invoke_on_cancel_btn_pressed()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(0, 100, fakeListener.Cancel, fakeListener.Ok);

			builder.CurrentValueText.text = 1000.ToString();
			builder.Slider.value = 110;
			Assert.AreEqual(100, splitSlider.CurrentValue);

			fakeListener.ClearReceivedCalls();
			builder.CancelBtn.onClick.Invoke();
			fakeListener.Received().Cancel();
			fakeListener.DidNotReceive().Ok(0);

			builder.Destory();
		}

		[Test]
		public void ok_is_invoke_on_ok_btn_pressed_if_CurrentValue_is_equal_as_MinValue()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(10, 100, fakeListener.Cancel, fakeListener.Ok);

			builder.CurrentValueText.text = (0).ToString();
			builder.Slider.value = 0;
			Assert.AreEqual(splitSlider.MinValue, splitSlider.CurrentValue);

			fakeListener.ClearReceivedCalls();
			builder.OkBtn.onClick.Invoke();
			fakeListener.DidNotReceive().Cancel();
			fakeListener.Received().Ok(splitSlider.MinValue);

			builder.Destory();
		}

		[Test]
		public void ok_is_invoke_on_ok_btn_pressed_if_CurrentValue_is_equal_as_MaxValue()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(0, 100, fakeListener.Cancel, fakeListener.Ok);

			builder.CurrentValueText.text = 1000.ToString();
			builder.Slider.value = 110;
			Assert.AreEqual(splitSlider.MaxValue, splitSlider.CurrentValue);

			fakeListener.ClearReceivedCalls();
			builder.OkBtn.onClick.Invoke();
			fakeListener.DidNotReceive().Cancel();
			fakeListener.Received().Ok(splitSlider.MaxValue);

			builder.Destory();
		}

		[Test]
		public void ok_is_invoke_on_ok_btn_pressed_if()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(0, 100, fakeListener.Cancel, fakeListener.Ok);

			builder.CurrentValueText.text = 56.ToString();
			builder.Slider.value = 56;
			Assert.AreEqual(56, splitSlider.CurrentValue);

			fakeListener.ClearReceivedCalls();
			builder.OkBtn.onClick.Invoke();
			fakeListener.DidNotReceive().Cancel();
			fakeListener.Received().Ok(56);

			builder.Destory();
		}

		[Test]
		public void decrease_button_is_interactable_if_current_value_is_more_than_min_value()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(10, 100, fakeListener.Cancel, fakeListener.Ok);

			var value = 11;
			builder.CurrentValueText.text = value.ToString();
			Assert.AreEqual(value, splitSlider.CurrentValue);
			Assert.IsTrue(builder.DecreaseBtn.interactable);

			value = 50;
			builder.CurrentValueText.text = value.ToString();
			Assert.AreEqual(value, splitSlider.CurrentValue);
			Assert.IsTrue(builder.DecreaseBtn.interactable);

			value = 100;
			builder.CurrentValueText.text = value.ToString();
			Assert.AreEqual(value, splitSlider.CurrentValue);
			Assert.IsTrue(builder.DecreaseBtn.interactable);

			builder.Destory();
		}

		[Test]
		public void decrease_button_is_not_interactable_if_current_value_is_equal_as_min_value()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(10, 100, fakeListener.Cancel, fakeListener.Ok);

			var value = 10;
			builder.CurrentValueText.text = value.ToString();
			Assert.AreEqual(value, splitSlider.CurrentValue);

			Assert.IsFalse(builder.DecreaseBtn.interactable);

			builder.Destory();
		}

		[Test]
		public void increase_button_is_interactable_if_current_value_is_less_then_max_value()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(10, 100, fakeListener.Cancel, fakeListener.Ok);

			var value = 99;
			builder.CurrentValueText.text = value.ToString();
			Assert.AreEqual(value, splitSlider.CurrentValue);

			value = 50;
			builder.CurrentValueText.text = value.ToString();
			Assert.AreEqual(value, splitSlider.CurrentValue);
			Assert.IsTrue(builder.IncreaseBtn.interactable);

			value = 10;
			builder.CurrentValueText.text = value.ToString();
			Assert.AreEqual(value, splitSlider.CurrentValue);
			Assert.IsTrue(builder.IncreaseBtn.interactable);

			Assert.IsTrue(builder.IncreaseBtn.interactable);

			builder.Destory();
		}

		[Test]
		public void increase_button_is_not_interactable_if_current_value_is_equal_as_max_value()
		{
			var builder = Builder.Create().CreateSplitSlider();
			var splitSlider = builder.SplitSlider;
			var fakeListener = Substitute.For<IFakeListener>();
			splitSlider.Open(10, 100, fakeListener.Cancel, fakeListener.Ok);

			var value = 100;
			builder.CurrentValueText.text = value.ToString();
			Assert.AreEqual(value, splitSlider.CurrentValue);

			Assert.IsFalse(builder.IncreaseBtn.interactable);

			builder.Destory();
		}
	}

	public interface IFakeListener
	{
		void Cancel();
		void Ok(uint value);
	}

	public class Builder : SplitSlider.ISplitSliderData
	{
		public Button DecreaseBtn { get; private set; }
		public Button IncreaseBtn { get; private set; }
		public Button CancelBtn { get; private set; }
		public Button OkBtn { get; private set; }
		public TextMeshProUGUI MinValueText { get; private set; }
		public TextMeshProUGUI MaxValueText { get; private set; }
		public TMP_InputField CurrentValueText { get; private set; }
		public Slider Slider { get; private set; }
		public ISplitSlider SplitSlider { get; private set; }

		public IGameEvent<IWindow, bool> OnOpened { get; private set; }

		public string Name => "SplitSliderTest";

		public GameObject Main { get; private set; }

		public static Builder Create()
		{
			return new Builder();
		}

		public Builder CreateSplitSlider()
		{
			Main = new GameObject("MainObject");
			DecreaseBtn = new GameObject("DecreaseBtn").AddComponent<Button>();
			IncreaseBtn = new GameObject("IncreaseBtn").AddComponent<Button>();
			CancelBtn = new GameObject("CancelBtn").AddComponent<Button>();
			OkBtn = new GameObject("OkBtn").AddComponent<Button>();
			MinValueText = new GameObject("MinValueText").AddComponent<TextMeshProUGUI>();
			MaxValueText = new GameObject("MaxValueText").AddComponent<TextMeshProUGUI>();
			CurrentValueText = new GameObject("CurrentValueText").AddComponent<TMP_InputField>();
			Slider = new GameObject("Slider").AddComponent<Slider>();
			OnOpened = Substitute.For<IGameEvent<IWindow, bool>>();
			CurrentValueText.contentType = TMP_InputField.ContentType.IntegerNumber;

			DecreaseBtn.transform.SetParent(Main.transform);
			IncreaseBtn.transform.SetParent(Main.transform);
			CancelBtn.transform.SetParent(Main.transform);
			OkBtn.transform.SetParent(Main.transform);
			MinValueText.transform.SetParent(Main.transform);
			MaxValueText.transform.SetParent(Main.transform);
			CurrentValueText.transform.SetParent(Main.transform);
			Slider.transform.SetParent(Main.transform);

			Main.SetActive(false);

			SplitSlider = new SplitSlider(this);
			return this;
		}

		public void Destory()
		{
			Object.DestroyImmediate(Main);
		}
	}
}
