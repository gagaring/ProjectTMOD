namespace VEngine.SO.Events
{
    public interface IGameEvent
    {
        int RegisteredCount { get; }
        void Raise();
        void RegisterListener(IGameEventListener listener);
        void UnregisterListener(IGameEventListener listener);
    }

    public interface IGameEvent<T>
    {
        int RegisteredCount { get; }
        void Raise(T t);
        void RegisterListener(IGameEventListener<T> listener);
        void UnregisterListener(IGameEventListener<T> listener);
	}

    public interface IGameEvent<T1, T2>
    {
        int RegisteredCount { get; }
        void Raise(T1 t1, T2 t2);
        void RegisterListener(IGameEventListener<T1, T2> listener);
        void UnregisterListener(IGameEventListener<T1, T2> listener);
    }

    public interface IGameEvent<T1, T2, T3>
    {
        int RegisteredCount { get; }
        void Raise(T1 t1, T2 t2, T3 t3);
        void RegisterListener(IGameEventListener<T1, T2, T3> listener);
        void UnregisterListener(IGameEventListener<T1, T2, T3> listener);
    }

    public interface IGameEvent<T1, T2, T3, T4>
    {
        int RegisteredCount { get; }
        void Raise(T1 t1, T2 t2, T3 t3, T4 t4);
        void RegisterListener(IGameEventListener<T1, T2, T3, T4> listener);
        void UnregisterListener(IGameEventListener<T1, T2, T3, T4> listener);
    }
}
