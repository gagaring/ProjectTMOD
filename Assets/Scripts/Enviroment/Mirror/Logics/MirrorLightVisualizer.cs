using UnityEngine;

namespace VEngine.Enviroment.Mirror
{
	public class MirrorLightVisualizer : MirrorPositioningWithRaycast.IVisualizer
	{
		private readonly IData _data;
		private readonly IComponents _components;

		public MirrorLightVisualizer(IData data, IComponents components)
		{
			_data = data;
			_components = components;
		}

		public bool Active { set => _components.Main.SetActive(value); }
		public Vector3 StartPosition { get => _components.Main.transform.position; set => _components.Main.transform.position = value; }
		
		public Vector3 EndPosition 
		{
			set
			{
				var displacementVector = value - StartPosition;
				_components.Scale = displacementVector.magnitude;
				_components.Dir = displacementVector;
			}
		}

		public interface IData
		{
		}

		public interface IComponents
		{
			GameObject Main { get; }
			Vector3 Dir { set; }
			float Scale { set; }
		}
	}
}
