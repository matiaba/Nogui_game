using UnityEngine;
using System;

public class WaypointManager : MonoBehaviour
{
    public GameObject[] waypoints;

    public GameObject NextWaypoint(GameObject current)
    {
        int currentIndex = Array.IndexOf(waypoints, current);
		int nextIndex = (currentIndex + 1) % waypoints.Length;
		
		return waypoints[nextIndex];
    }
}