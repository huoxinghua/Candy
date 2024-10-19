using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform target;
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

        if (target != null)
        {
            agent.SetDestination(target.position);
            agent.stoppingDistance = 0.1f;
        }
        else
        {
            Debug.LogError("no target");
        }
    }
}
