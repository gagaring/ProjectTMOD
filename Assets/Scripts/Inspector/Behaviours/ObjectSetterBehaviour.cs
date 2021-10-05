using System;
using UnityEngine;
using VEngine.SO.Variables;

namespace VEngine.Inspector
{
	public class ObjectSetterBehaviour : MonoBehaviour
	{
		[SerializeField] private Transform _parent;
		[SerializeField] private SingleUnityLayerReference _targetLayer;

		private IObjectSetter _setter;

		public IObjectSetter Setter 
		{ 
			get
			{
				if(_setter == null)
					_setter = new ObjectSetter(_parent, _targetLayer);
				return _setter;
			}
		}

		public void Attach(GameObject gameObject)
		{
			Setter.Attached = gameObject;
		}
	}
}
