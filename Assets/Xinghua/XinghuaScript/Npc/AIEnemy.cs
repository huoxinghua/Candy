using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : Npc, IInteractable
{
    private CookMachine cookMachine;
    private CandyDevourer candyDevourer;
    private  CityEntrance cityEntrance;
    private PlayerController player;
    private AIEnemy enemy;
 

    private void Start()
    {
        //set default material 
        childRenderer = gameObject.GetComponent<Renderer>();
        childRenderer.material = humanMaterial; 
       
    }
    public void ChangeToHuman()
    {
        
        childRenderer = gameObject.GetComponent<Renderer>();
        childRenderer.material = humanMaterial;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HumanNormal>())
        {
            //transfer people
            var humanNormal = other.gameObject.GetComponent<HumanNormal>();
            if (humanNormal != null)
            {
                humanNormal.ChangeToEnemy(); 
            }
        }
        else if(other.gameObject.GetComponent<CookMachine>())
        {
            //cook machine damage
            cookMachine = other.gameObject.GetComponent<CookMachine>();
            cookMachine.CookMachineDamaged();
        }
        else if (other.gameObject.GetComponent<CandyDevourer>())
        {
            //boss damage
            candyDevourer = other.gameObject.GetComponent<CandyDevourer>();
            candyDevourer.CandyDevourerDamaged();
        }
        else if (other.gameObject.GetComponent<CityEntrance>())
        {
            cityEntrance = other.gameObject.GetComponent<CityEntrance>();
            cityEntrance.Interact();
        }
        // enemy_ zombie will be change to human by player
        else if (other.gameObject.GetComponent<PlayerController>())
        {
           
            var interactor = other.gameObject.GetComponent<Interactor>();
            if (interactor.isInteract)
            {
                childRenderer.material = humanMaterial;
            }
          
        }
        else if(other.GetComponent<AIEnemy>())
        {
            var AIenemy = other.gameObject.GetComponent<AIEnemy>();
            //avoid
        }
    }



}
