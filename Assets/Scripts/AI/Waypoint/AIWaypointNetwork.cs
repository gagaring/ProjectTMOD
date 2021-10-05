using UnityEngine;
using System.Collections.Generic;

public class AIWaypointNetwork : MonoBehaviour
{
	public enum ePathDisplayMode 
	{ 
		None = 0, 
		Connections = 1, 
		Paths = 2
	}

	[HideInInspector] public ePathDisplayMode DisplayMode = ePathDisplayMode.Connections;
	[HideInInspector] public int UIStart = 0;
	[HideInInspector] public int UIEnd = 0;

	public List<Transform> Waypoints;
}
