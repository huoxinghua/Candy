using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanNormal : Npc,IInteractable
{
 
    [SerializeField] private Transform newTarget;
    Npc npc;
   
    private void Start()
    {
        // the render is for the human be changed by zombin and can also changed back by King
        childRenderer.material = humanMaterial;
        npc = gameObject.GetComponent<Npc>();
        HunmanMove();
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
           // Debug.Log("render" + enemyscript.GetComponent<Renderer>());
            childRenderer.material = enemyMaterial;
        }
        
        agent.SetDestination(newTarget.position);
    }
 
    private void HunmanMove()
    {
        npc.NpcMove();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<AIEnemy>())
        {
            ChangeToEnemy();
            childRenderer.material = enemyMaterial;
        }
    }
}
