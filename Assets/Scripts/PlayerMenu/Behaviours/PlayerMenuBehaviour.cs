using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VEngine.GUI;
using VEngine.SO.Variables;

namespace VEngine.PlayerMenu
{
    public class PlayerMenuBehaviour : WindowBehaviour, PlayerMenu.IPlayerMenuData
	{
		[SerializeField] private BoolVariableWithOnChangeEvent _defaultPage;
		[SerializeField] private List<Page> _pages;

		public IReadOnlyList<PlayerMenu.IPlayerMenuData.IPage> Pages => _pages;
		public TVariableWithOnChangeEvent<bool> DefaultPage => _defaultPage;

		protected override IWindow CreateWindow() => new PlayerMenu(this);

		[Serializable]
		public class Page : PlayerMenu.IPlayerMenuData.IPage
		{
			[SerializeField] private BoolVariableWithOnChangeEvent _isOpen;
			[SerializeField] private List<BoolVariableWithOnChangeEvent> _closeOnOpenExceptions;
			[SerializeField] private List<BoolVariableWithOnChangeEvent> _openOnPageClosed;

			public string Name => _isOpen.name;

			public TVariableWithOnChangeEvent<bool> IsOpen => _isOpen;
			public ICollection<TVariableWithOnChangeEvent<bool>> CloseOnPageOpenExceptions => _closeOnOpenExceptions.ToList<TVariableWithOnChangeEvent<bool>>();
			public IReadOnlyList<TVariableWithOnChangeEvent<bool>> OpenOnPageClosed => _openOnPageClosed;
		}
	}
}
