using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Base
{
	public class TransformSOPositionFollower : MonoBehaviour
	{
		[SerializeField] private TransformSO _target;

		public void OnPositionOverrided() => transform.position =_target.Position;
	}
}