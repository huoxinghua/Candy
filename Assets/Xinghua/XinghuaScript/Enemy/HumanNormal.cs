using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanNormal : MonoBehaviour
{
    [SerializeField] Transform patrolLocation;
    private NavMeshAgent agent;
    private void Start()
    {
        HumanMove();
    }
    private void HumanMove()
    {
        agent =gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(patrolLocation.position);

    }
}
