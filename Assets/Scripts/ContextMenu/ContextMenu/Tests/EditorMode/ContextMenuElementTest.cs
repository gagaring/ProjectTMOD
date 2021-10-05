using NSubstitute;
using NUnit.Framework;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VEngine.SO.Variables;
using VEngine.GUI.Context;
using static VEngine.GUI.Context.ContextMenuElement;

namespace VTest.GUI.Context
{
	class ContextMenuElementTest
	{
		[Test]
		public void show_the_right_text_on_show()
		{
			CreateContextMenuElement(out var element, out var components0);
			element.Show(CreateElementData("Hello"), 1, null);
			Assert.AreEqual("Hello", components0.Text.text);
			Destroy(components0);
		}

		private IContextMenuElementData CreateElementData(string text, bool interactable = true)
		{
			var data = Substitute.For<IContextMenuElementData>();
			data.Text.Returns(text);
			data.Enabled.Returns(interactable);
			return data;
		}

		[Test]
		public void gameobject_is_active_on_show()
		{
			CreateContextMenuElement(out var element, out var components0);
			element.Show(CreateElementData("Hello"), 1, null);
			Assert.IsTrue(components0.Main.activeSelf);
			Destroy(components0);
		}

		[Test]
		public void gameobject_is_active_on_hide()
		{
			CreateContextMenuElement(out var element, out var components0);
			element.Show(CreateElementData("Hello"), 1, null);
			Assert.IsTrue(components0.Main.activeSelf);
			element.Hide();
			Assert.IsFalse(components0.Main.activeSelf);
			Destroy(components0);
		}

		[Test]
		public void callback_is_received_OnPressed()
		{
			IFakeCallback fakeCallback = Substitute.For<IFakeCallback>();

			CreateContextMenuElement(out var element0, out var components0);
			element0.Show(CreateElementData("Hello"), 0, fakeCallback.OnPressed);

			CreateContextMenuElement(out var element1, out var components1);
			element1.Show(CreateElementData("Hello1", false), 1, fakeCallback.OnPressed);

			CreateContextMenuElement(out var element2, out var components2);
			element2.Show(CreateElementData("Hello2"), 2, fakeCallback.OnPressed);

			fakeCallback.ClearReceivedCalls();
			Assert.IsTrue(element0.OnPressed());
			fakeCallback.Received().OnPressed(0);

			fakeCallback.ClearReceivedCalls();
			Assert.IsFalse(element1.OnPressed());
			fakeCallback.DidNotReceive().OnPressed(1);

			fakeCallback.ClearReceivedCalls();
			Assert.IsTrue(element2.OnPressed());
			fakeCallback.Received().OnPressed(2);

			Destroy(components0);
			Destroy(components1);
			Destroy(components2);
		}

		[Test]
		public void callback_is_not_received_on_Hide()
		{
			IFakeCallback fakeCallback = Substitute.For<IFakeCallback>();

			CreateContextMenuElement(out var element0, out var components);
			element0.Show(CreateElementData("Hello"), 0, fakeCallback.OnPressed);

			fakeCallback.ClearReceivedCalls();
			element0.Hide();
			fakeCallback.DidNotReceive().OnPressed(Arg.Any<int>());
			Destroy(components);
		}

		private void Destroy(IComponents components)
		{
			Destroy(components.Main.gameObject);
		}

		private void CreateContextMenuElement(out IContextMenuElement contextMenuElement, out IComponents components)
		{
			var comp = new Components();
			comp.Main = new GameObject("ContextMenuElement");
			comp.Text = new GameObject("Text").AddComponent<TextMeshProUGUI>();
			comp.Text.transform.SetParent(comp.Main.transform);
			comp.Button = comp.Main.AddComponent<Button>();
			components = comp;
			contextMenuElement = new ContextMenuElement(components);
		}

		private void Destroy(GameObject main)
		{
			UnityEngine.Object.DestroyImmediate(main);
		}

		public interface IFakeCallback
		{
			void OnPressed(int index);
		}

		private class Components : IComponents
		{
			public TMP_Text Text { get; set; }
			public GameObject Main { get; set; }
			public Button Button { get; set; }
		}
	}
}
