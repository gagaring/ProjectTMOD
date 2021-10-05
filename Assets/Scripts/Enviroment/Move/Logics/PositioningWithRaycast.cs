using UnityEngine;

namespace VEngine.Enviroment.Move
{
    public class PositioningWithRaycast
    {
        private readonly IData _data;
        private readonly IComponents _components;

        public PositioningWithRaycast(IData data, IComponents components)
		{
            _data = data;
            _components = components;
		}

        public void Update()
        {
            _components.Target = GetTargetPosition();
        }

		private Vector3 GetTargetPosition()
		{
            return Physics.Raycast(_components.From, _components.Dir, out var hit, _data.Range, _data.LayerMask) ? hit.point : Vector3.one * 6000;
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
            Vector3 Target { set; }
		}
    }
}
