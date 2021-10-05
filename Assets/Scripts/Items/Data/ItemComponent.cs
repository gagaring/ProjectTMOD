using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;

namespace VEngine.Items
{
	//[CreateAssetMenu(menuName = "SO/Item/ItemComponents/" )]
	public abstract class ItemComponent : SerializedScriptableObject
	{
		private static Dictionary<Type, ItemComponent> _defaults = new Dictionary<Type, ItemComponent>();

		public static T FindOn<T>(IItem item, bool nullable = true) where T : ItemComponent
		{
			var component = (T)item.Find(typeof(T));
			if (nullable || component != null)
				return component;
			if (GetDefault(typeof(T), out var itemComponent))
				return (T)itemComponent;
			return null;
		}

		private static bool GetDefault(Type type, out ItemComponent component)
		{
			if (_defaults.TryGetValue(type, out component))
				return true;

			component = (ItemComponent) CreateInstance(type);
			component.name = $"Default_{type.Name}";
			_defaults.Add(type, component);
			return true;
		}
	}
}
