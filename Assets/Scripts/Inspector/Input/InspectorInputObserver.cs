using UnityEngine;
using VEngine.Input;
using VEngine.Log;

namespace VEngine.Inspector.Input
{
	public class InspectorInputObserver : InputObserver
	{
		private readonly IInspectorData _data;

		public InspectorInputObserver(IInspectorData data, string name = "") : base(data, name)
		{
			_data = data;

			//Register(_input.Inspector.Close, ctx =>
			//{
			//	if (IsPushed(ctx))
			//		_data.Close = false;
			//}
			//, false);

			VLog.Log(VLog.eFlag.Input, VLog.eLevel.Normal, $"InspectorInput Inited");
		}

		public override void Update()
		{
			var rotateX = _input.Inspector.RotateX.ReadValue<float>();
			var rotateY = _input.Inspector.RotateY.ReadValue<float>();
			_data.Rotate = new Vector2(rotateX, rotateY);
		}

		protected override void Reset()
		{
			_data.Rotate = Vector2.zero;
		}

		public interface IInspectorData : IData
		{
			Vector2 Rotate { set; }
			bool Close { set; }
		}
	}
}
