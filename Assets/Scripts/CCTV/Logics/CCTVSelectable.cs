

using System;
using UnityEngine;

namespace VEngine.CCTV
{
	public class CCTVSelectable : ICCTVSelectable
	{
		private readonly IData _data;
		private readonly IComponents _components;

		public bool Selected 
		{
			set
			{
				_components.Selected = value;
				if (value)
					OnSelected?.Invoke();
			}
		}

		public Action OnSelected { get; set; }

		public CCTVSelectable(IData data, IComponents components)
		{
			_data = data;
			_components = components;
			Selected = false;
		}

		public interface IData
		{
		}

		public interface IComponents
		{
			bool Selected { set; }
		}
	}
}
