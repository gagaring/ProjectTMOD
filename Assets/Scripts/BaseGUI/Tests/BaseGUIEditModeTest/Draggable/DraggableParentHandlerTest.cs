using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using VEngine.GUI.Draggable;

namespace VTest.GUI.Draggable
{
	public class DraggableParentHandlerTest
	{
		[Test]
		public void is_parent_normal_when_state_stay_on_StandBy()
		{
			var builder = Builder.Create().Init(out var draggableParentHandler, out var parentHandler, out var dragParent, out var normalParent);
			Assert.AreEqual(normalParent, parentHandler.Parent);
			builder.Destory();
		}

		[Test]
		public void is_parent_dragParent_when_state_set_to_OnDrag()
		{
			var builder = Builder.Create().Init(out var draggableParentHandler, out var parentHandler, out var dragParent, out var normalParent);
			Assert.AreEqual(normalParent, parentHandler.Parent);
			draggableParentHandler.SetParent(eState.OnDrag);
			Assert.AreEqual(dragParent, parentHandler.Parent);
			builder.Destory();
		}

		[Test]
		public void is_parent_dragParent_when_state_set_to_StandBy_after_OnDrag()
		{
			var builder = Builder.Create().Init(out var draggableParentHandler, out var parentHandler, out var dragParent, out var normalParent);
			Assert.AreEqual(normalParent, parentHandler.Parent);
			draggableParentHandler.SetParent(eState.OnDrag);
			Assert.AreEqual(dragParent, parentHandler.Parent);
			draggableParentHandler.SetParent(eState.StandBy);
			Assert.AreEqual(normalParent, parentHandler.Parent);
			builder.Destory();
		}


		public class Builder
		{
			private GameObject _dragParent;
			private GameObject _normalParent;

			public static Builder Create()
			{
				return new Builder();
			}

			public void Destory()
			{
				Object.DestroyImmediate(_dragParent);
				Object.DestroyImmediate(_normalParent);
			}

			public Builder Init(out IDraggableParentHandler draggableParentHandler, out IParentHandler parentHandler, out Transform dragParent, out Transform normalParent)
			{
				parentHandler = Substitute.For<IParentHandler>();

				dragParent = new GameObject("DragParent").transform;
				_dragParent = dragParent.gameObject;

				normalParent = new GameObject("NormalParent").transform;
				_normalParent = normalParent.gameObject;

				parentHandler.Parent.Returns(normalParent);

				draggableParentHandler = new DraggableParentHandler(parentHandler, dragParent);
				return this;
			}
		}
	}
}
