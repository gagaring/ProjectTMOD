using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Enviroment.Mirror
{
	public class MirrorPositioningWithRaycast
	{
		private readonly IData _data;
		private readonly IComponents _components;

		public MirrorPositioningWithRaycast(IData data, IComponents components)
		{
			_data = data;
			_components = components;
		}

		public void Update()
		{
			StartRaycast(_components.From, _components.Dir, 0);
		}

		private void StartRaycast(Vector3 raycastStart, Vector3 raycastDir, int currentIndex)
		{
			_components.Visualizers[currentIndex].Active = true;
			if (!Physics.Raycast(raycastStart, raycastDir, out var hit, _data.RaycastRange, _data.LayerMask))
			{
				var raycastEndPos = raycastStart + raycastDir * _data.RaycastRange;
				SetVisualizer(_components.Visualizers[currentIndex], raycastStart, raycastEndPos);
				_components.EndTargetPosition = raycastEndPos;
				HideRemainingVisualizers(currentIndex + 1);
				return;
			}

			SetVisualizer(_components.Visualizers[currentIndex], raycastStart, hit.point);
			var mirror = hit.collider.GetComponent<IMirror>();
			if (mirror == null)
			{
				_components.EndTargetPosition = hit.point;
				HideRemainingVisualizers(currentIndex + 1);
				return;
			}
			
			Reflect(raycastDir, hit, currentIndex);
		}

		private void SetVisualizer(IVisualizer visualizer, Vector3 from, Vector3 to)
		{
			visualizer.StartPosition = from;
			visualizer.EndPosition = to;
		}

		private void HideRemainingVisualizers(int min)
		{
			for (int i = min; i < _components.Visualizers.Count; ++i)
				_components.Visualizers[i].Active = false;
		}

		private void Reflect(Vector3 raycastDir, RaycastHit hit, int currentIndex)
		{
			if(currentIndex >= _components.Visualizers.Count - 1)
			{
				_components.EndTargetPosition = hit.point;
				return;
			}
			var outDir = Vector3.Reflect(raycastDir, hit.normal);
			StartRaycast(hit.point, outDir, currentIndex + 1);
		}

		public interface IData
		{
			float RaycastRange { get; }
			int LayerMask { get; }
		}

		public interface IComponents
		{
			Vector3 From { get; }
			Vector3 Dir { get; }
			Vector3 EndTargetPosition { set; }

			IReadOnlyList<IVisualizer> Visualizers { get; }
		}

		public interface IVisualizer
		{
			bool Active { set; }
			Vector3 StartPosition { set; }
			Vector3 EndPosition { set; }
		}
	}
}
