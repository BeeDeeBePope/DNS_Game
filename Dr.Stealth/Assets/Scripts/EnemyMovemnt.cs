using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AI;
using UnityEngine;
using UnityEngine.AI;
using Variables._Definitions;

public class EnemyMovemnt : MonoBehaviour
{
    public Transform[] PatrolPoints;
    public float[] Wait;

    private NavMeshAgent navMeshAgent;
    private int iterator;
    private Transform currenWaypoint;
    private float waittime;

    // Use this for initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.isStopped = true;
        waittime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.isStopped && waittime <= 0)
        {
            if (iterator >= PatrolPoints.Length)
            {
                iterator = 0;
            }

            currenWaypoint = PatrolPoints[iterator++];
            navMeshAgent.SetDestination(currenWaypoint.position);
            navMeshAgent.isStopped = false;
        }
    }
}
