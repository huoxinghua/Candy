using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class Interactor : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] LayerMask interactableLayer;
    private bool isNearbyInteractable = false;
    [SerializeField] private int radius = 4;
    private Collider[] colliders;
    private float interactionCooldown = 10f; 
    private float lastInteractionTime = 0f; 

    private void FixedUpdate()
    {
        EnemyInteract();
    }
    private bool CheckForInteractable()
    {

        colliders = Physics.OverlapSphere(transform.position, radius, interactableLayer);
        isNearbyInteractable = colliders.Length > 0;
        return isNearbyInteractable;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;  // Choose the color for the Gizmo
        Gizmos.DrawWireSphere(transform.position, radius);  // Draw a wireframe sphere at the object's position with the set radius
    }


    public void EnemyInteract()
    {
        
        if (!CheckForInteractable()) return;  

       
        if (Time.time - lastInteractionTime < interactionCooldown) return;
        foreach (Collider collider in colliders)
        {
            var interactor = collider.transform.GetComponent<IInteractable>();

            if (collider.gameObject.GetComponent<CookMachine>())
            {
                //cook machine damage
                var cookMachine = collider.gameObject.GetComponent<CookMachine>();
                cookMachine.CookMachineDamaged();
            }
            if (collider.gameObject.GetComponent<HumanNormal>()&& CompareTag("Enemy"))
            {
                //cook machine damage
                var human = collider.gameObject.GetComponent<HumanNormal>();
                human.ChangeToEnemy();
            }
            else if (collider.gameObject.GetComponent<CandyDevourer>())
            {
                //boss damage
                var candyDevourer = collider.gameObject.GetComponent<CandyDevourer>();
                candyDevourer.CandyDevourerDamaged();
            }
            else if (collider.gameObject.GetComponent<CityEntrance>())
            {
                var cityEntrance = collider.gameObject.GetComponent<CityEntrance>();
                cityEntrance.Interact();
            }
           
        }
        lastInteractionTime = Time.time;

    }
    public void PlayerTryInteract()
    {
        Debug.Log("player interact");
      

       
        if (CheckForInteractable())
        {
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.GetComponent<HumanNormal>()) return;
                var interactor = collider.transform.GetComponent<IInteractable>();
                Debug.Log("interactor" + interactor);
                if (interactor != null && !collider.gameObject.GetComponentInChildren<HumanNormal>())
                {
                     interactor.Interact();
                }
                else
                {
                    Debug.Log("not find the Interactable");
                }
            }
        
       }


    }
}


