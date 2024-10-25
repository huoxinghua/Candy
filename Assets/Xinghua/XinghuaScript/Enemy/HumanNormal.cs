using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanNormal : Npc,IInteractable
{
    [SerializeField] private Material humanMaterial;
    [SerializeField] private Material enemyMaterial;
    [SerializeField] private Transform newTarget;
    
    private Renderer render;
    Npc npc;
    private void Start()
    {
        render = gameObject.GetComponent<Renderer>();
        npc = gameObject.GetComponent<Npc>();
        HunmanMove();
    }

    public void ChangeCloth()
    {
        render.material = humanMaterial;
    }
    public void BeenChanged()
    {
        render.material = enemyMaterial;
        Destroy(this);
        if (this.gameObject.GetComponent<AIEnemy>() == null)
        {
            this.gameObject.AddComponent<AIEnemy>();
        }

        agent.SetDestination(newTarget.position);
    }

    private void HunmanMove()
    {
        npc.NpcMove();
    }
    public void Interact()
    {
        Debug.Log("change enemy look");
        ChangeCloth();
    }
    public void ShowKeyToInteract()
    {

    }




}
