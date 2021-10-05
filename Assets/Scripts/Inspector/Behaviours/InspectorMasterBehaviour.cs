using System;
using UnityEngine;
using VEngine.Input;
using VEngine.Items;

namespace VEngine.Inspector
{
    public class InspectorMasterBehaviour : MonoBehaviour, InspectorMaster.IData
	{
		[SerializeField] private GameObject _main;
		[SerializeField] private InputActivator _inputActivator;
		[SerializeField] private ObjectSetterBehaviour _objectSetter;

		public GameObject Parent => _main;
		public IInputActivator InputActivator => _inputActivator;
		public IObjectSetter ObjectSetter => _objectSetter.Setter;

		public IInspectorMaster _master = null;

        public IInspectorMaster Master
        {
			get
			{
                if(_master == null)
                    _master = new InspectorMaster(this);
                return _master;
            }
        }

		protected void Awake()
		{
            Open(false);
		}

		public void Open(bool open)
		{
            Master.Open(open);
		}

        public void Inspect(IItem item)
		{
            Master.Inspect(item);
		}

        public void ClosePressed(bool pressed)
		{
            if (!pressed)
                return;
            Open(false);
		}
	}
}
