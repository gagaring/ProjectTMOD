using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using VEngine.Camera;
using VEngine.SO.Variables;
using Sirenix.OdinInspector;

namespace VTest
{
    public class CameraDataStorerTest
    {
        [UnityTest]
        public IEnumerator is_camera_data_position_zero_if_transform_was_set_to_zero()
        {
            CreateBase(out var dataStorer, out var cameraTransform, out var cameraData);
            yield return SetAndCheckPosition(cameraTransform, cameraData, Vector3.zero);
            RemoveTransform(cameraTransform);
            RemoveStorer(dataStorer);
        }

        [UnityTest]
        public IEnumerator is_camera_data_position_one_if_transform_was_set_to_one()
        {
            CreateBase(out var dataStorer, out var cameraTransform, out var cameraData);
            yield return SetAndCheckPosition(cameraTransform, cameraData, Vector3.one);
            RemoveTransform(cameraTransform);
            RemoveStorer(dataStorer);
        }

        [UnityTest]
        public IEnumerator is_camera_data_position_custom_if_transform_was_set_to_custom()
        {
            CreateBase(out var dataStorer, out var cameraTransform, out var cameraData);
            yield return SetAndCheckPosition(cameraTransform, cameraData, new Vector3(123.3f, 432.45f, -86.34f));
            RemoveTransform(cameraTransform);
            RemoveStorer(dataStorer);
        }

        [UnityTest]
        public IEnumerator is_camera_data_forward_one_if_transform_was_set_to_one()
        {
            CreateBase(out var dataStorer, out var cameraTransform, out var cameraData);
            yield return SetAndCheckForward(cameraTransform, cameraData, Vector3.one);
            RemoveTransform(cameraTransform);
            RemoveStorer(dataStorer);
        }

        [UnityTest]
        public IEnumerator is_camera_data_forward_custom_if_transform_was_set_to_custom()
        {
            CreateBase(out var dataStorer, out var cameraTransform, out var cameraData);
            yield return SetAndCheckForward(cameraTransform, cameraData, new Vector3(123.3f, 432.45f, -86.34f));
            RemoveTransform(cameraTransform);
            RemoveStorer(dataStorer);
        }

        [UnityTest]
        public IEnumerator is_camera_data_rotation_identity_if_transform_was_set_to_identity()
        {
            CreateBase(out var dataStorer, out var cameraTransform, out var cameraData);
            yield return SetAndCheckRotation(cameraTransform, cameraData, Quaternion.identity);
            RemoveTransform(cameraTransform);
            RemoveStorer(dataStorer);
        }

        [UnityTest]
        public IEnumerator is_camera_data_rotation_custom_if_transform_was_set_to_custom()
        {
            CreateBase(out var dataStorer, out var cameraTransform, out var cameraData);
            yield return SetAndCheckRotation(cameraTransform, cameraData, Quaternion.Euler(new Vector3(123.3f, 432.45f, -86.34f)));
            RemoveTransform(cameraTransform);
            RemoveStorer(dataStorer);
        }

        private IEnumerator SetAndCheckPosition(Transform cameraTransform, CameraDataVariable cameraData, Vector3 position)
        {
            cameraTransform.position = position;
            yield return null;
            Assert.AreEqual(cameraTransform.position, cameraData.Position);
        }

        private IEnumerator SetAndCheckRotation(Transform cameraTransform, CameraDataVariable cameraData, Quaternion rotation)
        {
            cameraTransform.rotation = rotation;
            yield return null;
            Assert.AreEqual(cameraTransform.rotation, cameraData.Rotation);
        }

        private IEnumerator SetAndCheckForward(Transform cameraTransform, CameraDataVariable cameraData, Vector3 forward)
        {
            cameraTransform.forward = forward;
            yield return null;
            Assert.AreEqual(cameraTransform.forward, cameraData.Forward);
        }

        private void CreateBase(out CCameraDataStorer cameraDataStorer, out Transform cameraTransform, out CameraDataVariable data)
		{
            cameraDataStorer = (new GameObject("CameraDataStorer")).AddComponent<CCameraDataStorer>();
            cameraTransform = new GameObject("CameraTransform").transform;
            data = SerializedScriptableObject.CreateInstance<CameraDataVariable>();
            cameraDataStorer.Camera = cameraTransform;
            cameraDataStorer.Data = data;
        }

        private void RemoveTransform(Transform transform)
        {
            Object.Destroy(transform.gameObject);
        }

        private void RemoveStorer(CCameraDataStorer storer)
        {
            Object.Destroy(storer.gameObject);
        }
    }
}