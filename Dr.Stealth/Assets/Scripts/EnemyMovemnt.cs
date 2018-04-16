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
    public Vector3Variable PlayerPosition;

    public Light spotlight;
    public float viewDistance;
    float viewAngle;
    public LayerMask viewMask;

    private NavMeshAgent navMeshAgent;
    private int iterator;
    private Transform currenWaypoint;
    private float waittime;

    Color originalSpotlightColor;
    // Use this for initialization
    void Start()
    {
        viewAngle = spotlight.spotAngle;
        originalSpotlightColor = spotlight.color;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.isStopped = true;
        waittime = 0;
    }
    
    bool CanSeePlayer()
    {
        if(Vector3.Distance(transform.position, PlayerPosition.Value) < viewDistance)
        {
            Vector3 dirToPlayer = (PlayerPosition.Value - transform.position).normalized;
            float angleBetweenEnemieAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenEnemieAndPlayer < viewAngle /2f)
            {
                if(!Physics.Linecast(transform.position, PlayerPosition.Value, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer())
        {
            spotlight.color = Color.red;
        }
        else
        {
            spotlight.color = originalSpotlightColor;
        }
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
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);

    }
}

