using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Base
{
	public class TransformSOAssignerBehaviour : MonoBehaviour
	{
		[SerializeField] private TransformSO _transform;

		protected void Awake()
		{
			_transform.AssignTransform(transform);
		}
	}
}
