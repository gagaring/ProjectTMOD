using Sirenix.OdinInspector;
using UnityEngine;

namespace VEngine.TimeManagement
{
    public class TimeManagerBehaviour : SerializedMonoBehaviour, TimeStack.IData, TimeVariable.IData
    {
		[SerializeField] public GameSpeed DefaultSpeed { get; private set; }

        private ITimeManager _timeManager;

        private void Awake()
        {
            _timeManager = new TimeVariable(this);
        }

        public void Activate(IGameSpeed gameSpeed, bool activate)
        {
            if (activate)
                _timeManager.Activate(gameSpeed);
            else 
                _timeManager.Deactivate(gameSpeed);
        }
    }
}
