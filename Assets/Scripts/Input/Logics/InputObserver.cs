using System;
using UnityEngine.InputSystem;
using VEngine.Log;
using VEngine.SO.Variables;

namespace VEngine.Input
{
    public abstract class InputObserver : IInputObserver
    {
		private readonly IData _data;
		protected readonly DefaultInputActionMap _input;

		public string Name { get; private set; }

		protected bool IsInputNull => _input == null;
		protected IInputActionCollection InputActionCollection => _input;
		protected abstract void Reset();

		public InputObserver(IData data, string name = "")
		{
			Name = name;
			_data = data;
			//TODO ez minden inputnak kulon le van generalva
			_input = new DefaultInputActionMap();
			VLog.Log(VLog.eFlag.Input, VLog.eLevel.Normal, $"InputObserver ({Name}) inited: {_data.IsEnabled.Value}");
		}

		public virtual void Activate(bool active)
		{
			if (active)
				InputActionCollection.Enable();
			else
			{
				InputActionCollection.Disable();
				Reset();
			}
			VLog.Log(VLog.eFlag.Input, VLog.eLevel.Normal, $"InputObserver ({Name}) activated: {active}");
		}

		public virtual void Update()
		{
		}

		protected void Register(InputAction inputAction, Action<InputAction.CallbackContext> action, bool usePerformed)
		{
			inputAction.started += action;
			inputAction.canceled += action;
			if (usePerformed)
				inputAction.performed += action;
		}

		protected void Unregister(InputAction inputAction, Action<InputAction.CallbackContext> action, bool usePerformed)
		{
			inputAction.started -= action;
			inputAction.canceled -= action;
			if (usePerformed)
				inputAction.performed -= action;
		}

		protected bool IsPushed(InputAction.CallbackContext ctx)
		{
			return ctx.phase != UnityEngine.InputSystem.InputActionPhase.Canceled;
		}

		public interface IData
		{
			IVariableWithOnChangeEvent<bool> IsEnabled { get; }
		}
	}
}
