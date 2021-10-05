using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Input
{
	[CreateAssetMenu(menuName = "SO/Input/InputActivator")]
	public class InputActivator : SerializedScriptableObject, IInputActivator
	{
		[SerializeField] private IInputStack _inputStack;
		[SerializeField] private List<InputEnabledWithOnChangeEvent> _enableInputs;

		[SerializeField] [ReadOnly] private int _inputHash = -1;

		public void Activate(bool activate)
		{
			if (activate)
				Activate();
			else
				Deactivate();
		}

		public void Activate()
		{
			_inputHash = _inputStack.Activate(_enableInputs);
		}

		public void Deactivate()
		{
			if (_inputHash == -1)
				return;
			_inputStack?.Deactivate(_inputHash);
			_inputHash = -1;
		}

#if UNITY_EDITOR
		[Button("ResetHash")]
		private void ResetHash()
		{
			_inputHash = -1;
		}
#endif
	}
}
