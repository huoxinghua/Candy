using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : Npc,IInteractable
{
    private CookMachine cookMachine;
    private CandyDevourer candyDevourer;
    private  CityEntrance cityEntrance;
    private PlayerController player;
    private AIEnemy enemy;
 

    private void Start()
    {
        //set default material 
      
       // Debug.Log("start material" + childRenderer.material);
        //childRenderer.material = humanMaterial;
    }
    public void ChangeToHuman()
    {
        childRenderer.material = humanMaterial;
    }
    public override void Interact()
    {
        Debug.Log("player interact"+ childRenderer.material);
        //childRenderer = gameObject.GetComponent<Renderer>();
        childRenderer.material = humanMaterial;
    }
}
