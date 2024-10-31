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
    protected bool isInteracted;
    private void Start()
    {
       
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

    
}
