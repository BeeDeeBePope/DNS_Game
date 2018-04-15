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

            waittime = Wait[iterator];
            currenWaypoint = PatrolPoints[iterator++];
            navMeshAgent.SetDestination(currenWaypoint.position);
        }

        waittime -= Time.deltaTime;

        if (waittime <= 0)
        {
            navMeshAgent.isStopped = false;
        }

        if (Math.Abs(transform.position.x - currenWaypoint.position.x) < .0001f && Math.Abs(transform.position.z - currenWaypoint.position.z) < .0001f)
        {
            navMeshAgent.isStopped = true;
        }
    }
}
