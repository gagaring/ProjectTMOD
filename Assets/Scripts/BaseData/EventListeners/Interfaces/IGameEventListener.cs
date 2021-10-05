namespace VEngine.SO.Events
{
    public interface IGameEventListener 
    {
        void OnEventRaised();
        string Name { get; }
    }

    public interface IGameEventListener<T>
    {
        string Name { get; }
        void RegisterToEvent();
        void UnregisterFromEvent();
        void OnEventRaised(T t);
    }

    public interface IGameEventListener<T1, T2>
    {
        void OnEventRaised(T1 t1, T2 t2);
        string Name { get; }
    }

    public interface IGameEventListener<T1, T2, T3>
    {
        void OnEventRaised(T1 t1, T2 t2, T3 t3);
        string Name { get; }
    }

    public interface IGameEventListener<T1, T2, T3, T4>
    {
        void OnEventRaised(T1 t1, T2 t2, T3 t3, T4 t4);
        string Name { get; }
    }
}
