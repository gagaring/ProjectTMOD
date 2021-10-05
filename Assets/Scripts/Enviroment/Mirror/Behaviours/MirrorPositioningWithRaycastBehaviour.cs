using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Enviroment.Mirror
{
	public class MirrorPositioningWithRaycastBehaviour : MonoBehaviour
	{
		[SerializeField] private Data _data;
		[SerializeField] private Components _components;

		private MirrorPositioningWithRaycast _mirrorLightVisualizer;

		protected void Awake()
		{
			_components.CreateVisualizer(_data.MaxRaycastReflection);
			_mirrorLightVisualizer = new MirrorPositioningWithRaycast(_data, _components);
		}

		protected void Update()
		{
			_mirrorLightVisualizer.Update();
		}

		[Serializable]
		public class Data : MirrorPositioningWithRaycast.IData
		{
			[SerializeField] private FloatReference _raycastRange;
			[SerializeField] private LayerMaskReference _raycastLayers;
			[SerializeField] private IntReference _maxRaycastReflection;

			public float RaycastRange => _raycastRange.Value;
			public int LayerMask => _raycastLayers.Value;
			public int MaxRaycastReflection => _maxRaycastReflection.Value;
		}

		[Serializable]
		public class Components : MirrorPositioningWithRaycast.IComponents
		{
			[SerializeField] private Transform _startTransform;
			[SerializeField] private Transform _targetTrigger;
			[SerializeField] private MirrorLightVisualizerBehaviour _visualizerPrefab;
			[SerializeField] private Transform _visualizerParent;

			private List<MirrorPositioningWithRaycast.IVisualizer> _visualizers = new List<MirrorPositioningWithRaycast.IVisualizer>();

			public Vector3 From => _startTransform.position;
			public Vector3 Dir => _startTransform.forward;
			public Vector3 EndTargetPosition { set => _targetTrigger.position = value; }
			public IReadOnlyList<MirrorPositioningWithRaycast.IVisualizer> Visualizers => _visualizers;

			public void CreateVisualizer(int count)
			{
				for (int i = 0; i < count; ++i)
					CreateVisualizer();
			}

			public void CreateVisualizer()
			{
				var visualizer = Instantiate(_visualizerPrefab, _visualizerParent);
				AddVisualizer(visualizer.MirrorLightVisualizer);
			}

			private void AddVisualizer(MirrorPositioningWithRaycast.IVisualizer visualizer)
			{
				_visualizers.Add(visualizer);
			}
		}
	}
}
