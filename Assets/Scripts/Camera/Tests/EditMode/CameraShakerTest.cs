using NUnit.Framework;
using System.Collections.Generic;
using VEngine;
using VEngine.Camera;
using static VTest.SO.CameraShakeDataTest;

namespace VTest.Camera
{
	public class CameraShakerTest
	{
		[Test]
		public void is_shake_good_with_2_deactivated_timed_shakes()
		{
			var shakes = new List<ICameraShakeDataReference>();
			CameraShakeBuilder.Create().SetDuration(1.0f).SetMaxFrequency(1.0f).SetMaxAmplitude(1.0f).Activate(1.0f).DoReset().AddTo(shakes);
			CameraShakeBuilder.Create().SetDuration(1.0f).SetMaxFrequency(1.0f).SetMaxAmplitude(1.0f).Activate(1.0f).DoReset().AddTo(shakes);
			var cameraShaker = CreateCameraShaker(()=>shakes,
				(x) =>
				{
					Assert.IsNull(x);
				}
			);
			cameraShaker.ShakeFirstActive(0.0f);
		}

		[Test]
		public void is_shake_good_with_1_activated_and_1_deactivated_timed_shake()
		{
			var shakes = new List<ICameraShakeDataReference>();
			CameraShakeBuilder.Create().SetDuration(1.0f).SetMaxFrequency(1.0f).SetMaxAmplitude(1.0f).Activate(1.0f).AddTo(shakes);
			CameraShakeBuilder.Create().SetDuration(1.0f).SetMaxFrequency(1.0f).SetMaxAmplitude(1.0f).Activate(1.0f).DoReset().AddTo(shakes);
			var cameraShaker = CreateCameraShaker(()=>shakes,
				(x) =>
				{
					Assert.IsNotNull(x);
					Assert.AreEqual(0, shakes.IndexOf(x));
					Assert.IsTrue(x.Data.IsActive);
					Assert.AreEqual(1.0f, x.Data.CurrentAmplitude);
					Assert.AreEqual(1.0f, x.Data.CurrentFrequency);
				}
			);
			cameraShaker.ShakeFirstActive(0.0f);
		}

		[Test]
		public void is_shake_good_with_1_deactivated_and_1_activated_timed_shake()
		{
			var shakes = new List<ICameraShakeDataReference>();
			CameraShakeBuilder.Create().SetDuration(1.0f).SetMaxFrequency(2.0f).SetMaxAmplitude(2.0f).Activate(1.0f).DoReset().AddTo(shakes);
			CameraShakeBuilder.Create().SetDuration(1.0f).SetMaxFrequency(1.0f).SetMaxAmplitude(1.0f).Activate(1.0f).AddTo(shakes);
			var cameraShaker = CreateCameraShaker(()=>shakes,
				(x) =>
				{
					Assert.IsNotNull(x);
					Assert.AreEqual(1, shakes.IndexOf(x));
					Assert.IsTrue(x.Data.IsActive);
					Assert.AreEqual(1.0f, x.Data.CurrentAmplitude);
					Assert.AreEqual(1.0f, x.Data.CurrentFrequency);
				}
			);
			cameraShaker.ShakeFirstActive(0.0f);
		}

		[Test]
		public void is_shake_good_with_2_activated_shake()
		{
			var shakes = new List<ICameraShakeDataReference>();
			CameraShakeBuilder.Create().SetDuration(1.0f).SetMaxFrequency(2.0f).SetMaxAmplitude(2.0f).Activate(1.0f).AddTo(shakes);
			CameraShakeBuilder.Create().SetDuration(1.0f).SetMaxFrequency(1.0f).SetMaxAmplitude(1.0f).Activate(1.0f).AddTo(shakes);
			var cameraShaker = CreateCameraShaker(()=>shakes,
				(x) =>
				{
					Assert.IsNotNull(x);
					Assert.AreEqual(0, shakes.IndexOf(x));
					Assert.IsTrue(x.Data.IsActive);
					Assert.AreEqual(2.0f, x.Data.CurrentAmplitude);
					Assert.AreEqual(2.0f, x.Data.CurrentFrequency);
				}
			);
			cameraShaker.ShakeFirstActive(0.0f);
		}

		[Test]
		public void is_shake_good_with_2_activated_shake_but_second_higher()
		{
			var shakes = new List<ICameraShakeDataReference>();
			CameraShakeBuilder.Create().SetDuration(1.0f).SetMaxFrequency(1.0f).SetMaxAmplitude(1.0f).Activate(1.0f).AddTo(shakes);
			CameraShakeBuilder.Create().SetDuration(1.0f).SetMaxFrequency(2.0f).SetMaxAmplitude(2.0f).Activate(1.0f).AddTo(shakes);
			var cameraShaker = CreateCameraShaker(()=>shakes,
				(x) =>
				{
					Assert.IsNotNull(x);
					Assert.AreEqual(0, shakes.IndexOf(x));
					Assert.IsTrue(x.Data.IsActive);
					Assert.AreEqual(1.0f, x.Data.CurrentAmplitude);
					Assert.AreEqual(1.0f, x.Data.CurrentFrequency);
				}
			);
			cameraShaker.ShakeFirstActive(0.0f);
		}

		[Test]
		public void is_shake_good_with_2_activated_shake_but_first_expired()
		{
			var shakes = new List<ICameraShakeDataReference>();
			CameraShakeBuilder.Create().SetDuration(1.0f).SetMaxFrequency(1.0f).SetMaxAmplitude(1.0f).Activate(1.0f).AddTo(shakes);
			CameraShakeBuilder.Create().SetDuration(10.0f).SetMaxFrequency(2.0f).SetMaxAmplitude(2.0f).Activate(1.0f).AddTo(shakes);
			var cameraShaker = CreateCameraShaker(()=>shakes,
				(x) =>
				{
					Assert.IsNotNull(x);
					Assert.AreEqual(1, shakes.IndexOf(x));
					Assert.IsTrue(x.Data.IsActive);
					Assert.AreEqual(2.0f, x.Data.CurrentAmplitude);
					Assert.AreEqual(2.0f, x.Data.CurrentFrequency);
				}
			);
			cameraShaker.ShakeFirstActive(5f);
		}

		[Test]
		public void is_shake_good_with_2_activated_shake_but_first_deactivated()
		{
			var shakes = new List<ICameraShakeDataReference>();
			CameraShakeBuilder.Create().SetDuration(1.0f).SetMaxFrequency(1.0f).SetMaxAmplitude(1.0f).Activate(1.0f).DoReset().AddTo(shakes);
			CameraShakeBuilder.Create().SetDuration(10.0f).SetMaxFrequency(2.0f).SetMaxAmplitude(2.0f).Activate(1.0f).AddTo(shakes);
			var cameraShaker = CreateCameraShaker(()=>shakes,
				(x) =>
				{
					Assert.IsNotNull(x);
					Assert.AreEqual(1, shakes.IndexOf(x));
					Assert.IsTrue(x.Data.IsActive);
					Assert.AreEqual(2.0f, x.Data.CurrentAmplitude);
					Assert.AreEqual(2.0f, x.Data.CurrentFrequency);
				}
			);
			cameraShaker.ShakeFirstActive(5f);
		}

		[Test]
		public void is_shake_good_with_shake_but_first_expired_and_second_deactivated()
		{
			var shakes = new List<ICameraShakeDataReference>();
			CameraShakeBuilder.Create().SetDuration(1.0f).SetMaxFrequency(1.0f).SetMaxAmplitude(1.0f).Activate(1.0f).AddTo(shakes);
			CameraShakeBuilder.Create().SetDuration(10.0f).SetMaxFrequency(2.0f).SetMaxAmplitude(2.0f).Activate(1.0f).DoReset().AddTo(shakes);
			var cameraShaker = CreateCameraShaker(()=>shakes,
				(x) =>
				{
					Assert.IsNull(x);
				}
			);
			cameraShaker.ShakeFirstActive(5f);
		}

		[Test]
		public void is_shake_good_with_shake_but_first_deactivated_and_second_expired()
		{
			var shakes = new List<ICameraShakeDataReference>();
			CameraShakeBuilder.Create().SetDuration(10.0f).SetMaxFrequency(2.0f).SetMaxAmplitude(2.0f).Activate(1.0f).DoReset().AddTo(shakes);
			CameraShakeBuilder.Create().SetDuration(1.0f).SetMaxFrequency(1.0f).SetMaxAmplitude(1.0f).Activate(1.0f).AddTo(shakes);
			var cameraShaker = CreateCameraShaker(()=>shakes,
				(x) =>
				{
					Assert.IsNull(x);
				}
			);
			cameraShaker.ShakeFirstActive(5f);
		}

		[Test]
		public void is_shake_good_with_2_activated_shake_but_first_infinite()
		{
			var shakes = new List<ICameraShakeDataReference>();
			CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1.0f).SetMaxAmplitude(1.0f).Activate(1.0f).AddTo(shakes);
			CameraShakeBuilder.Create().SetDuration(10f).SetMaxFrequency(2.0f).SetMaxAmplitude(2.0f).Activate(1.0f).AddTo(shakes);
			var cameraShaker = CreateCameraShaker(()=>shakes,
				(x) =>
				{
					Assert.IsNotNull(x);
					Assert.AreEqual(0, shakes.IndexOf(x));
					Assert.IsTrue(x.Data.IsActive);
					Assert.AreEqual(1.0f, x.Data.CurrentAmplitude);
					Assert.AreEqual(1.0f, x.Data.CurrentFrequency);
				}
			);
			cameraShaker.ShakeFirstActive(5f);
		}

		[Test]
		public void is_shake_good_with_2_activated_shake_but_first_infinite_and_second_expired()
		{
			var shakes = new List<ICameraShakeDataReference>();
			CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1.0f).SetMaxAmplitude(1.0f).Activate(1.0f).AddTo(shakes);
			CameraShakeBuilder.Create().SetDuration(10f).SetMaxFrequency(2.0f).SetMaxAmplitude(2.0f).Activate(1.0f).AddTo(shakes);
			var cameraShaker = CreateCameraShaker(()=>shakes,
				(x) =>
				{
					Assert.IsNotNull(x);
					Assert.AreEqual(0, shakes.IndexOf(x));
					Assert.IsTrue(x.Data.IsActive);
					Assert.AreEqual(1.0f, x.Data.CurrentAmplitude);
					Assert.AreEqual(1.0f, x.Data.CurrentFrequency);
				}
			);
			cameraShaker.ShakeFirstActive(10f);
		}

		[Test]
		public void is_shake_good_with_2_activated_shake_but_both_expired()
		{
			var shakes = new List<ICameraShakeDataReference>();
			CameraShakeBuilder.Create().SetDuration(10f).SetMaxFrequency(1.0f).SetMaxAmplitude(1.0f).Activate(1.0f).AddTo(shakes);
			CameraShakeBuilder.Create().SetDuration(10f).SetMaxFrequency(2.0f).SetMaxAmplitude(2.0f).Activate(1.0f).AddTo(shakes);
			var cameraShaker = CreateCameraShaker(()=>shakes,
				(x) =>
				{
					Assert.IsNull(x);
				}
			);
			cameraShaker.ShakeFirstActive(10f);
		}

		[Test]
		public void is_shake_good_with_2_activated_shake_but_shaker_reseted()
		{
			var shakes = new List<ICameraShakeDataReference>();
			CameraShakeBuilder.Create().SetDuration(1.0f).SetMaxFrequency(2.0f).SetMaxAmplitude(2.0f).Activate(1.0f).AddTo(shakes);
			CameraShakeBuilder.Create().SetDuration(1.0f).SetMaxFrequency(1.0f).SetMaxAmplitude(1.0f).Activate(1.0f).AddTo(shakes);
			var cameraShaker = CreateCameraShaker(()=>shakes,
				(x) =>
				{
					Assert.IsNull(x);
				}
			);
			cameraShaker.DoResetAll();
			cameraShaker.ShakeFirstActive(0.0f);
		}

		private ICameraShaker CreateCameraShaker(Delegate0<List<ICameraShakeDataReference>> shakes, Delegate1<ICameraShakeDataReference> callbackFromShaker)
		{
			return new CCameraShaker(shakes, callbackFromShaker);
		}
	}
}
