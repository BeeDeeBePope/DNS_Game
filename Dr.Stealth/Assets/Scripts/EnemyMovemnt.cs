using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AI;
using UnityEngine;
using UnityEngine.AI;
using Variables._Definitions;

[Serializable]
public class BehaviourPoint {
    public Transform Transform;
    public MovementNode MovementNode;
}

public enum MovementNode 
{
    None, 
    Wait,
    Interact
}

public class EnemyMovemnt : MonoBehaviour
{
    public BehaviourPoint[] PatrolPoints;
    public float[] Wait;
    public Vector3Variable PlayerPosition;
    public EnemyInteraction interaction;

    public Light spotlight;
    public float viewDistance;
    float viewAngle;
    public LayerMask viewMask;

    private NavMeshAgent navMeshAgent;
    private int iterator;
    private BehaviourPoint currenWaypoint;
    private float waittime;
    private bool actionPerformed = true;

    private bool isWaiting;
    private float waitTime;

    Color originalSpotlightColor;
    // Use this for initialization
    void Start()
    {
        viewAngle = spotlight.spotAngle;
        originalSpotlightColor = spotlight.color;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.isStopped = true;
        waitTime = 2;
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
        
        

        

        if (navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete) {

            if (isWaiting) {
                waitTime -= Time.deltaTime;
                if (waitTime <= 0) {
                    isWaiting = false;
                    actionPerformed = true;
                }
                return;
            }

            if (actionPerformed) {
                if (iterator >= PatrolPoints.Length) {
                    iterator = 0;
                }

                currenWaypoint = PatrolPoints[iterator++];
                navMeshAgent.SetDestination(currenWaypoint.Transform.position);
            }
            if (!isWaiting) {
                switch (currenWaypoint.MovementNode) {
                    case MovementNode.None:
                        break;
                    case MovementNode.Wait:
                        isWaiting = true;
                        waitTime = 2;
                        break;
                    case MovementNode.Interact:
                        float interactionTime = interaction.InteractWithClosest();
                        isWaiting = true;
                        waitTime = interactionTime;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("MovementNode Value not implemented.");

                }
            }
        }




        //if (CanSeePlayer())
        //{
        //    spotlight.color = Color.red;
        //}
        //else
        //{
        //    spotlight.color = originalSpotlightColor;
        //}
        //if (navMeshAgent.isStopped && waittime <= 0)
        //{
        //    if (iterator >= PatrolPoints.Length)
        //    {
        //        iterator = 0;
        //    }

        //    waittime = Wait[iterator];
        //    currenWaypoint = PatrolPoints[iterator++];
        //    navMeshAgent.SetDestination(currenWaypoint.position);
        //}

        //waittime -= Time.deltaTime;

        //if (waittime <= 0)
        //{
        //    navMeshAgent.isStopped = false;
        //}

        //if (Math.Abs(transform.position.x - currenWaypoint.position.x) < .0001f && Math.Abs(transform.position.z - currenWaypoint.position.z) < .0001f)
        //{
        //    navMeshAgent.isStopped = true;
        //}
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);

    }
}
