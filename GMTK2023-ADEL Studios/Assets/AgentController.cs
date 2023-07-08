using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    [SerializeField] private Transform targetDirection;
    [SerializeField] private NavMeshAgent Agent;
    [SerializeField] private string decisionTag;
    [SerializeField] private string obstacleTag;
    [SerializeField] private Transform agentTransform;
    [SerializeField] private Transform directionTransform;

    [SerializeField] private float raycastRange = 8f;

    [SerializeField] private float decisionTime = 5f;

    public enum STATES
    {
        WALKING,
        DECISION,
        IDLE
    }

    STATES currentState = STATES.WALKING;
    STATES previousState;

    Vector3 targetPosition;

    private float decisionTimer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == decisionTag)
        {
            Debug.Log("in decision area ");
            currentState = STATES.DECISION;
        }
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

    private void RotateAgentDirection(float degrees)
    {
        Vector3 rotationAxis = Agent.transform.up;
        transform.RotateAround(Agent.transform.position, rotationAxis, degrees);
    }

    private bool CanWalkTowards(Vector3 direction)
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, direction, Color.blue, 5f);
        if (Physics.Raycast(transform.position, direction, out hit, raycastRange))
        {
            if (hit.transform.tag == obstacleTag)
            {
                //if there's an obstacle in this path;
                Debug.Log("there's an obstacle");
                return false;
            }
        }
        //if no obstacle then go towards this
        Debug.Log("No obstacles, turning towards a direction");
        Debug.DrawRay(transform.position, direction, Color.red, 5f);

        return true;
    }
    private void Start()
    {
        previousState = currentState;
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
                Vector3 targetPosition = targetDirection.position;
                Agent.SetDestination(targetPosition);

                break;

            case STATES.DECISION:
                decisionTimer -= Time.deltaTime;
                if (CanWalkTowards(transform.forward))
                {
                    currentState = STATES.WALKING;
                }
                else if (CanWalkTowards(transform.right))
                {
                    RotateAgentDirection(90f);
                    currentState = STATES.WALKING;
                }
                else if (CanWalkTowards(-1 * transform.right))
                {
                    RotateAgentDirection(-90f);
                    currentState = STATES.WALKING;
                }

                if (decisionTimer <= 0f)
                {
                    RotateAgentDirection(180f);
                    currentState = STATES.WALKING;
                }
                break;
        }
    }

    //state changes and checks happen here

}
