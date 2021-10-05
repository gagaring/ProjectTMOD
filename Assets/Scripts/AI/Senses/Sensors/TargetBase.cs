using UnityEngine;

namespace VEngine.AI.Senses.Sensors
{
	public abstract class TargetBase : MonoBehaviour
	{
		protected abstract void OnTargetedChanged(bool targeted);

		private bool _targeted = false;

		public float TargetStart { get; set; }
		public float TargetEnd { get; set; }

		public virtual bool Targeted
		{
			get => _targeted;
			set
			{
				if (_targeted == value)
					return;
				_targeted = value;
				if (_targeted)
					TargetStart = Time.time;
				else
					TargetEnd = Time.time;

				OnTargetedChanged(_targeted);
			}
		}

	}
}
