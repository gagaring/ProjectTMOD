using UnityEngine.InputSystem;
using VEngine.Input;

namespace VEngine.HandSystem.Input
{
	public class HandSystemInputObserver : InputObserver
	{
		private readonly IHandData _data;

		public HandSystemInputObserver(IHandData data, string name = "") : base(data, name)
		{
			_data = data;
			Register(_input.Player.HandSlot0, ctx => { IsPushed(ctx, 0); }, false);
			Register(_input.Player.HandSlot1, ctx => { IsPushed(ctx, 1); }, false);

			Register(_input.Player.UseHand, ctx => { _data.UseHand = IsPushed(ctx); }, false);
			Register(_input.Player.TargetingHand, ctx => { _data.TargetingHand = IsPushed(ctx); }, false);
		}

		private void IsPushed(InputAction.CallbackContext ctx, int slotIndex)
		{
			if (!IsPushed(ctx))
				return;
			_data.ActiveEquipmentSlot = slotIndex;
		}

		protected override void Reset()
		{
			_data.UseHand = false;
			_data.TargetingHand = false;
		}

		public interface IHandData : IData
		{
			int ActiveEquipmentSlot { set; }
			bool UseHand { set; }
			bool TargetingHand { set; }
		}

	}
}
