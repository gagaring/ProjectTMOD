using System;
using System.Collections.Generic;
using UnityEngine.Events;
using VEngine.GUI;
using VEngine.SO.Events;
using VEngine.SO.Variables;

namespace VEngine.PlayerMenu
{
	public class PlayerMenu : Window, IPlayerMenu
	{
		private readonly IPlayerMenuData _data;

		private List<IGameEventListener<bool>> _listeners = new List<IGameEventListener<bool>>();

		public PlayerMenu(IPlayerMenuData data) : base(data)
		{
			_data = data;
			CreateAndRegister();
			CloseAll();
		}

		~PlayerMenu()
		{
			foreach(var curr in _listeners)
				curr.UnregisterFromEvent();
		}

		public override void Open(bool open)
		{
			if (open)
				Open();
			else
				CloseAll();
		}

		public void CloseAll()
		{
			foreach (var page in _data.Pages)
				page.IsOpen.Value = false;
			base.Close();
		}

		public override void Close()
		{
			CloseAll();
		}

		private void CreateAndRegister()
		{
			foreach(var page in _data.Pages)
			{
				var data = new ListenerData(page, OnPageOpened);

				var listener = new TGameEventListener<bool>(data);
				page.IsOpen.OnChangedEvent.RegisterListener(listener);
				_listeners.Add(listener);
			}
		}

		private void OnPageOpened(IPlayerMenuData.IPage page, bool opened)
		{
			if (opened)
				CloseAllPages(page, page.CloseOnPageOpenExceptions);
			else
				OpenPages(page.OpenOnPageClosed);
		}

		private void OpenPages(IReadOnlyList<TVariableWithOnChangeEvent<bool>> events)
		{
			foreach (var currEvent in events)
				currEvent.Value = true;
		}

		private void CloseAllPages(IPlayerMenuData.IPage opened, ICollection<TVariableWithOnChangeEvent<bool>> exceptions)
		{
			foreach(var page in _data.Pages)
			{
				if (opened == page || exceptions.Contains(page.IsOpen))
					continue;
				page.IsOpen.Value = false;
			}
		}

		protected override void OnWindowOpened(bool opened)
		{
			base.OnWindowOpened(opened);
			if (!opened)
				return;
			_data.DefaultPage.Value = true;
		}

		public interface IPlayerMenuData : IWindowData
		{
			IReadOnlyList<IPage> Pages { get; }
			TVariableWithOnChangeEvent<bool> DefaultPage { get; }

			public interface IPage
			{
				string Name { get; }
				TVariableWithOnChangeEvent<bool> IsOpen { get; }
				ICollection<TVariableWithOnChangeEvent<bool>> CloseOnPageOpenExceptions { get; }
				IReadOnlyList<TVariableWithOnChangeEvent<bool>> OpenOnPageClosed { get; }
			}
		}

		public class ListenerData : TGameEventListener<bool>.IData
		{
			public ListenerData(IPlayerMenuData.IPage page, Action<IPlayerMenuData.IPage, bool> OnPageOpened) 
			{
				Name = $"{page.Name}Listener";
				Event = page.IsOpen.OnChangedEvent;
				Response = new UnityEvent<bool>();
				Response.AddListener((x) => OnPageOpened(page, x));
			}

			public string Name { get; set; }
			public IGameEvent<bool> Event { get; set; }
			public UnityEvent<bool> Response { get; set; }
		}
	}
}
