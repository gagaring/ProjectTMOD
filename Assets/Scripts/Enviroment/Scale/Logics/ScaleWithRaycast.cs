using UnityEngine;

namespace VEngine.Enviroment.Scale
{
	public class ScaleWithRaycast
    {
        private readonly IData _data;
        private readonly IComponents _components;

        public ScaleWithRaycast(IData data, IComponents components)
        {
            _data = data;
            _components = components;
        }

        public void Update()
        {
            _components.Scale = GetTargetDistance();
        }

        private float GetTargetDistance()
        {
            if (!Physics.Raycast(_components.From, _components.Dir, out var hit, _data.Range, _data.LayerMask))
                return _data.Range;
            return hit.distance;
        }

        public interface IData
        {
            float Range { get; }
            int LayerMask { get; }
        }

        public interface IComponents
        {
            Vector3 From { get; }
            Vector3 Dir { get; }
            float Scale { set; }
        }
    }
}
