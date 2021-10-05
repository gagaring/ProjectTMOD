using NUnit.Framework;
using UnityEngine;
using VEngine.SO.Variables;

namespace VTest
{
    public class CameraDataVariableTest
    {
        #region position
        [Test]
        public void test_position_camera_data_with_zero_position_and_identity_rotation()
        {
            CreateBase(out var cameraData, out var transform, Vector3.zero, Quaternion.identity);
            ValidatePosition(cameraData, transform);
            RemoveTransform(transform);
        }

        [Test]
        public void test_position_camera_data_with_one_position_and_identity_rotation()
        {
            CreateBase(out var cameraData, out var transform, Vector3.one, Quaternion.identity);
            ValidatePosition(cameraData, transform);
            RemoveTransform(transform);
        }

        [Test]
        public void test_position_camera_data_with_custom_position_and_identity_rotation()
        {
            CreateBase(out var cameraData, out var transform, new Vector3(-90, 90, 156), Quaternion.identity);
            ValidatePosition(cameraData, transform);
            RemoveTransform(transform);
        }

        [Test]
        public void test_position_camera_data_with_zero_position_and_custom_rotation()
        {
            CreateBase(out var cameraData, out var transform, Vector3.zero, Quaternion.Euler(new Vector3(-90, -234, 235)));
            ValidatePosition(cameraData, transform);
            RemoveTransform(transform);
        }

        [Test]
        public void test_position_camera_data_with_one_position_and_custom_rotation()
        {
            CreateBase(out var cameraData, out var transform, Vector3.one, Quaternion.Euler(new Vector3(-90, -234, 235)));
            ValidatePosition(cameraData, transform);
            RemoveTransform(transform);
        }

        [Test]
        public void test_position_camera_data_with_custom_position_and_custom_rotation()
        {
            CreateBase(out var cameraData, out var transform, new Vector3(-90, 90, 156), Quaternion.Euler(new Vector3(-90, -234, 235)));
            ValidatePosition(cameraData, transform);
            RemoveTransform(transform);
        }
        #endregion

        #region rotation
        [Test]
        public void test_rotation_camera_data_with_zero_position_and_identity_rotation()
        {
            CreateBase(out var cameraData, out var transform, Vector3.zero, Quaternion.identity);
            ValidateRotation(cameraData, transform);
            RemoveTransform(transform);
        }

        [Test]
        public void test_rotation_camera_data_with_one_position_and_identity_rotation()
        {
            CreateBase(out var cameraData, out var transform, Vector3.one, Quaternion.identity);
            ValidateRotation(cameraData, transform);
            RemoveTransform(transform);
        }

        [Test]
        public void test_rotation_camera_data_with_custom_position_and_identity_rotation()
        {
            CreateBase(out var cameraData, out var transform, new Vector3(-90, 90, 156), Quaternion.identity);
            ValidateRotation(cameraData, transform);
            RemoveTransform(transform);
        }

        [Test]
        public void test_rotation_camera_data_with_zero_position_and_custom_rotation()
        {
            CreateBase(out var cameraData, out var transform, Vector3.zero, Quaternion.Euler(new Vector3(-90, -234, 235)));
            ValidateRotation(cameraData, transform);
            RemoveTransform(transform);
        }

        [Test]
        public void test_rotation_camera_data_with_one_position_and_custom_rotation()
        {
            CreateBase(out var cameraData, out var transform, Vector3.one, Quaternion.Euler(new Vector3(-90, -234, 235)));
            ValidateRotation(cameraData, transform);
            RemoveTransform(transform);
        }

        [Test]
        public void test_rotation_camera_data_with_custom_position_and_custom_rotation()
        {
            CreateBase(out var cameraData, out var transform, new Vector3(-90, 90, 156), Quaternion.Euler(new Vector3(-90, -234, 235)));
            ValidateRotation(cameraData, transform);
            RemoveTransform(transform);
        }
        #endregion


        #region forward
        [Test]
        public void test_forward_camera_data_with_zero_position_and_identity_rotation()
        {
            CreateBase(out var cameraData, out var transform, Vector3.zero, Quaternion.identity);
            ValidateForward(cameraData, transform);
            RemoveTransform(transform);
        }

        [Test]
        public void test_forward_camera_data_with_one_position_and_identity_rotation()
        {
            CreateBase(out var cameraData, out var transform, Vector3.one, Quaternion.identity);
            ValidateForward(cameraData, transform);
            RemoveTransform(transform);
        }

        [Test]
        public void test_forward_camera_data_with_custom_position_and_identity_rotation()
        {
            CreateBase(out var cameraData, out var transform, new Vector3(-90, 90, 156), Quaternion.identity);
            ValidateForward(cameraData, transform);
            RemoveTransform(transform);
        }

        [Test]
        public void test_forward_camera_data_with_zero_position_and_custom_rotation()
        {
            CreateBase(out var cameraData, out var transform, Vector3.zero, Quaternion.Euler(new Vector3(-90, -234, 235)));
            ValidateForward(cameraData, transform);
            RemoveTransform(transform);
        }

        [Test]
        public void test_forward_camera_data_with_one_position_and_custom_rotation()
        {
            CreateBase(out var cameraData, out var transform, Vector3.one, Quaternion.Euler(new Vector3(-90, -234, 235)));
            ValidateForward(cameraData, transform);
            RemoveTransform(transform);
        }

        [Test]
        public void test_forward_camera_data_with_custom_position_and_custom_rotation()
        {
            CreateBase(out var cameraData, out var transform, new Vector3(-90, 90, 156), Quaternion.Euler(new Vector3(-90, -234, 235)));
            ValidateForward(cameraData, transform);
            RemoveTransform(transform);
        }
        #endregion

        private void CreateBase(out CameraDataVariable cameraData, out Transform transform, Vector3 position, Quaternion rotation)
        {
            cameraData = ScriptableObject.CreateInstance<CameraDataVariable>();
            SetTransform(out transform, position, rotation);
            cameraData.AssignTransform(transform);
        }

		private void ValidatePosition(CameraDataVariable cameraData, Transform transform)
        {
            Assert.AreEqual(cameraData.Position, transform.position);
        }

        private void ValidateRotation(CameraDataVariable cameraData, Transform transform)
        {
            Assert.AreEqual(cameraData.Rotation, transform.rotation);
        }

        private void ValidateForward(CameraDataVariable cameraData, Transform transform)
        {
            Assert.AreEqual(cameraData.Forward, transform.forward);
        }

		private void SetTransform(out Transform transform, Vector3 position, Quaternion rotation)
		{
            transform = new GameObject().transform;
            transform.position = position;
            transform.rotation = rotation;
		}

        private void RemoveTransform(Transform transform)
        {
            Object.DestroyImmediate(transform.gameObject);
        }
    }
}
