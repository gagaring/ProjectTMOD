using System;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.CCTV
{
	[Serializable]
	public class CCTVSelectableList : CCTVList<ICCTVSelectable>
	{
		[SerializeField] private List<CCTVSelectableBehaviour> _selectableList;

		protected override List<ICCTVSelectable> GetList()
		{
			return _selectableList.ConvertAll(x => x.Selectable);
		}
	}
}
