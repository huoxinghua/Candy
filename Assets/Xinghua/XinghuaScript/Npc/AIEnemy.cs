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
        
        bool a = Inventory.Instance.collectedItems.ContainsKey("Candy");
        bool b = Inventory.Instance.collectedItems["Candy"] >= 1;
        HumanNormal human = gameObject.GetComponent<HumanNormal>();
        Debug.Log("a and b "+ a+b);
        if (Inventory.Instance.collectedItems.ContainsKey("Candy") && Inventory.Instance.collectedItems["Candy"] >= 1 )
        {
            childRenderer.material = humanMaterial;
            Inventory.Instance.RemoveItem("Candy", 1);
        }
        else
        { 
            UIManager.Instance.candyHealPeople.SetActive(true);
            StartCoroutine(HideCandyHealPeopleAfterDelay());
            //Show Ui you need more candy
        }
    }

    private IEnumerator HideCandyHealPeopleAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        UIManager.Instance.candyHealPeople.SetActive(false);
    }

    public void EnemyMove(GameObject value)
    {
        //value = GameObject.Find("CookMachine");
        agent.SetDestination(value.transform.position);
   
    }
}
