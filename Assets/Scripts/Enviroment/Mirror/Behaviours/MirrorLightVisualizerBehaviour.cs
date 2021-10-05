using System;
using UnityEngine;

namespace VEngine.Enviroment.Mirror
{
	public class MirrorLightVisualizerBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		private MirrorLightVisualizer _mirrorLightVisualizer;

		public MirrorLightVisualizer MirrorLightVisualizer 
		{ 
			get
			{
				if(_mirrorLightVisualizer == null)
					_mirrorLightVisualizer = new MirrorLightVisualizer(_data, _components);
				return _mirrorLightVisualizer;
			}
		}

		[Serializable]
		public class Data : MirrorLightVisualizer.IData
		{

		}

		[Serializable]
		public class Components : MirrorLightVisualizer.IComponents
		{
			[SerializeField] private GameObject _main;
			[SerializeField] private Transform _visualizer;
			[SerializeField] private float _scaleMultiplier;

			public GameObject Main => _main;

			public Vector3 Dir { set => _main.transform.forward = value; }
			public float Scale
			{
				set
				{
					var scale = _visualizer.localScale;
					scale.z = value * _scaleMultiplier;
					_visualizer.localScale = scale; ;
				}
			}
		}
	}
}
