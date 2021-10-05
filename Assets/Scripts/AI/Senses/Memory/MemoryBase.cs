using System.Collections.Generic;
using UnityEngine;
using VEngine.AI.Senses.Sensors;

namespace VEngine.AI.Senses.Memory
{
	public class MemoryBase<TSensor, TTarget> : SenseBase where TSensor : SensorBase<TTarget> where TTarget : TargetBase
	{
		[SerializeField] private TSensor _sensor;
		[SerializeField] private float _rememberDuration;

		private float _nextRemoveTime = 0;

		public HashSet<TTarget> _targets = new HashSet<TTarget>();

		public void Init()
		{
			_sensor.OnTargeted += OnTargeted;
		}

		private void OnTargeted(TTarget target, bool targeted)
		{
			if (targeted)
			{
				_targets.Remove(target);
			}
			else
			{
				_targets.Add(target);
			}
		}

		private void Update()
		{
			if (!IsRemoveEnabled())
				return;
			RemoveObsoleteTargets(out var earliestEndTime);
			CalculateNextRemoveTime(earliestEndTime);
		}

		private bool IsRemoveEnabled()
		{
			return _targets.Count != 0 && _nextRemoveTime <= Time.time;
		}

		private void RemoveObsoleteTargets(out float earliestEndTime)
		{
			/*TODO otlet: jelenleg mindegy, hogy mit es mennyi ideig lat, mindig ugyanannyi ideig emlekszik ra
			 * lehetne az, hogy playerre tobb ideig emlekszik, ha sokaig lat valamit, akkor is tobb ideig emlekszik ra
			 * */
			earliestEndTime = float.MaxValue;
			var limit = Time.time - _rememberDuration;
			var removeables = new List<TTarget>();
			foreach(var curr in _targets)
			{
				if (curr.TargetEnd < limit)
					removeables.Add(curr);
				else if (curr.TargetEnd < earliestEndTime)
					earliestEndTime = curr.TargetEnd;
			}
			_targets.RemoveWhere(x => removeables.Contains(x));
		}

		private void CalculateNextRemoveTime(float earliestEndTime)
		{
			_nextRemoveTime = earliestEndTime == float.MaxValue ? 0.0f : earliestEndTime + _rememberDuration;
		}
	}
}
