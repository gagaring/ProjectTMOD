
using System;
using UnityEngine;

namespace VEngine.Artifacts.Throwables
{
	public class ThrowableArtifact : Artifact
	{
		private Rigidbody _rigidbody;

		private Rigidbody Rigidbody
		{
			get
			{
				if (_rigidbody == null)
					SetRigidBody();
				return _rigidbody;
			}
		}

		public ThrowableArtifact() : base() { }
	
		public ThrowableArtifact(IData data) : base(data) 
		{
			SetRigidBody();
		}

		public override bool Init(IData data)
		{
			if (!base.Init(data))
				return false;
			SetRigidBody();
			return true;
		}

		private void SetRigidBody()
		{
			_rigidbody = base.GetComponent<Rigidbody>();
		}

		public override T GetComponent<T>()
		{
			if (typeof(T) == typeof(Rigidbody))
				return (T)Convert.ChangeType(Rigidbody, typeof(T));
			return base.GetComponent<T>();
		}
	}
}