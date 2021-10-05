using UnityEngine;
using VEngine.SO.Events;

namespace VEngine.CCTV.Events
{
	[CreateAssetMenu(menuName = "SO/CCVT/Events/CCTVRotateableGameEvent")]
	public class CCTVRotateableGameEvent : TGameEvent<ICCTVRotateable>
	{
	}
}
