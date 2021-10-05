using System;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Enviroment.Move
{
    public class PositioningWithRaycastBehaviour : MonoBehaviour
    {
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		private PositioningWithRaycast _positionWithRaycast;

		protected void Awake()
		{
			_positionWithRaycast = new PositioningWithRaycast(_data, _components);
		}

		protected void Update()
		{
			_positionWithRaycast.Update();
		}

		[Serializable]
		public class Data : PositioningWithRaycast.IData
		{
			[SerializeField] private FloatReference _range;
			[SerializeField] private LayerMaskReference _layerMask;

			public float Range => _range.Value;
			public int LayerMask => _layerMask.Value;
		}

		[Serializable]
		public class Components : PositioningWithRaycast.IComponents
		{
			[SerializeField] private Transform _from;
			[SerializeField] private Transform _target;

			public Vector3 From => _from.position;
			public Vector3 Dir => _from.forward;
			public Vector3 Target { set => _target.position = value; }
		}
	}
}
