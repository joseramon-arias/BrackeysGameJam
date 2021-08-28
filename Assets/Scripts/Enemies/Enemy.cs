using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    protected NavMeshAgent agent;
    protected GameObject player;
    private bool moveStatus = true;
    private bool hasMoveStatusActivated;
    protected Health slimeHealth;
    [SerializeField] protected GoldSpawner goldSpawner;

    public bool MoveStatus 
    { 
        get { return moveStatus; }
        set { moveStatus = value; }
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        slimeHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    virtual public void Update()
    {
        // moveStatus is modified from another script only for the enemies that need it
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

    protected void CheckForDeath()
    {
        if (slimeHealth.CurrentHealth <= 0 )
        {
            goldSpawner.SpawnGold();
            Destroy(gameObject);
        }
    }
}
