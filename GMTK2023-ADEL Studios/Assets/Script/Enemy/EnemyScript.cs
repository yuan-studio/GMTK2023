using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject agent;
    [SerializeField] private bool isBlind = false;
    [SerializeField] private float sightRange = 15f;
    [SerializeField] private float sightAngle = 45f;


    public void setBlind(bool b)
    {
        isBlind = b;
    }

    
    void Update()
    {
        if (Vector3.Distance(agent.transform.position, transform.position) <= sightRange && !isBlind)
        {
            if (Vector3.Angle(transform.forward, (agent.transform.position - transform.position)) <= sightAngle)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (agent.transform.position - transform.position), out hit, sightRange))
                {
                    if (hit.transform.CompareTag("Agent"))
                    {
                        Debug.Log("Seeing agent");
                    }
                }
            }
        }
    }
}
