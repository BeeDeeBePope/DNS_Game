using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AI;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovemnt : MonoBehaviour
{
    public Transform[] PatrolPoints;

    private NavMeshAgent navMeshAgent;
    private int iterator;
    private Transform currenWaypoint;

    // Use this for initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.isStopped)
        {
            if (iterator >= PatrolPoints.Length)
            {
                iterator = 0;
            }

            currenWaypoint = PatrolPoints[iterator++];
            navMeshAgent.SetDestination(currenWaypoint.position);
            navMeshAgent.isStopped = false;
        }

        if (Math.Abs(transform.position.x - currenWaypoint.position.x) < .0001f && Math.Abs(transform.position.z - currenWaypoint.position.z) < .0001f)
        {
            navMeshAgent.isStopped = true;
        }

    }
}
