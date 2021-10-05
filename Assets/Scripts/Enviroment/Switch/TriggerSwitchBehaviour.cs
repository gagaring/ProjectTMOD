using System;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Enviroment.Switch
{
	public class TriggerSwitchBehaviour : MonoBehaviour, ISwitch
	{
		[SerializeField] private List<Collider> _activators;

		private HashSet<Collider> _activaActivators = new HashSet<Collider>();

		public Action<ISwitch, bool> OnChanged { get; set ; }

		protected void OnTriggerEnter(Collider other)
		{
			if (!_activators.Contains(other) || _activaActivators.Contains(other))
				return;
			_activaActivators.Add(other);
			OnChanged?.Invoke(this, true);
		}

		protected void OnTriggerExit(Collider other)
		{
			if (!_activators.Contains(other) )
				return;
			_activaActivators.Remove(other);
			if(_activaActivators.Count == 0)
				OnChanged?.Invoke(this, false);
		}
	}
}
