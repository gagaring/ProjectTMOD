using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using VEngine.Log;

namespace VEngine.AI.Enemy.Teleporter
{
	public class Teleporter_PostProccessing : MonoBehaviour
	{
		[SerializeField] private Volume _volume;
		[SerializeField] private float _maxVignetteIntensity = 0.6f;
		[SerializeField] private float _maxChromaticAberationIntensity = 1.0f;
		[SerializeField] private AnimationCurve _vignetteCurve;

		private Vignette _vignette;
		private ChromaticAberration _chromaticAberration;

		private float _defalutVignetteIntensity = 0.2f;

		private float _diffVigniteIntensity;

		public void Init()
		{
			if (!_volume.profile.TryGet(out _vignette))
				VLog.Log(VLog.eFlag.AI, VLog.eLevel.Error, $"Vignette effect is not found", _volume.gameObject);
			if (!_volume.profile.TryGet(out _chromaticAberration))
				VLog.Log(VLog.eFlag.AI, VLog.eLevel.Error, $"FilmGrain effect is not found", _volume.gameObject);
			StoreDefaults();
		}

		public void DoReset()
		{
			_vignette.intensity.value = _defalutVignetteIntensity;
		}

		private void StoreDefaults()
		{
			_defalutVignetteIntensity = _vignette.intensity.value;
			_diffVigniteIntensity = _maxVignetteIntensity - _defalutVignetteIntensity;
		}

		public void SetDyingRate(float rate)
		{
			_vignette.intensity.value = _vignetteCurve.Evaluate(rate) * _diffVigniteIntensity + _defalutVignetteIntensity;
			_chromaticAberration.intensity.value = Mathf.Lerp(0, _maxChromaticAberationIntensity, rate);
		}
	}
}