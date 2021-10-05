using System;
using UnityEngine;
using Unity.Collections;

namespace VEngine.Game.SO.Speed
{
	[CreateAssetMenu(menuName = "SO/Variables/SpeedVariable")]
	public class SpeedVariable : ScriptableObject
	{
		[SerializeField] private float _max;
		[ReadOnly] [SerializeField] private float _value;
		[Header("Event")]
		[SerializeField] private SpeedGameEvent _onSpeedChanged;

		public float Value
		{
			get => _value;
			set
			{
				if (Mathf.Approximately(_value, value))
					return;
				_value = value;
				_onSpeedChanged.Raise(value, _max);
			}
		}

		public float Max { get => _max; }

		public void OnEnable()
		{
			_value = 0.0f;
		}
	}

	[Serializable]
	public class SpeedReference
	{
		[SerializeField] private bool _useConstant = true;
		[SerializeField] private SpeedVariable _variable;
		[SerializeField] private Vector2 _constantValue;

		public bool UseConstant { get => _useConstant; set => _useConstant = value; }

		public float Value { get => UseConstant ? _constantValue.x : _variable.Value; }
		public float Max { get => UseConstant ? _constantValue.y : _variable.Max; }
	}
}
