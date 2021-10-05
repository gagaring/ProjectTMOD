using UnityEngine;
using VEngine.Input;
using VEngine.Items;

namespace VEngine.Inspector
{
	public class InspectorMaster : IInspectorMaster
	{
		private readonly IData _data;

		public InspectorMaster(IData data)
		{
			_data = data;
		}

		public void Open(bool open)
		{
			_data.Parent.gameObject.SetActive(open);
			_data.InputActivator.Activate(open);
		}

		public void Inspect(IItem item)
		{
			if (_data.ObjectSetter.Attached != null)
				Detach();
			var component = ItemComponent.FindOn<InspectItemComponent>(item);
			if (component == null)
				return;
			Inspect(component);
		}

		private void Inspect(IInspectable inspectable)
		{
			//TODO Inspect: Jatek kozbeni Instantiate
			_data.ObjectSetter.Attached = GameObject.Instantiate(inspectable.Prefab);
		}

		public void Detach()
		{
			GameObject.DestroyImmediate(_data.ObjectSetter.Attached);
			_data.ObjectSetter.Attached = null;
		}

		public interface IData
		{
			GameObject Parent { get; }
			IInputActivator InputActivator { get; }
			IObjectSetter ObjectSetter { get; }
		}
	}
}
