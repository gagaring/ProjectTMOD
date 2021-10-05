using System.Collections.Generic;
using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.CCTV.Events
{
	[CreateAssetMenu(menuName = "SO/CCVT/Events/OpenCCTVEvent")]
	public class CCTVOpenGameEvent : TGameEvent<IReadOnlyList<ICCTVSelectable>, IReadOnlyList<ICCTVSelectable>, IReadOnlyList<ICCTVSelectable>>
	{
	}
}
