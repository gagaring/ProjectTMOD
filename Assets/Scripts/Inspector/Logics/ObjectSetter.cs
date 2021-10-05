using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Inspector
{
	public class ObjectSetter : IObjectSetter
	{
		private readonly Transform _parent;
		private readonly SingleUnityLayerReference _targetLayer;

		private GameObject _attached;

		public ObjectSetter(Transform parent, SingleUnityLayerReference targetLayer)
		{
			_parent = parent;
			_targetLayer = targetLayer;
		}

		public GameObject Attached 
		{
			get => _attached;
			set
			{
				SetParentAndReset(value);
				_attached = value;
			} 
		}

		private void SetParentAndReset(GameObject target)
		{
			if (target == null)
				return;
			target.transform.parent = _parent;
			target.transform.localRotation = Quaternion.identity;
			target.transform.localPosition = Vector3.zero;
			target.layer = _targetLayer.Value.LayerIndex;
		}
	}
}
