using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour,IInteractable
{
    [SerializeField] protected Renderer childRenderer;
    [SerializeField] protected Material humanMaterial;
    [SerializeField] protected Material enemyMaterial;
    protected Material defaultMaterial;
    protected NavMeshAgent agent;
    [SerializeField] protected GameObject target;
    Rigidbody rb;

    protected bool isInteracted;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        childRenderer = GetComponent<Renderer>();
        childRenderer.material = defaultMaterial;
     
        //SetMaterial(defaultMaterial);
        isInteracted = false;
    }

    public void SetIfInteract(bool newInteractValue)
    {
        isInteracted = newInteractValue;
    }
    public void SetMaterial(Material material)
    {

        childRenderer = gameObject.GetComponent<Renderer>();
        childRenderer.material = material;
    }
    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
        NpcMove();

    }
  
    public void ShowKeyToInteract()
    {

    }
    public void ChangeEnemy()
    {
        defaultMaterial = enemyMaterial;
    }
    public virtual void Interact()
    {
           // Debug.Log("change npc look");
    }

    public void NpcMove()
    {
      
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        if (target != null)
        {
            agent.SetDestination(target.transform.position);
            //agent.stoppingDistance = 0.2f;
        }
        else
        {
            Debug.LogError("no target");
        }
    }
}