using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;
using static AgentController;

public class AgentController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent Agent;
    [SerializeField] private string decisionTag;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private DIR initialDirection;

    [SerializeField] private float raycastRange = 8f;
    [SerializeField] private float movementSpeed = 1.5f;
    [SerializeField] private float decisionTime = 5f;


    public enum STATES
    {
        WALKING,
        DECISION,
        PENDING
    }

    public enum DIR
    {
        front,
        right,
        left,
        back
    }

    STATES currentState = STATES.WALKING;
    STATES previousState;

    DIR targetDirection;

    Vector3 targetPosition;

    private float decisionTimer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == decisionTag)
        {
            Debug.Log("in decision area ");
            currentState = STATES.DECISION;
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

            case STATES.IDLE:

                break;
        }
        previousState = currentState;
    }

    private bool CanWalkTowards()
    {
        Vector3 reverseDirection = -targetPosition;

        Vector3[] checkDirections = { transform.forward, transform.right, -transform.right, -transform.forward };
        

        foreach (Vector3 d in checkDirections)
        {
            if (d != reverseDirection)
            {
                RaycastHit hit;
                if (!Physics.Raycast(transform.position, d, out hit, raycastRange, obstacleLayer))
                {
                    Debug.Log("the direction " + d.ToString() + " is empty, moving towards that");
                    targetPosition = d;
                    return true;
                }
            }
        }

        return false;
    }
    private void Start()
    {
        previousState = currentState;
        targetPosition = transform.forward;
    }

    void Update()
    {
        Debug.Log(currentState.ToString());
        if (currentState != previousState)
        {
            OnStateChange();
        }

        switch (currentState)
        {
            case STATES.IDLE:

                break;

            case STATES.WALKING:
                Agent.isStopped = false;
                Agent.Move(targetPosition * Time.deltaTime * movementSpeed);

                break;

            case STATES.DECISION:
                decisionTimer -= Time.deltaTime;
                if (CanWalkTowards())
                {
                    Debug.Log("switching to walking");
                    currentState = STATES.WALKING;
                }

                if (decisionTimer <= 0f)
                {
                    targetPosition = -targetPosition;
                    currentState = STATES.WALKING;
                }
                break;
        }
    }

    //state changes and checks happen here

}
