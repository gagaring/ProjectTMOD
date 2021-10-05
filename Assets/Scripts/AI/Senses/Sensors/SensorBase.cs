using System;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.AI.Senses.Sensors
{
	public class SensorBase<T> : SenseBase where T : TargetBase 
	{
		public List<T> Targets { get; protected set; } = new List<T>();

		public Action<T, bool> OnTargeted { get; set; }

		public void DoReset()
		{
			Targets.Clear();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!GetTarget(other, out var target))
				return;
			AddTarget(target);
		}

		private void OnTriggerExit(Collider other)
		{
			if (!GetTarget(other, out var target))
				return;
			RemoveTarget(target);
		}

		private void AddTarget(T target)
		{
			if (Targets.Contains(target))
				return;
			Targets.Add(target);
			OnTargetAdded(target, true);
		}

		private void RemoveTarget(T target)
		{
			if (!Targets.Contains(target))
				return;
			Targets.Remove(target);
			OnTargetAdded(target, false);
		}

		private void OnTargetAdded(T target, bool targeted)
		{
			target.Targeted = targeted;
			OnTargeted?.Invoke(target, targeted);
		}

		private bool GetTarget(Collider collider, out T target)
		{
			target = collider.gameObject.GetComponent<T>();
			return target != null;
		}
	}
}