namespace VEngine.GUI
{
    public class WindowStackHandler : IWindowStackHandler
    {
        private readonly IData _data;

        public WindowStackHandler(IData data) => _data = data;

		public void OnWindowOpened(IWindow window, bool opened)
        {
			if (opened)
				_data.Stack.Add(window);
			else
				_data.Stack.Remove(window);
        }

		public bool CloseAllWindow()
		{
			if (_data.Stack.IsEmpty)
				return false;
			while (CloseTopWindow()) {}
			return true;
		}

		public bool CloseTopWindow()
		{
			if (_data.Stack.IsEmpty)
				return false;
			_data.Stack.Peek().Close();
			return true;
		}

		public interface IData
		{
            IWindowStack Stack { get; }
		}
    }
}
