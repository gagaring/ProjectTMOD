using UnityEngine;

namespace VEngine.Game.Entity.Light
{
	public class CFlashlightTargetBound : MonoBehaviour
	{
		private BoxCollider _boxCollider;

		private Vector3 Min { get => _boxCollider.bounds.min; }
		private Vector3 Max { get => _boxCollider.bounds.max; }
		private float RandX { get => Random.Range(Min.x, Max.x); }

		private float RandY { get => Random.Range(Min.y, Max.y); }
		private float RandZ { get => Random.Range(Min.z, Max.z); }

		public Vector3 RandInnerPoint { get => new Vector3(RandX, RandY, RandZ); }

		public CFlashlightTargetBound(BoxCollider box, UnityEngine.Light light, float zAngle)
		{
			_boxCollider = box;
			box.isTrigger = true;
			Set(light, zAngle);
		}

		private void Set(UnityEngine.Light light, float zAngle)
		{
			var zSize = 0.01f;
			_boxCollider.transform.position = light.transform.position + light.transform.forward * (light.range - zSize * 2.0f) * 0.8425f;
			_boxCollider.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, zAngle);
			var xySize = Mathf.Tan(Mathf.Deg2Rad * light.spotAngle * 0.5f) * light.range;
			_boxCollider.transform.localScale = new Vector3(xySize, xySize, zSize);
		}

		public bool IsInBound(Vector3 position) => _boxCollider.bounds.Contains(position);
	}
}
