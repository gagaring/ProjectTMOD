using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using VEngine.Camera;
using VEngine.SO.Camera;

namespace VTest.SO
{
    public class CameraShakeDataTest
    {
        [Test]
        public void check_is_shake_data_with_1_duration_and_1_max_frequency_and_1_max_amplitude_and_0_rate()
		{
            var rate = 0.0f;
            var data = CameraShakeBuilder.Create().SetDuration(1).SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsFalse(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_1_duration_and_1_max_frequency_and_1_max_amplitude_and_half_rate()
        {
            var rate = 0.5f;
            var data = CameraShakeBuilder.Create().SetDuration(1).SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_1_duration_and_1_max_frequency_and_1_max_amplitude_and_1_rate()
        {
            var rate = 1.0f;
            var data = CameraShakeBuilder.Create().SetDuration(1).SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_1_duration_and_1_max_frequency_and_1_max_amplitude_and_2_rate()
        {
            var rate = 2.0f;
            var data = CameraShakeBuilder.Create().SetDuration(1).SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            Assert.AreEqual(1.0f, data.CurrentAmplitude);
            Assert.AreEqual(1.0f, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_1_duration_and_1_max_frequency_and_1_max_amplitude_and_0_rate_after_half_sec()
        {
            var rate = 0.0f;
            var delay = 0.5f;
            var data = CameraShakeBuilder.Create().SetDuration(1).SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsFalse(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_1_duration_and_1_max_frequency_and_1_max_amplitude_and_half_rate_after_half_sec()
        {
            var rate = 0.5f;
            var delay = 0.5f;
            var data = CameraShakeBuilder.Create().SetDuration(1).SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_1_duration_and_1_max_frequency_and_1_max_amplitude_and_1_rate_after_half_sec()
        {
            var rate = 1f;
            var delay = 0.5f;
            var data = CameraShakeBuilder.Create().SetDuration(1).SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_1_duration_and_1_max_frequency_and_1_max_amplitude_and_2_rate_after_half_sec()
        {
            var rate = 2f;
            var delay = 0.5f;
            var data = CameraShakeBuilder.Create().SetDuration(1).SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(1f, data.CurrentAmplitude);
            Assert.AreEqual(1f, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_1_duration_and_1_max_frequency_and_1_max_amplitude_and_0_rate_after_1_sec()
        {
            var rate = 0.0f;
            var delay = 1f;
            var data = CameraShakeBuilder.Create().SetDuration(1).SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsFalse(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_1_duration_and_1_max_frequency_and_1_max_amplitude_and_half_rate_after_1_sec()
        {
            var rate = 0.5f;
            var delay = 1f;
            var data = CameraShakeBuilder.Create().SetDuration(1).SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsFalse(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_1_duration_and_1_max_frequency_and_1_max_amplitude_and_1_rate_after_1_sec()
        {
            var rate = 1f;
            var delay = 1f;
            var data = CameraShakeBuilder.Create().SetDuration(1).SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsFalse(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_1_duration_and_1_max_frequency_and_1_max_amplitude_and_2_rate_after_1_sec()
        {
            var rate = 2f;
            var delay = 1f;
            var data = CameraShakeBuilder.Create().SetDuration(1).SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(1f, data.CurrentAmplitude);
            Assert.AreEqual(1f, data.CurrentFrequency);
            Assert.IsFalse(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_1_duration_and_1_max_frequency_and_1_max_amplitude_and_0_rate_after_10_sec()
        {
            var rate = 0f;
            var delay = 10f;
            var data = CameraShakeBuilder.Create().SetDuration(1).SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(0f, data.CurrentAmplitude);
            Assert.AreEqual(0f, data.CurrentFrequency);
            Assert.IsFalse(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_1_duration_and_1_max_frequency_and_1_max_amplitude_and_half_rate_after_10_sec()
        {
            var rate = 0.5f;
            var delay = 10f;
            var data = CameraShakeBuilder.Create().SetDuration(1).SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsFalse(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_1_duration_and_1_max_frequency_and_1_max_amplitude_and_1_rate_after_10_sec()
        {
            var rate = 1f;
            var delay = 10f;
            var data = CameraShakeBuilder.Create().SetDuration(1).SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsFalse(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_1_duration_and_1_max_frequency_and_1_max_amplitude_and_2_rate_after_10_sec()
        {
            var rate = 2f;
            var delay = 10f;
            var data = CameraShakeBuilder.Create().SetDuration(1).SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(1f, data.CurrentAmplitude);
            Assert.AreEqual(1f, data.CurrentFrequency);
            Assert.IsFalse(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_0_rate()
        {
            var rate = 0f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsFalse(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_half_rate()
        {
            var rate = 0.5f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_1_rate()
        {
            var rate = 1.0f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_2_rate()
        {
            var rate = 2.0f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            Assert.AreEqual(1.0f, data.CurrentAmplitude);
            Assert.AreEqual(1.0f, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_0_rate_after_half_sec()
        {
            var rate = 0f;
            var delay = 0.5f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsFalse(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_half_rate_after_half_sec()
        {
            var rate = 0.5f;
            var delay = 0.5f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_1_rate_after_half_sec()
        {
            var rate = 1f;
            var delay = 0.5f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_2_rate_after_half_sec()
        {
            var rate = 2f;
            var delay = 0.5f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(1.0f, data.CurrentAmplitude);
            Assert.AreEqual(1.0f, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_0_rate_after_1_sec()
        {
            var rate = 0f;
            var delay = 1f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsFalse(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_half_rate_after_1_sec()
        {
            var rate = 0.5f;
            var delay = 1f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_1_rate_after_1_sec()
        {
            var rate = 1f;
            var delay = 1f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_2_rate_after_1_sec()
        {
            var rate = 2f;
            var delay = 1f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(1f, data.CurrentAmplitude);
            Assert.AreEqual(1f, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_0_rate_after_10_sec()
        {
            var rate = 0f;
            var delay = 10f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsFalse(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_half_rate_after_10_sec()
        {
            var rate = .5f;
            var delay = 10f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_1_rate_after_10_sec()
        {
            var rate = 1f;
            var delay = 10f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(rate, data.CurrentAmplitude);
            Assert.AreEqual(rate, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_2_rate_after_10_sec()
        {
            var rate = 2f;
            var delay = 10f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).GetIData();
            data.DoUpdate(delay);
            Assert.AreEqual(1f, data.CurrentAmplitude);
            Assert.AreEqual(1f, data.CurrentFrequency);
            Assert.IsTrue(data.IsActive);
        }

        [Test]
        public void check_is_shake_data_with_infinite_duration_and_1_max_frequency_and_1_max_amplitude_and_2_rate_after_deactivated()
        {
            var rate = 2f;
            var data = CameraShakeBuilder.Create().SetInfinite().SetMaxFrequency(1).SetMaxAmplitude(1.0f).Activate(rate).DoReset().GetIData();
            Assert.AreEqual(0f, data.CurrentAmplitude);
            Assert.AreEqual(0f, data.CurrentFrequency);
            Assert.IsFalse(data.IsActive);
        }

        public class CameraShakeBuilder
        {
            private CameraShakeData _data;

            public static CameraShakeBuilder Create()
            {
                return new CameraShakeBuilder();
            }

            private CameraShakeBuilder()
            {
                _data = ScriptableObject.CreateInstance<CameraShakeData>();
            }

            public CameraShakeBuilder SetDuration(float duration)
            {
                _data.Duration = duration;
                return this;
            }

            public CameraShakeBuilder SetInfinite()
			{
                _data.Infinite = true;
                return this;
			}

            public CameraShakeBuilder SetMaxAmplitude(float amplitude)
            {
                _data.MaxAmplitude = amplitude;
                return this;
            }

            public CameraShakeBuilder SetMaxFrequency(float frequency)
            {
                _data.MaxFrequency = frequency;
                return this;
            }

            public CameraShakeBuilder Activate(float rate)
            {
                _data.Activate(rate);
                return this;
            }

            public CameraShakeBuilder DoReset()
            {
                _data.DoReset();
                return this;
            }

            public List<ICameraShakeDataReference> AddTo(List<ICameraShakeDataReference> list)
            {
                list.Add(GetRef());
                return list;
            }

            public ICameraShakeDataReference GetRef()
            {
                return new CameraShakeDataReference(_data);
            }

            public ICameraShakeData GetIData()
            {
                return _data;
            }

            public CameraShakeData GetData()
            {
                return _data;
            }
        }
    }
}
