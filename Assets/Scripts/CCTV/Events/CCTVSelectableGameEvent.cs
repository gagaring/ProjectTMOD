using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.CCTV.Events
{
	[CreateAssetMenu(menuName = "SO/CCVT/Events/CCTVSelectableGameEvent")]
	public class CCTVSelectableGameEvent : TGameEvent<ICCTVSelectable>
	{
	}
}
