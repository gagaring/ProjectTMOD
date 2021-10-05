using System;
using System.Collections.Generic;
using VEngine.ObjectPool;

namespace VEngine.Artifacts
{
	public interface IArtifactData
	{
		IObjectPoolEntity Entity { get; }
		IArtifactUseage Useage { get; }
		IReadOnlyList<IArtifactUseageEvent> EventListeners { get; }

		T GetUseageEvent<T>() where T : IArtifactUseageEvent;
		bool GetUseage<T>(out T useage) where T : IArtifactUseage;
	}

	//TODO ezt at kene nevezni vagy az eventeset, mivel megteveszto. Mire?
	public interface IArtifactUseage //Throwable, Placeable
	{
	}

	public interface IArtifactUseageEvent //OnThrow, OnTimer, OnCollided, OnTrigger
	{
		void Use(IArtifact artifact);
	}

	public interface IArtifactCommand //Explosion, StartTimer, PushBackToObjectPool, PlaySound, PlayEffect
	{
		void Use(IArtifact artifact);
	}
}
