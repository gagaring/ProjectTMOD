using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Camera;

namespace VEngine.Camera
{
	public class CCameraShakerBehaviour : MonoBehaviour, ICameraShakerBehaviour
	{
		[SerializeField] private CinemachineVirtualCamera _virtualCamera;
		[SerializeField] private List<CameraShakeData> _shakeData;

		private CinemachineBasicMultiChannelPerlin _perlin;

		public ICameraShaker CameraShaker { get; private set; }
		public float CurrentAmplitude { get => _perlin.m_AmplitudeGain; }
		public float CurrentFrequency { get => _perlin.m_FrequencyGain; }

		public List<ICameraShakeDataReference> ShakeDataReferencePriorityList
		{
			get
			{
				//TODO ha sokszor hivjuk ezt, akkor be lehetne hashelni
				var shakeDataReferences = new List<ICameraShakeDataReference>();
				foreach (var curr in _shakeData)
					shakeDataReferences.Add(new CameraShakeDataReference(curr));
				return shakeDataReferences;
			}
		}

		public List<CameraShakeData> ShakeData
		{
			set
			{
				_shakeData = new List<CameraShakeData>();
				_shakeData.AddRange(value);
			}
		}

		public CinemachineVirtualCamera VirtualCamera { get => _virtualCamera; set => _virtualCamera = value; }
		
		public void Start()
		{
			_perlin = VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
			CameraShaker = new CCameraShaker(() => ShakeDataReferencePriorityList, 
				(x) => {
					if(x == null)
					{
						_perlin.m_AmplitudeGain = 0.0f;
						_perlin.m_FrequencyGain = 0.0f;
					}
					else
					{
						_perlin.m_AmplitudeGain = x.Data.CurrentAmplitude;
						_perlin.m_FrequencyGain = x.Data.CurrentFrequency;
					}
				} );
			DoResetAll();
		}

		public void DoResetAll()
		{
			CameraShaker.DoResetAll();
		}

		public void Update()
		{
			CameraShaker.ShakeFirstActive(Time.deltaTime);
		}
	}

	public class CCameraShaker : ICameraShaker
	{
		public float HighestIntesity { get; private set; } = 0.0f;

		private Delegate1<ICameraShakeDataReference> _shaker;
		private Delegate0<List<ICameraShakeDataReference>> _shakeData;

		public CCameraShaker(Delegate0<List<ICameraShakeDataReference>> shakeData, Delegate1<ICameraShakeDataReference> shaker)
		{
			_shakeData = shakeData;
			_shaker = shaker;
		}

		public void DoResetAll()
		{
			foreach (var curr in _shakeData())
				curr.Data.DoReset();
		}

		public void ShakeFirstActive(float deltaTime)
		{
			UpdateAll(deltaTime);
			GetFirstActive(out var dataReference);
			_shaker(dataReference);
		}

		private void UpdateAll(float deltaTime)
		{
			foreach (var curr in _shakeData())
				curr.Data.DoUpdate(deltaTime);
		}

		private void GetFirstActive(out ICameraShakeDataReference dataRefenrece)
		{
			foreach (var curr in _shakeData())
			{
				if (!curr.Data.IsActive)
					continue;

				dataRefenrece = curr;
				return;
			}
			dataRefenrece = null;
		}
	}
}
