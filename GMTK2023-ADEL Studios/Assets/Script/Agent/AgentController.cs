using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;
using static AgentController;

public class AgentController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent Agent;
    [SerializeField] private string decisionTag;
    [SerializeField] private string obstacleTag;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private DIRECTION initialDirection;
    [SerializeField] private STATES initialState;

    [SerializeField] private float raycastRange = 8f;
    [SerializeField] private float decisionTime = 5f;

    public enum STATES
    {
        WALKING,
        DECISION,
        PENDING,
        IDLE
    }

    public enum DIRECTION 
    { 
        FRONT,
        BACK,
        LEFT,
        RIGHT
    }

    STATES currentState;
    STATES previousState;

    Vector3 targetPosition;

    private float decisionTimer = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(decisionTag))
        {
            Agent.SetDestination(transform.position + targetPosition * 1f);
            ChangeState(STATES.PENDING);
        }
        else if (other.transform.CompareTag(obstacleTag) && currentState.Equals(STATES.WALKING))
        {
            reverseDirection();
        }
    }

    public void ChangeState (STATES s)
    {
        this.currentState = s;
    }

    private void OnStateChange()
    {
        switch (currentState)
        {
            case STATES.WALKING:

                break;

            case STATES.DECISION:
                decisionTimer = decisionTime;
                break;

            case STATES.PENDING:
                break;

            case STATES.IDLE:
                Agent.isStopped = true;
                break;
        }
        previousState = currentState;
    }

    private void reverseDirection()
    {
        targetPosition = -targetPosition;
    }

    private bool CanWalkTowards()
    {
        Vector3 reverseDirection = -targetPosition;
        Vector3[] checkDirections = { transform.forward, transform.right, -transform.right, -transform.forward };
        

        foreach (Vector3 d in checkDirections)
        {
            if (d != reverseDirection)
            {
                if (!Physics.Raycast(transform.position, d, out _, raycastRange, obstacleLayer))
                {
                    targetPosition = d;
                    return true;
                }
            }
        }

        return false;
    }
    private void Start()
    {
        currentState = initialState;
        previousState = currentState;
        
        switch (initialDirection)
        {
            case DIRECTION.FRONT:
                targetPosition = transform.forward;
                break;

            case DIRECTION.LEFT:
                targetPosition = -transform.right;
                break;

            case DIRECTION.BACK:
                targetPosition = -transform.forward;
                break;

            case DIRECTION.RIGHT:
                targetPosition = transform.right;
                break;

            default:
                targetPosition = transform.forward;
                break;
        }
    }

    void Update()
    {
        if (currentState != previousState)
        {
            OnStateChange();
        }

        switch (currentState)
        {
            case STATES.IDLE:
                break;

            case STATES.PENDING:
                if (Agent.remainingDistance <= 0.1f)
                {
                    ChangeState(STATES.DECISION);
                }
                break;

            case STATES.WALKING:
                Agent.isStopped = false;
                Agent.SetDestination(transform.position + targetPosition);
                break;

            case STATES.DECISION:
                Debug.Log(decisionTimer);
                decisionTimer -= Time.deltaTime;
                //if there's an open path forward, left, or right
                if (CanWalkTowards())
                {
                    currentState = STATES.WALKING;
                }

                //else go backwards
                if (decisionTimer <= 0f)
                {
                    targetPosition = -targetPosition;
                    currentState = STATES.WALKING;
                }
                break;
        }
        //state changes and checks happen here

    }
}
