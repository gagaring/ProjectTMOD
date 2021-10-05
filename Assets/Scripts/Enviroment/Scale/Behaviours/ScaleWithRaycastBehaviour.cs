using System;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Enviroment.Scale
{
	public class ScaleWithRaycastBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		private ScaleWithRaycast _scaleWithRaycast;

		protected void Awake()
		{
			_scaleWithRaycast = new ScaleWithRaycast(_data, _components);
		}

		protected void Update()
		{
			_scaleWithRaycast.Update();
		}

		[Serializable]
		public class Data : ScaleWithRaycast.IData
		{
			[SerializeField] private FloatReference _range;
			[SerializeField] private LayerMaskReference _layerMask;

			public float Range => _range.Value;
			public int LayerMask => _layerMask.Value;
		}

		[Serializable]
		public class Components : ScaleWithRaycast.IComponents
		{
			[SerializeField] private Transform _from;
			[SerializeField] private Transform _target;
			[SerializeField] private float _scaleMultiplier = .1f;

			public Vector3 From => _from.position;
			public Vector3 Dir => _from.forward;

			public float Scale
			{
				set
				{
					var scale = _target.localScale;
					scale.z = value * _scaleMultiplier;
					_target.localScale = scale;
				}
			}
		}
	}
}
