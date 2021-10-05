using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Inspector
{
	public class ObjectScaler : IObjectScaler
	{
		private readonly FloatReference _targetSize;

		public ObjectScaler(FloatReference targetSize)
		{
			_targetSize = targetSize;
		}

		public void Scale(GameObject target)
		{
			if (target == null)
				return;
			target.transform.localScale = Vector3.one;
			Mesh mesh = target.GetComponentInChildren<MeshFilter>().mesh;
			Bounds bounds = mesh.bounds;
			float size = Mathf.Max(bounds.extents.x, bounds.extents.y, bounds.extents.z);
			target.transform.localScale = Vector3.one * (_targetSize.Value / size);
		}
	}
}
