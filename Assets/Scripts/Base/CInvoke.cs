using System;
using UnityEngine;

namespace VEngine
{
	public class CInvoke
	{
		private float _invokeTime;
		private float _repeat;
		private Action _callback;

		public CInvoke()
		{
			Cancel();
		}

		public void Start(Action callback, float startTime, float repeat = -1.0f)
		{
			_callback = callback;
			_invokeTime = Time.time + startTime;
			_repeat = repeat;
		}

		public void Update()
		{
			if (_invokeTime > Time.time)
				return;
			_callback.Invoke();
			_invokeTime = _repeat == -1 ? _invokeTime = int.MaxValue : Time.time + _repeat;
		}

		public void Cancel()
		{
			_invokeTime = float.MaxValue;
		}
	}

	public class CInvoke<T>
	{
		private float _invokeTime;
		private float _repeat;
		private Action<T> _callback;
		private T _value;

		public CInvoke()
		{
			Cancel();
		}

		public void Start(Action<T> callback, T value, float startTime, float repeat = -1.0f)
		{
			_callback = callback;
			_value = value;
			_invokeTime = Time.time + startTime;
			_repeat = repeat;
		}

		public void Update()
		{
			if (_invokeTime > Time.time)
				return;
			_callback.Invoke(_value);
			_invokeTime = _repeat == -1 ? _invokeTime = int.MaxValue : Time.time + _repeat;
		}

		public void Cancel()
		{
			_invokeTime = float.MaxValue;
		}
	}

	public class CInvoke<T1, T2>
	{
		private float _invokeTime;
		private float _repeat;
		private Action<T1, T2> _callback;
		private T1 _value1;
		private T2 _value2;

		public CInvoke()
		{
			Cancel();
		}

		public void Start(Action<T1, T2> callback, T1 value1, T2 value2, float startTime, float repeat = -1.0f)
		{
			_callback = callback;
			_value1 = value1;
			_value2 = value2;
			_invokeTime = Time.time + startTime;
			_repeat = repeat;
		}

		public void Update()
		{
			if (_invokeTime > Time.time)
				return;
			_callback.Invoke(_value1, _value2);
			_invokeTime = _repeat == -1 ? _invokeTime = int.MaxValue : Time.time + _repeat;
		}

		public void Cancel()
		{
			_invokeTime = float.MaxValue;
		}
	}
}
