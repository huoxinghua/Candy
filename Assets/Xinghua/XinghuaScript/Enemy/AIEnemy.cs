using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform target;
    Rigidbody rb;
    private void Start()
    {
        EnemyMove();
    }
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        EnemyMove();

    }
 
    private void EnemyMove()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        if (target != null)
        {
            agent.SetDestination(target.position);
           // agent.stoppingDistance = 0.01f;
        }
        else
        {
            Debug.LogError("no target");
        }
    }
}
