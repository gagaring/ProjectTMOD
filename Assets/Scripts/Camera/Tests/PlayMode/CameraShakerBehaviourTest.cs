using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using VEngine.Camera;
using VEngine.SO.Camera;
using static VTest.SO.CameraShakeDataTest;

namespace VTest
{
    public class CameraShakerBehaviourTest
    {
		[UnityTest]
		public IEnumerator is_shake_good_with_2_deactivated_timed_shakes()
		{
			var builder = CameraShakeBehavoiurBuilder.Create().AddCinemachineWithPerlin().AddShakeToListBuffer(1.0f, 1.0f, 1.0f).AddShakeToListBuffer(2.0f, 2.0f, 2.0f).AcceptList();
			var shaker = builder.GetShaker();
			yield return null;
			builder.DeactivateList();
			yield return null;
			Assert.AreEqual(0.0f, shaker.CurrentAmplitude);
			Assert.AreEqual(0.0f, shaker.CurrentFrequency);
			builder.DeleteShaker();
		}

		[UnityTest]
		public IEnumerator is_shake_good_with_1_activated_and_1_deactivated_timed_shake()
		{
			var builder = CameraShakeBehavoiurBuilder.Create().AddCinemachineWithPerlin().AddShakeToListBuffer(1.0f, 1.0f, 1.0f).AddShakeToListBuffer(2.0f, 2.0f, 2.0f).AcceptList();
			var shaker = builder.GetShaker();
			yield return null;
			builder.Activate(0, 1.0f);
			builder.Deactivate(1);
			yield return null;
			Assert.AreEqual(1.0f, shaker.CurrentAmplitude);
			Assert.AreEqual(1.0f, shaker.CurrentFrequency);
			builder.DeleteShaker();
		}

		[UnityTest]
		public IEnumerator is_shake_good_with_1_deactivated_and_1_activated_timed_shake()
		{
			var builder = CameraShakeBehavoiurBuilder.Create().AddCinemachineWithPerlin().AddShakeToListBuffer(1.0f, 1.0f, 1.0f).AddShakeToListBuffer(2.0f, 2.0f, 2.0f).AcceptList();
			var shaker = builder.GetShaker();
			yield return null;
			builder.Activate(1, 1.0f);
			builder.Deactivate(0);
			yield return null;
			Assert.AreEqual(2.0f, shaker.CurrentAmplitude);
			Assert.AreEqual(2.0f, shaker.CurrentFrequency);
			builder.DeleteShaker();
		}

		[UnityTest]
		public IEnumerator is_shake_good_with_2_activated_shake()
		{
			var builder = CameraShakeBehavoiurBuilder.Create().AddCinemachineWithPerlin().AddShakeToListBuffer(1.0f, 1.0f, 1.0f).AddShakeToListBuffer(1.0f, .5f, .5f).AcceptList();
			var shaker = builder.GetShaker();
			yield return null;
			builder.ActivateList();
			yield return null;
			Assert.AreEqual(1.0f, shaker.CurrentAmplitude);
			Assert.AreEqual(1.0f, shaker.CurrentFrequency);
			builder.DeleteShaker();
		}

		[UnityTest]
		public IEnumerator is_shake_good_with_2_activated_shake_but_second_higher()
		{
			var builder = CameraShakeBehavoiurBuilder.Create().AddCinemachineWithPerlin().AddShakeToListBuffer(1.0f, 1.0f, 1.0f).AddShakeToListBuffer(2.0f, 2.0f, 2.0f).AcceptList();
			var shaker = builder.GetShaker();
			yield return null;
			builder.ActivateList();
			yield return null;
			Assert.AreEqual(1.0f, shaker.CurrentAmplitude);
			Assert.AreEqual(1.0f, shaker.CurrentFrequency);
			builder.DeleteShaker();
		}

		[UnityTest]
		public IEnumerator is_shake_good_with_2_activated_shake_but_first_expired()
		{
			var builder = CameraShakeBehavoiurBuilder.Create().AddCinemachineWithPerlin().AddShakeToListBuffer(.1f, 1.0f, 1.0f).AddShakeToListBuffer(2.0f, 2.0f, 2.0f).AcceptList();
			var shaker = builder.GetShaker();
			yield return null;
			builder.ActivateList();
			yield return new WaitForSeconds(0.1f);
			Assert.AreEqual(2.0f, shaker.CurrentAmplitude);
			Assert.AreEqual(2.0f, shaker.CurrentFrequency);
			builder.DeleteShaker();
		}

		[UnityTest]
		public IEnumerator is_shake_good_with_2_activated_shake_but_first_deactivated()
		{
			var builder = CameraShakeBehavoiurBuilder.Create().AddCinemachineWithPerlin().AddShakeToListBuffer(1.0f, 1.0f, 1.0f).AddShakeToListBuffer(2.0f, 2.0f, 2.0f).AcceptList();
			var shaker = builder.GetShaker();
			yield return null;
			builder.ActivateList();
			builder.Deactivate(0);
			yield return null;
			Assert.AreEqual(2.0f, shaker.CurrentAmplitude);
			Assert.AreEqual(2.0f, shaker.CurrentFrequency);
			builder.DeleteShaker();
		}

		[UnityTest]
		public IEnumerator is_shake_good_with_shake_but_first_expired_and_second_deactivated()
		{
			var builder = CameraShakeBehavoiurBuilder.Create().AddCinemachineWithPerlin().AddShakeToListBuffer(.1f, 1.0f, 1.0f).AddShakeToListBuffer(2.0f, 2.0f, 2.0f).AcceptList();
			var shaker = builder.GetShaker();
			yield return null;
			builder.ActivateList();
			builder.Deactivate(1);
			yield return new WaitForSeconds(0.1f);
			Assert.AreEqual(0.0f, shaker.CurrentAmplitude);
			Assert.AreEqual(0.0f, shaker.CurrentFrequency);
			builder.DeleteShaker();
		}

		[UnityTest]
		public IEnumerator is_shake_good_with_shake_but_first_deactivated_and_second_expired()
		{
			var builder = CameraShakeBehavoiurBuilder.Create().AddCinemachineWithPerlin().AddShakeToListBuffer(1.0f, 1.0f, 1.0f).AddShakeToListBuffer(.1f, 2.0f, 2.0f).AcceptList();
			var shaker = builder.GetShaker();
			yield return null;
			builder.ActivateList();
			builder.Deactivate(0);
			yield return new WaitForSeconds(0.1f);
			Assert.AreEqual(.0f, shaker.CurrentAmplitude);
			Assert.AreEqual(.0f, shaker.CurrentFrequency);
			builder.DeleteShaker();
		}

		[UnityTest]
		public IEnumerator is_shake_good_with_2_activated_shake_but_first_infinite()
		{
			var builder = CameraShakeBehavoiurBuilder.Create().AddCinemachineWithPerlin().AddInfShakeToListBuffer(1.0f, 1.0f).AddShakeToListBuffer(.1f, 2.0f, 2.0f).AcceptList();
			var shaker = builder.GetShaker();
			yield return null;
			builder.ActivateList();
			yield return null;
			Assert.AreEqual(1.0f, shaker.CurrentAmplitude);
			Assert.AreEqual(1.0f, shaker.CurrentFrequency);
			builder.DeleteShaker();
		}

		[UnityTest]
		public IEnumerator is_shake_good_with_2_activated_shake_but_first_infinite_and_second_expired()
		{
			var builder = CameraShakeBehavoiurBuilder.Create().AddCinemachineWithPerlin().AddInfShakeToListBuffer(1.0f, 1.0f).AddShakeToListBuffer(.1f, 2.0f, 2.0f).AcceptList();
			var shaker = builder.GetShaker();
			yield return null;
			builder.ActivateList();
			yield return new WaitForSeconds(0.1f);
			Assert.AreEqual(1.0f, shaker.CurrentAmplitude);
			Assert.AreEqual(1.0f, shaker.CurrentFrequency);
			builder.DeleteShaker();
		}

		[UnityTest]
		public IEnumerator is_shake_good_with_2_activated_shake_but_both_expired()
		{
			var builder = CameraShakeBehavoiurBuilder.Create().AddCinemachineWithPerlin().AddShakeToListBuffer(.1f, 1.0f, 1.0f).AddShakeToListBuffer(.1f, 2.0f, 2.0f).AcceptList();
			var shaker = builder.GetShaker();
			yield return null;
			builder.ActivateList();
			yield return new WaitForSeconds(0.1f);
			Assert.AreEqual(.0f, shaker.CurrentAmplitude);
			Assert.AreEqual(.0f, shaker.CurrentFrequency);
			builder.DeleteShaker();
		}

		[UnityTest]
		public IEnumerator is_shake_good_with_2_activated_shake_but_shaker_reseted()
		{
			var builder = CameraShakeBehavoiurBuilder.Create().AddCinemachineWithPerlin().AddShakeToListBuffer(.1f, 1.0f, 1.0f).AddShakeToListBuffer(.1f, 2.0f, 2.0f).AcceptList();
			var shaker = builder.GetShaker();
			yield return null;
			builder.ActivateList();
			builder.DeactivateList();
			yield return null;
			Assert.AreEqual(.0f, shaker.CurrentAmplitude);
			Assert.AreEqual(.0f, shaker.CurrentFrequency);
			builder.DeleteShaker();
		}
	}

	public class CameraShakeBehavoiurBuilder
	{
        private CCameraShakerBehaviour _shaker;
        private List<CameraShakeData> _list = new List<CameraShakeData>();

        private CameraShakeBehavoiurBuilder()
		{
            _shaker = new GameObject("ShakerBehaviour").AddComponent<CCameraShakerBehaviour>();
        }

        public static CameraShakeBehavoiurBuilder Create()
        {
            return new CameraShakeBehavoiurBuilder();
        }

        public CameraShakeBehavoiurBuilder AddCinemachineWithPerlin()
		{
            _shaker.VirtualCamera = _shaker.gameObject.AddComponent<CinemachineVirtualCamera>();
            _shaker.VirtualCamera.AddCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            return this;
        }

        public CameraShakeBehavoiurBuilder AddShakeToListBuffer(float duration, float maxAmplitude, float maxFrequency)
        {
            var data = CameraShakeBuilder.Create().SetDuration(duration).SetMaxAmplitude(maxAmplitude).SetMaxFrequency(maxFrequency).GetData();
            _list.Add(data);
            return this;
        }

        public CameraShakeBehavoiurBuilder AddInfShakeToListBuffer(float maxAmplitude, float maxFrequency)
        {
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxAmplitude(maxAmplitude).SetMaxFrequency(maxFrequency).GetData();
            _list.Add(data);
            return this;
        }

        public CameraShakeBehavoiurBuilder AcceptList()
        {
            _shaker.ShakeData = _list;
            return this;
        }

        public CameraShakeBehavoiurBuilder ActivateList()
		{
            foreach (var curr in _list)
                curr.Activate(1.0f);
            return this;
		}

        public CameraShakeBehavoiurBuilder Activate(int index, float rate)
		{
            _list[index].Activate(rate);
            return this;
		}

        public CameraShakeBehavoiurBuilder Deactivate(int index)
		{
            _list[index].DoReset();
            return this;
		}

		public CameraShakeBehavoiurBuilder DeactivateList()
		{
			foreach (var curr in _list)
				curr.DoReset();
			return this;
		}

        public CameraShakeBehavoiurBuilder ClearListBuffer()
        {
            _list.Clear();
            return this;
        }

        public CCameraShakerBehaviour GetShaker()
		{
            return _shaker;
        }

		public CameraShakeBehavoiurBuilder DeleteShaker()
		{
			Object.Destroy(_shaker.gameObject);
			return this;
		}
	}
}
