﻿using UnityEngine;
using UnityEngine.AI;

public class ArrowNPCMovement : MonoBehaviour
{
    private GameObject targetGo = null;
    private WaypointManager waypointManager;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        waypointManager = GetComponent<WaypointManager>();
        HeadForNextWayPoint();
    }

    void Update()
    {
        float closeToDestination = navMeshAgent.stoppingDistance * 2;
        if (navMeshAgent.remainingDistance < closeToDestination)
        {
            HeadForNextWayPoint();
        }

    }

    private void HeadForNextWayPoint()
    {
        targetGo = waypointManager.NextWaypoint(targetGo);
        navMeshAgent.SetDestination(targetGo.transform.position);
    }
}
