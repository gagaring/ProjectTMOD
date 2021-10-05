using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Variables;
using VEngine.GUI.Context;
using VEngine;

namespace VTest.GUI.Context
{
	class ContextMenuTest
	{
		private List<GameObject> gos = new List<GameObject>();

		[Test]
		public void createElements_function_is_called_if_element_count_is_less_than_open_count()
		{
			CreateMenu(out var contextMenu, out var main, out var elementParent, out var elements, 3, out var fakeCreate, out var isContextMenuEnabledRef, true);
			fakeCreate.ClearReceivedCalls();
			//fakeCreate.Create(2).Returns(CreateFakeMenuElements(2));
			contextMenu.Open(Vector2.zero, CreateStrings(5, ""), fakeCreate.Cancel, fakeCreate.Ok);
			fakeCreate.Received().Create(2);

			fakeCreate.ClearReceivedCalls();
			//fakeCreate.Create(1).Returns(CreateFakeMenuElements(1));
			contextMenu.Open(Vector2.zero, CreateStrings(6, ""), fakeCreate.Cancel, fakeCreate.Ok);
			fakeCreate.Received().Create(3);

			fakeCreate.ClearReceivedCalls();
			//fakeCreate.Create(3).Returns(CreateFakeMenuElements(3));
			contextMenu.Open(Vector2.zero, CreateStrings(9, ""), fakeCreate.Cancel, fakeCreate.Ok);
			fakeCreate.Received().Create(6);
			Destroy();
		}

		[Test]
		public void createElements_function_is_not_called_if_element_count_is_equal_as_open_count()
		{
			CreateMenu(out var contextMenu, out var main, out var elementParent, out var elements, 3, out var fakeCreate, out var isContextMenuEnabledRef, true);
			fakeCreate.ClearReceivedCalls();
			//fakeCreate.Create(2).Returns(CreateFakeMenuElements(2));
			contextMenu.Open(Vector2.zero, CreateStrings(3, ""), fakeCreate.Cancel, fakeCreate.Ok);
			fakeCreate.DidNotReceive().Create(Arg.Any<int>());
			Destroy();
		}

		[Test]
		public void createElements_function_is_not_called_if_element_count_is_more_than_open_count()
		{
			CreateMenu(out var contextMenu, out var main, out var elementParent, out var elements, 3, out var fakeCreate, out var isContextMenuEnabledRef, true);
			fakeCreate.ClearReceivedCalls();
			//fakeCreate.Create(2).Returns(CreateFakeMenuElements(2));
			contextMenu.Open(Vector2.zero, CreateStrings(2, ""), fakeCreate.Cancel, fakeCreate.Ok);
			fakeCreate.DidNotReceive().Create(Arg.Any<int>());
			Destroy();
		}

		[Test]
		public void elements_show_function_is_called_with_right_params_on_open()
		{
			int count = 3;
			CreateMenu(out var contextMenu, out var main, out var elementParent, out var elements, count, out var fakeCreate, out var isContextMenuEnabledRef, true);
			fakeCreate.ClearReceivedCalls();
			for (int i = 0; i < count; ++i)
			{
				elements[i].ClearReceivedCalls();
			}
			var data = CreateStrings(count, "element_");
			contextMenu.Open(Vector2.zero, data, fakeCreate.Cancel, fakeCreate.Ok);
			for (int i = 0; i < count; ++i)
			{
				elements[i].Received().Show(data[i], i, fakeCreate.Ok);
			}
			Destroy();
		}

		[Test]
		public void main_gameobject_is_active_on_open()
		{
			int count = 3;
			CreateMenu(out var contextMenu, out var main, out var elementParent, out var elements, count, out var fakeCreate, out var isContextMenuEnabledRef, true);
			contextMenu.Open(Vector2.zero, CreateStrings(count, "element_"), fakeCreate.Cancel, fakeCreate.Ok);
			Assert.IsTrue(main.activeSelf);
			Destroy();
		}

		[Test]
		public void main_gameobject_is_active_on_close()
		{
			int count = 3;
			CreateMenu(out var contextMenu, out var main, out var elementParent, out var elements, count, out var fakeCreate, out var isContextMenuEnabledRef, true);
			contextMenu.Open(Vector2.zero, CreateStrings(count, "element_"), fakeCreate.Cancel, fakeCreate.Ok);
			Assert.IsTrue(main.activeSelf);
			contextMenu.Close();
			Assert.IsFalse(main.activeSelf);
			Destroy();
		}

		[Test]
		public void elementParent_follow_the_show_position()
		{
			int count = 3;
			var pos = new Vector2(1234.3f, 543.2f);
			CreateMenu(out var contextMenu, out var main, out var elementParent, out var elements, count, out var fakeCreate, out var isContextMenuEnabledRef, true);
			contextMenu.Open(pos, CreateStrings(count, "element_"), fakeCreate.Cancel, fakeCreate.Ok);
			Assert.AreEqual(new Vector3(pos.x, pos.y, 0), elementParent.position);
			contextMenu.Close();
			Destroy();
		}

		private void CreateMenu(out IContextMenu contextMenu, out GameObject main, out RectTransform elementParent, out List<IContextMenuElement> elements, int elementCount, out IFakeCreateMenuElement fakeCreate, out BoolReference isContextMenuEnabledRef, bool isContextMenuEnabled = true)
		{
			elements = new List<IContextMenuElement>();
			for (int i = 0; i < elementCount; ++i)
				elements.Add(CreateFakeMenuElement());

			main = new GameObject("ContextMenu");
			elementParent = new GameObject("ElementParent").AddComponent<RectTransform>();
			gos.Add(main);
			gos.Add(elementParent.gameObject);
			fakeCreate = Substitute.For<IFakeCreateMenuElement>();
			isContextMenuEnabledRef = new BoolReference();
			isContextMenuEnabledRef.Init(isContextMenuEnabled);

			var data = Substitute.For<VEngine.GUI.Context.ContextMenu.IData>();
			var components = Substitute.For<VEngine.GUI.Context.ContextMenu.IComponents>();

			data.AddToElelements.Returns(fakeCreate.Create);
			data.IsContextMenuEnabled.Returns(isContextMenuEnabledRef.Value);

			components.Elements.Returns(elements);
			components.Main.Returns(main);
			components.ElementParent.Returns(elementParent);

			contextMenu = new VEngine.GUI.Context.ContextMenu(data, components);
		}

		private List<IContextMenuElement> CreateFakeMenuElements(int count)
		{
			var elements = new List<IContextMenuElement>();
			for (int i = 0; i < count; ++i)
				elements.Add(CreateFakeMenuElement());
			return elements;
		}
		
		private List<IContextMenuElementData> CreateStrings(int count, string pretag)
		{
			List<IContextMenuElementData> list = new List<IContextMenuElementData>();
			for(int i = 0; i < count; ++i)
			{
				var data = Substitute.For<IContextMenuElementData>();
				data.Text.Returns(pretag + "" + i);
				list.Add(data);
			}
			return list;
		}

		private void Destroy()
		{
			foreach (var curr in gos)
				Object.DestroyImmediate(curr);
		}

		private IContextMenuElement CreateFakeMenuElement()
		{
			return Substitute.For<IContextMenuElement>();
		}

		public interface IFakeCreateMenuElement
		{
			void Create(int count);
			void Cancel();
			void Ok(int index);
		}
	}
}
