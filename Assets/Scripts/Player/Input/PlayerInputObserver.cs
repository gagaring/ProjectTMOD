using UnityEngine;
using VEngine.Input;
using VEngine.Log;
using VEngine.SO.Events;

namespace VEngine.Player.Input
{
	public class PlayerInputObserver : InputObserver
	{
		private readonly IPlayerData _data;

		public PlayerInputObserver(IPlayerData data, string name = "") : base(data, name)
		{
			_data = data;

			Register(_input.Player.Crouch, ctx => _data.Crouch = IsPushed(ctx), false);
			Register(_input.Player.Sprint, ctx => _data.Sprint = IsPushed(ctx), false);
			Register(_input.Player.Interact, ctx => _data.Interact = IsPushed(ctx), false);
			Register(_input.Player.Jump, ctx => _data.Jump = IsPushed(ctx), false);
			Register(_input.Player.Loot, ctx => { if (IsPushed(ctx)) _data.Loot.Raise(); }, false);
			VLog.Log(VLog.eFlag.Input, VLog.eLevel.Normal, $"PlayerInput Inited");
		}

		public override void Update()
		{
			_data.Move = _input.Player.Move.ReadValue<Vector2>();
			_data.Rotate = _input.Player.Rotate.ReadValue<Vector2>();
		}

		protected override void Reset()
		{
			_data.Move = Vector2.zero;
			_data.Rotate = Vector2.zero;
			_data.Crouch = false;
			_data.Sprint = false;
			_data.Interact = false;
			_data.Jump = false;
		}

		public interface IPlayerData : IData
		{
			Vector2 Move { set; }
			Vector2 Rotate { set; }
			bool Crouch { set; }
			bool Sprint { set; }
			bool Interact { set; }
			bool Jump { set; }
			IGameEvent Loot { get; }
		}
	}
}
