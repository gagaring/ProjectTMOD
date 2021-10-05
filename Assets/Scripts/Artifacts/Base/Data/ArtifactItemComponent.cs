using System;
using System.Collections.Generic;
using UnityEngine;
using VEngine.Items;
using VEngine.ObjectPool;

namespace VEngine.Artifacts
{
	[CreateAssetMenu(menuName = "SO/Item/ItemComponents/ArtifactItemComponent")]
	public class ArtifactItemComponent : ItemComponent, IArtifactData
	{
		[SerializeField] private IObjectPoolEntity _entity;
		[SerializeField] private IArtifactUseage _useage;
		[SerializeField] private List<IArtifactUseageEvent> _eventListeners = new List<IArtifactUseageEvent>();

		public IReadOnlyList<IArtifactUseageEvent> EventListeners => _eventListeners;
		public IArtifactUseage Useage => _useage;
		public IObjectPoolEntity Entity => _entity;

		public IArtifactUseageEvent GetUseageEvent(Type type)
		{
			return _eventListeners.Find(x => x != null && type.IsAssignableFrom(x.GetType()));
		}

		public T GetUseageEvent<T>() where T : IArtifactUseageEvent => (T)GetUseageEvent(typeof(T));

		public bool GetUseage<T>(out T useage) where T : IArtifactUseage
		{
			if (!typeof(T).IsAssignableFrom(_useage.GetType()))
			{
				useage = default(T);
				return false;
			}
			useage = (T)_useage;
			return true;
		}
	}
}
