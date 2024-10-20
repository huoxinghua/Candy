using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    private PlayerInput playerInput;
    private Vector3 movement;
    private float movementX;
    private float movementY;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpHeight;
    bool isGrounded;
    [SerializeField] private float sensitivityX = 1f;  
    [SerializeField] private float sensitivityY = 1f;  
    [SerializeField] LayerMask interactableLayer;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints =RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
       //Vector3 movement = new Vector3(movementX, 0.0f, movementY);
     
        rb.velocity = movement * moveSpeed;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        if (movement != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), moveSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.PlayerControl.Move.performed += OnMove;
        playerInput.PlayerControl.Interact.performed += OnInteract;
        //playerInput.PlayerControl.Look.performed += OnLook;
        playerInput.PlayerControl.Jump.canceled += OnJump;
    }

    private void OnDisable()
    {
        playerInput.Disable();
        playerInput.PlayerControl.Move.canceled -= OnMove;
        playerInput.PlayerControl.Jump.canceled -= OnJump;
        playerInput.PlayerControl.Look.performed -= OnLook;
    }

    // ctx input behavior need use Invoke unity envents
    private void OnMove(InputAction.CallbackContext ctx)
    {
         Vector2 movementVector = ctx.ReadValue<Vector2>();
         Vector3 forward = Camera.main.transform.forward;
        forward.y = 0;
        Vector3 right = Camera.main.transform.right;
        right.y = 0;
        movement = forward.normalized * movementVector.y + right.normalized * movementVector.x;
    }

    private void OnInteract(InputAction.CallbackContext ctx)
    {

        TryInteract();
    }

    private void TryInteract()
    {
       
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 12f, interactableLayer))
        {
            var interactor = hit.transform.GetComponent<IInteractable>();

            if (interactor != null)
            {
                Debug.Log("get Ekey");
                interactor.Interact();
            }
            
        }
    }
    

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpHeight,ForceMode.Impulse);
            Debug.Log("on jump" + rb.velocity);
            //rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
            Debug.Log("on jump after" + rb.velocity);
        }
    }
    public void OnLook(InputAction.CallbackContext ctx)
    {
        Vector2 lookVector = ctx.ReadValue<Vector2>();
        float mouseX = lookVector.x * sensitivityX;  // Horizontal rotation
        float mouseY = lookVector.y * sensitivityY;  // Vertical rotation
        // Rotate player body horizontally
        this.transform.Rotate(Vector3.up * mouseX);

    }
}
