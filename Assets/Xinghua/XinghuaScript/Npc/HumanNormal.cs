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
    [SerializeField] private Animator animator;
    private void Start()
    {
        // the render is for the human be changed by zombin and can also changed back by King
       // childRenderer =gameObject.GetComponent<Renderer>();
      //  npc = gameObject.GetComponent<Npc>();
        agent = GetComponent<NavMeshAgent>();
        if (animator != null)
        {
            animator.SetBool("isWalking", false);
        }
        
    }

    public void ChangeToHuman()
    {
        Debug.Log("change to human");
        childRenderer.material = humanMaterial;
    }

    public void ChangeToEnemy()
    {
        Debug.Log("change to enemy");
        Destroy(this);
        if (this.gameObject.GetComponent<AIEnemy>() == null)
        {
            var enemyscript = this.gameObject.AddComponent<AIEnemy>();
            enemyscript.GetComponent<Renderer>();
            if (childRenderer.material != null)
            {
                childRenderer.material = enemyMaterial;
            }
            else
            {
                childRenderer = gameObject.AddComponent<Renderer>();
            }
            if (animator != null)
            {
                animator.SetBool("isWalking", true);
            }
        }
        
        agent.SetDestination(EnemyManager.Instance.boss.transform.position);
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
            for (int i = 0;i< targets.Length;i++)
            {
                agent.SetDestination(targets[0].transform.position);
                //agent.stoppingDistance = 0.2f;
            }

        }
        else
        {
            Debug.LogError("no target");
        }
    }
}
