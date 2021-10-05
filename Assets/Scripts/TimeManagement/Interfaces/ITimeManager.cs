namespace VEngine.TimeManagement
{
    public interface ITimeManager 
    {
        void Activate(IGameSpeed gameSpeed);
        void Deactivate(IGameSpeed gameSpeed);
    }
}
