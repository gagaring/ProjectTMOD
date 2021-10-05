using System;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.Items
{
	[CreateAssetMenu(menuName = "SO/Item/Item")]
	public class Item : ScriptableObject, IItem
	{
		[SerializeField] private Details _details;
		[SerializeField] private List<ItemComponent> _components = new List<ItemComponent>();

		public IDetails Details { get => _details; set => _details = (Details) value; }


		public ItemComponent Find(Type type)
		{
			return _components.Find(x => x != null && type.IsAssignableFrom(x.GetType()));
		}

		public IReadOnlyList<ItemComponent> FindAll(Type type)
		{
			return _components.FindAll(x => x.GetType() == type);
		}

		public IReadOnlyList<ItemComponent> FindAll(Predicate<ItemComponent> match)
		{
			return _components.FindAll(match);
		}

		public void AddComponent(ItemComponent component) => _components.Add(component);
	}

	[Serializable]
	public class ItemReference : IItemReference
	{
		[SerializeField] private Item _value;

		public ItemReference(Item item)
		{
			_value = item;
		}

		public IItem Value => _value;
		public void SetValue(Item item) => _value = item;
	}
}
