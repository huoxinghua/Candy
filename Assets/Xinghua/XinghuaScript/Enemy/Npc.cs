using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{
    protected NavMeshAgent agent;
    [SerializeField] private Transform target;
    Rigidbody rb;
    private void Start()
    {
       
    }
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        NpcMove();

    }
 
    public void NpcMove()
    {
      
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        if (target != null)
        {
            agent.SetDestination(target.position);
            agent.stoppingDistance = 0.2f;
        }
        else
        {
            Debug.LogError("no target");
        }
    }
}
