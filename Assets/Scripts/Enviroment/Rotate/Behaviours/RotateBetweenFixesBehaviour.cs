using UnityEngine;
using System.Collections.Generic;
using VEngine.SO.Variables;

namespace VEngine.Enviroment.Rotate
{
	public class RotateBetweenFixesBehaviour : MonoBehaviour, RotateBetweenFixes.IData, RotateBetweenFixes.IComponents
	{
		[SerializeField] private int _defaultIndex;
		[SerializeField] private bool _canInRotateAround;
		[SerializeField] private FloatReference _rotationSpeed;

		[SerializeField] private Transform _target;
		[SerializeField] private List<Transform> _rotations;

		public Quaternion Target { get => _target.rotation; set => _target.rotation = value; }
		public IReadOnlyList<Transform> TargetRotations => _rotations;
		public int DefaultIndex => _defaultIndex;
		public bool CanItRotateAround => _canInRotateAround;
		public float RotationSpeed => _rotationSpeed.Value;
		public bool Enabled { set => enabled = value; }

		public IRotateBetweenFixes RotateBetweenFixes { get; private set; }

		protected void Awake() => RotateBetweenFixes = new RotateBetweenFixes(this, this);	
		protected void Update() => RotateBetweenFixes.Update(Time.deltaTime);
	}
}
