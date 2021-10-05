using UnityEngine;
using System.Collections.Generic;

namespace VEngine.Input
{
	public class InputManagerBehaviour : MonoBehaviour
	{
		[SerializeField] private InputStack _inputStack;
		[SerializeField] private List<InputEnabledWithOnChangeEvent> _defaultInputs;

		private int _defaultInputHash = -1;

		protected void Awake()
		{
			_inputStack.Clear();
			_defaultInputHash = _inputStack.Activate(_defaultInputs);
		}

		private void OnDestroy()
		{
			if (_defaultInputHash == -1)
				return;
			_inputStack.Deactivate(_defaultInputHash);
		}
	}
}
