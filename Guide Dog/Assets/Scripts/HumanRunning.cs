using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class HumanRunning : MonoBehaviour
{

    NavMeshAgent agent;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent.enabled == true)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {

        }
        
    }
}
