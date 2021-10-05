using UnityEngine;
using VEngine.Input;
using VEngine.Log;

namespace VEngine.Interaction.Input
{
	public class RotatorInputObserver : InputObserver
	{
		private readonly IRotatorData _data;

		public RotatorInputObserver(IRotatorData data, string name = "") : base(data, name)
		{
			_data = data;
			Register(_input.Interact.Close, ctx => _data.Close = IsPushed(ctx), false);
			VLog.Log(VLog.eFlag.Input, VLog.eLevel.Normal, $"RotatorInput Inited");
		}

		public override void Update()
		{
			_data.Rotate = _input.Interact.Rotate.ReadValue<Vector2>();
		}

		protected override void Reset()
		{
			_data.Rotate = Vector2.zero;
		}

		public interface IRotatorData : IData
		{
			Vector2 Rotate { set; }
			bool Close { set; }
		}
	}
}
