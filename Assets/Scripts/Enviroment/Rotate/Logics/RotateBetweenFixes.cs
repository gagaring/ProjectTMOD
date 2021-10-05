using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Enviroment.Rotate
{
	public class RotateBetweenFixes : IRotateBetweenFixes
	{
		private readonly IData _data;
		private readonly IComponents _components;

		private int _currentIndex;

		private int CurrentIndex
		{
			get => _currentIndex;
			set
			{
				if (value == _currentIndex)
					return;
				if (value < 0)
					_currentIndex = _data.CanItRotateAround ? _components.TargetRotations.Count - 1 : 0;
				else if (value >= _components.TargetRotations.Count)
					_currentIndex = _data.CanItRotateAround ? 0 : _components.TargetRotations.Count - 1;
				else
					_currentIndex = value;
				_data.Enabled = true;
			}
		}

		public bool CanRotatePositive => _data.CanItRotateAround || CurrentIndex < _components.TargetRotations.Count - 1;
		public bool CanRotateNegative => _data.CanItRotateAround || CurrentIndex > 0;

		public RotateBetweenFixes(IData data, IComponents components)
		{
			_data = data;
			_components = components;
			CurrentIndex = _data.DefaultIndex;
		}

		public void Rotate(bool increase)
		{
			CurrentIndex += increase ? 1 : -1;
		}

		public void Update(float deltaTime)
		{
			_components.Target = Quaternion.RotateTowards(_components.Target, _components.TargetRotations[CurrentIndex].rotation, _data.RotationSpeed * deltaTime);
			if (Quaternion.Angle(_components.Target, _components.TargetRotations[CurrentIndex].rotation) > 0.01f)
				return;
			_data.Enabled = false;
		}

		public interface IData
		{
			int DefaultIndex { get; }
			bool CanItRotateAround { get; }
			float RotationSpeed { get; }
			bool Enabled { set; }
		}

		public interface IComponents
		{
			Quaternion Target { get; set; }
			IReadOnlyList<Transform> TargetRotations { get; }
		}
	}
}
