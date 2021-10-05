using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using VEngine.GUI.Limiter;

namespace VTest.GUI.Limiter
{
	public class AreaLimiterTest
	{
 		[Test]
		public void position_is_changed_if_position_x_is_less_than_x_min_and_y_is_less_than_y_min()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(949f, 949f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.Received().Position = new Vector2(950f, 950f);
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_less_than_x_min_and_y_is_equal_as_y_min()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(949f, 950f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.Received().Position = new Vector2(950f, 950f);
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_less_than_x_min_and_y_is_good()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(949f, 1000f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.Received().Position = new Vector2(950f, 1000f);
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_less_than_x_min_and_y_is_equal_as_y_max()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(949f, 1050f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.Received().Position = new Vector2(950f, 1050f);
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_less_than_x_min_and_y_is_more_than_y_max()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(949f, 1051f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.Received().Position = new Vector2(950f, 1050f);
			
		}


		[Test]
		public void position_is_changed_if_position_x_is_equal_as_x_min_and_y_is_less_than_y_min()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(950f, 949f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.Received().Position = new Vector2(950f, 950f);
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_equal_as_x_min_and_y_is_equal_as_y_min()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(950f, 950f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.DidNotReceive().Position = Arg.Any<Vector2>();
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_equal_as_x_min_and_y_is_good()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(950f, 1000f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.DidNotReceive().Position = Arg.Any<Vector2>();
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_equal_as_x_min_and_y_is_equal_as_y_max()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(950f, 1050f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.DidNotReceive().Position = Arg.Any<Vector2>();
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_equal_as_x_min_and_y_is_more_than_y_max()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(950f, 1051f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.Received().Position = new Vector2(950f, 1050f);
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_good_and_y_is_less_than_y_min()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(1000f, 949f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.Received().Position = new Vector2(1000f, 950f);
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_good_and_y_is_equal_as_y_min()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(1000f, 950f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.DidNotReceive().Position = Arg.Any<Vector2>();
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_good_and_y_is_good()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(1000f, 1000f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.DidNotReceive().Position = Arg.Any<Vector2>();
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_good_and_y_is_equal_as_y_max()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(1000f, 1050f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.DidNotReceive().Position = Arg.Any<Vector2>();
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_good_and_y_is_more_than_y_max()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(1000f, 1051f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.Received().Position = new Vector2(1000f, 1050f);
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_equal_as_x_max_and_y_is_less_than_y_min()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(1050f, 949f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.Received().Position = new Vector2(1050f, 950f);
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_equal_as_x_max_and_y_is_equal_as_y_min()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(1050f, 950f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.DidNotReceive().Position = Arg.Any<Vector2>();
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_equal_as_x_max_and_y_is_good()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(1050f, 1000f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.DidNotReceive().Position = Arg.Any<Vector2>();
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_equal_as_x_max_and_y_is_equal_as_y_max()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(1050f, 1050f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.DidNotReceive().Position = Arg.Any<Vector2>();
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_equal_as_x_max_and_y_is_more_than_y_max()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(1050f, 1051f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.Received().Position = new Vector2(1050f, 1050f);
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_more_than_x_max_and_y_is_less_than_y_min()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(1051f, 949f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.Received().Position = new Vector2(1050f, 950f);
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_more_than_x_max_and_y_is_equal_as_y_min()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(1051f, 950f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.Received().Position = new Vector2(1050f, 950f);
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_more_than_x_max_and_y_is_good()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(1051f, 1000f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.Received().Position = new Vector2(1050f, 1000f);
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_more_than_x_max_and_y_is_equal_as_y_max()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(1051f, 1050f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.Received().Position = new Vector2(1050f, 1050f);
			
		}

		[Test]
		public void position_is_changed_if_position_x_is_more_than_x_max_and_y_is_more_than_y_max()
		{
			Create(out var areaLimiterTarget, out var limiter, out var limitArea);
			areaLimiterTarget.Position.Returns(new Vector2(1051f, 1051f));
			areaLimiterTarget.ClearReceivedCalls();
			limiter.OnPositionChanged(areaLimiterTarget);
			areaLimiterTarget.Received().Position = new Vector2(1050f, 1050f);
			
		}

		private void Create(out IAreaLimiterTarget target, out IAreaLimiter limiter, out IAreaLimiterArea limitArea)
		{
			target = Substitute.For<IAreaLimiterTarget>();
			limitArea = Substitute.For<IAreaLimiterArea>();
			limitArea.XMin.Returns(950f);
			limitArea.XMax.Returns(1050f);
			limitArea.YMin.Returns(950f);
			limitArea.YMax.Returns(1050f);
			limiter = new AreaLimiter(limitArea);
		}
	}
}
