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
            targetPosition = other.gameObject.transform.position;
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
                Agent.SetDestination(targetPosition);
                decisionTimer = decisionTime;
                break;

            case STATES.IDLE:

                break;
        }
        previousState = currentState;
    }

    private void CanWalkTowards(Vector3 direction)
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, direction, Color.blue, 5f);
        if (Physics.Raycast(transform.position, direction, out hit, raycastRange))
        {
            if (hit.transform.tag == obstacleTag)
            {
                //if there's an obstacle in this path;
                Debug.LogError("there's an obstacle");
                return;
            }
        }
        //if no obstacle then go towards this
        Quaternion targetDirection = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetDirection, Agent.angularSpeed * Time.deltaTime);

        currentState = STATES.WALKING;
    }
    private void Start()
    {
        previousState = currentState;
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

            case STATES.WALKING:
                Agent.isStopped = false;
                Vector3 targetPosition = transform.position + (transform.forward * 2f);
                Agent.SetDestination(targetPosition);

                break;

            case STATES.DECISION:
                decisionTimer -= Time.deltaTime;
                if (Agent.remainingDistance <= 0.1f)
                {
                    CanWalkTowards(transform.forward);
                }
                
                if (decisionTimer <= 0f)
                {
                    currentState = STATES.WALKING;
                }
                break;
        }
    }

    //state changes and checks happen here

}
