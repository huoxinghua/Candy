using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanNormal : Npc,IInteractable
{
    [SerializeField] private Material humanMaterial;
    [SerializeField] private Material enemyMaterial;
    [SerializeField] private Transform newTarget;
    [SerializeField] private Renderer childRenderer;
    
    private Renderer render;
    Npc npc;
    private void Start()
    {
        //render = gameObject.transform.Find("FatHuman04").gameObject.GetComponentInChildren<Renderer>();//  .GetComponent<Renderer>();
        ///render.materials[0] = enemyMaterial;
        childRenderer.material = enemyMaterial;
        npc = gameObject.GetComponent<Npc>();
        HunmanMove();
    }

    public void ChangeCloth()
    {
        childRenderer.material = humanMaterial;
    }
    public void BeenChanged()
    {
        childRenderer.material = enemyMaterial;
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
