using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanNormal : Npc,IInteractable
{
 
    [SerializeField] private Transform newTarget;
    Npc npc;
    [SerializeField] private GameObject[] targets;
    public NavMeshAgent agent;
    private void Start()
    {
        // the render is for the human be changed by zombin and can also changed back by King
       // childRenderer.material = humanMaterial;
      //  npc = gameObject.GetComponent<Npc>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void ChangeToHuman()
    {
        Debug.Log("change to human");
        childRenderer.material = humanMaterial;
    }

    public void ChangeToEnemy()
    {
        Destroy(this);
        if (this.gameObject.GetComponent<AIEnemy>() == null)
        {
            var enemyscript = this.gameObject.AddComponent<AIEnemy>();
            enemyscript.GetComponent<Renderer>();
            childRenderer.material = enemyMaterial;
        }
        
        agent.SetDestination(newTarget.position);
    }
 
    private void HunmanMove()
    {
        HumanMove();
    }
    public void HumanMove()
    {
        agent = GetComponent<NavMeshAgent>();

        if (targets != null && targets.Length > 0)
        {
            agent.SetDestination(targets[0].transform.position);
            //agent.stoppingDistance = 0.2f;
        }
        else
        {
            Debug.LogError("no target");
        }
    }
}
