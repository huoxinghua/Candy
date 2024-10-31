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
    private Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Debug.Log("Animator is" + animator);
       // animator.SetBool("isHumanChanged", true);


    }
    public void ChangeToHuman()
    {
        childRenderer.material = humanMaterial;
    }
    public override void Interact()
    {
        //the is for player interact. player can use candy to change enemy back to human
        if (Inventory.Instance.collectedItems.ContainsKey("Candy") && Inventory.Instance.collectedItems["Candy"] >= 1 )
        {
            Destroy(this);
            this.gameObject.AddComponent<HumanNormal>();
            childRenderer.material = humanMaterial;
            animator.SetBool("isHumanChanged", true);


            Inventory.Instance.RemoveItem("Candy", 1);
        }
        else
        { 
            UIManager.Instance.ShowCandyHealUI();
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
        Debug.Log("Move enemy");
        //value = GameObject.Find("CookMachine");
        agent.SetDestination(value.transform.position);

    }
}
