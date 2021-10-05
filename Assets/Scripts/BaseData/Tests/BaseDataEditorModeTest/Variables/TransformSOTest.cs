using NSubstitute;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using VEngine.SO.Events;
using VEngine.SO.Variables;

namespace VTest
{
	public class TransformSOTest
	{
		#region set position to
		[Test]
		public void transformSO_set_position_to_vector3_one()
		{
			CheckPositionSetTo(Vector3.one);
		}

		[Test]
		public void transformSO_set_position_to_vector3_zero()
		{
			CheckPositionSetTo(Vector3.zero);
		}

		[Test]
		public void transformSO_set_position_to_vector3_custom()
		{
			CheckPositionSetTo(new Vector3(1, 2, 3));
		}

		private void CheckPositionSetTo(Vector3 vector)
		{
			CreateTransformSO(out var transformSO, out var transform, out var onPosition, out var onRotation);
			transformSO.Position = vector;
			
			onPosition.Received();
			onRotation.DidNotReceive();
			Assert.AreEqual(transformSO.Position, vector);
			RemoveTransform(transform);
		}
		#endregion

		#region set rotation to
		[Test]
		public void transformSO_set_rotation_to_quaternion_identity()
		{
			CheckRotationSetTo(Quaternion.identity);
		}

		[Test]
		public void transformSO_set_rotation_to_quaternion_custom_1()
		{
			CheckRotationSetTo(Quaternion.Euler(new Vector3(1, 2, 3)));
		}

		[Test]
		public void transformSO_set_rotation_to_quaternion_custom_2()
		{
			CheckRotationSetTo(Quaternion.Euler(new Vector3(-90, 256, 23)));
		}

		private void CheckRotationSetTo(Quaternion rotation)
		{
			CreateTransformSO(out var transformSO, out var transform, out var onPosition, out var onRotation);
			transformSO.Rotation = rotation;
			var other = new GameObject().transform;
			other.rotation = rotation;
			
			onPosition.DidNotReceive();
			onRotation.Received();
			Assert.AreEqual(transformSO.Rotation, rotation);
			Assert.AreEqual(transformSO.Forward, other.forward);
			Assert.AreEqual(transformSO.Up, other.up);
			RemoveTransform(other);
			RemoveTransform(transform);
		}
		#endregion

		#region lookAt
		[Test]
		public void transformSO_set_look_at_to_forward()
		{
			CheckLookAtTo(Vector3.forward);
		}

		[Test]
		public void transformSO_set_look_at_to_up()
		{
			CheckLookAtTo(Vector3.up);
		}

		[Test]
		public void transformSO_set_look_at_to_custom()
		{
			CheckLookAtTo(new Vector3(123, -123, 633));
		}

		private void CheckLookAtTo(Vector3 lookAt)
		{
			CreateTransformSO(out var transformSO, out var transform, out var onPosition, out var onRotation);
			transformSO.LookAt(lookAt);
			var other = new GameObject().transform;
			other.position = transformSO.Position;
			other.LookAt(lookAt);
			onPosition.DidNotReceive();
			onRotation.Received();
			Assert.AreEqual(transformSO.Rotation, other.rotation);
			Assert.AreEqual(transformSO.Forward, other.forward);
			Assert.AreEqual(transformSO.Up, other.up);
			RemoveTransform(other);
			RemoveTransform(transform);
		}
		#endregion

		#region rotate
		[Test]
		public void transformSO_rotate_90()
		{
			CheckRotate(90);
		}

		[Test]
		public void transformSO_rotate_minus_90()
		{
			CheckRotate(-90);
		}

		[Test]
		public void transformSO_rotate_432()
		{
			CheckRotate(432);
		}

		private void CheckRotate(float angle)
		{
			CreateTransformSO(out var transformSO, out var transform, out var onPosition, out var onRotation);
			var other = new GameObject().transform;
			other.forward = transformSO.Forward;
			transformSO.Rotate(transformSO.Up, angle);
			other.Rotate(transformSO.Up, angle);
			
			onPosition.DidNotReceive();
			onRotation.Received();
			Assert.AreEqual(transformSO.Rotation, other.rotation);
			Assert.AreEqual(transformSO.Forward, other.forward);
			Assert.AreEqual(transformSO.Up, other.up);
			RemoveTransform(other);
			RemoveTransform(transform);
		}
		#endregion

		private void CreateTransformSO(out TransformSO transformSO, out Transform transform, out IGameEventListener onPosition, out IGameEventListener onRotation)
		{
			transformSO = ScriptableObject.CreateInstance<TransformSO>();
			transform = new GameObject().transform;
			transformSO.AssignTransform(transform);

			CreateGameEventWithListener(out var gameEventOnPositionOverrided, out onPosition);
			transformSO.OnPositionOverrided = gameEventOnPositionOverrided;

			CreateGameEventWithListener(out var gameEventOnRotationOverrided, out onRotation);
			transformSO.OnRotationOverrided = gameEventOnRotationOverrided;
		}

		private void CreateGameEventWithListener(out GameEvent gameEvent, out IGameEventListener listener)
		{
			gameEvent = ScriptableObject.CreateInstance<GameEvent>();
			listener = Substitute.For<IGameEventListener>();
			gameEvent.RegisterListener(listener);
		}

		private void RemoveTransform(Transform transform)
		{
			Object.DestroyImmediate(transform.gameObject);
		}
	}
}
