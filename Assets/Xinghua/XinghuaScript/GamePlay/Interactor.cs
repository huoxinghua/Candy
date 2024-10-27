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
    private int radius = 2;
    public bool isInteract;
 
    private void Awake()
    {
        isInteract = false;
        playerInput = new PlayerInput();
    }
    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.PlayerControl.Interact.performed += OnInteract;
    }

    private void OnDisable()
    {
        playerInput.PlayerControl.Interact.canceled -= OnInteract;
       
    }
    private void Update()
    {
        CheckForInteractable();
    }
    private void OnInteract(InputAction.CallbackContext ctx)
    {
       
        if (isNearbyInteractable)
        {
            TryInteract();

        }
    }
    private void CheckForInteractable()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, interactableLayer);
        isNearbyInteractable = colliders.Length > 0;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;  // Choose the color for the Gizmo
        Gizmos.DrawWireSphere(transform.position, radius);  // Draw a wireframe sphere at the object's position with the set radius
    }

    private void TryInteract()
    {
      
        int radius = 12;
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, interactableLayer);
       foreach (Collider collider in colliders) 
        {
            var interactor = collider.transform.GetComponent<IInteractable>();
          
            if (interactor != null)
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
