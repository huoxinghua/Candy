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
    public NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

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

    public void EnemyMove(GameObject value)
    {
        //value = GameObject.Find("CookMachine");
        agent.SetDestination(value.transform.position);
   
    }
}
