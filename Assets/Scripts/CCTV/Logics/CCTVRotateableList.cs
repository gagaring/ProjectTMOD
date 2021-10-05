using System;
using System.Collections.Generic;
using UnityEngine;

namespace VEngine.CCTV
{
	[Serializable]
	public class CCTVRotateableList : CCTVList<ICCTVRotateable>
	{
		[SerializeField] private List<CCTVRotateableBehaviour> _rotateableBehaviours;

		protected override List<ICCTVRotateable> GetList()
		{
			return _rotateableBehaviours.ConvertAll(x => x.Rotateable);
		}
	}
}
