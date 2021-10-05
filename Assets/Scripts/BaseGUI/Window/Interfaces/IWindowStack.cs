namespace VEngine.GUI
{
	public interface IWindowStack : IWindowStackReference
	{
		void Add(IWindow window);
		void Remove(IWindow window);
	}

	public interface IWindowStackReference
	{
		bool IsEmpty { get; }
		int OpenWindowCount { get; }

		IWindow Peek();
	}
}