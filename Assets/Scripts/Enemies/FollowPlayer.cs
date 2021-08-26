using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    bool moveStatus = true;
    bool hasMoveStatusActivated;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (moveStatus)
        {
            agent.SetDestination(player.transform.position);
            if (!hasMoveStatusActivated)
            {
                agent.isStopped = false;
                hasMoveStatusActivated = true;
            }
            
        }
        else
        {
            agent.isStopped = true;
            hasMoveStatusActivated = false;
        }
            
    }

    public void MovementStatus(bool status)
    {
        moveStatus = status;
    }
}
