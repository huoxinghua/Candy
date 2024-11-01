using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    private PlayerInput playerInput;
    private Vector3 targetMovement;
  
    private float movementX;
    private float movementY;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpHeight;
    bool isGrounded;
   //[SerializeField] private float sensitivityX = 1f;  
   // [SerializeField] private float sensitivityY = 1f;  
    private bool isTopView;
   // [SerializeField] LayerMask interactableLayer;
    private Animator animator;

    [SerializeField] private GameObject topCamera;
    [SerializeField] private GameObject followCamera;
    private bool isFollowCamera;
    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints =RigidbodyConstraints.FreezeRotation;
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("isWalking",false);
        isFollowCamera = true;
        isTopView = false;
    }
    private void Update()
    {
        HandleAninaton();
    }

    private void HandleAninaton()
    {
        var velocity = rb.velocity;
        if (velocity.magnitude > 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else { animator.SetBool("isWalking", false); }
    }
    void FixedUpdate()
    {
       //Vector3 movement = new Vector3(movementX, 0.0f, movementY);
     
        rb.velocity = targetMovement * moveSpeed;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        if (targetMovement != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetMovement), moveSpeed * Time.deltaTime);

    }

    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.PlayerControl.Move.performed += OnMove;
        playerInput.PlayerControl.CameraSwitch.performed += TopCameraSwitch;
        playerInput.PlayerControl.Interact.performed += OnInteract;
        playerInput.PlayerControl.Pause.performed += OnShowPauseMenu;
    }

    private void OnDisable()
    {
        playerInput.Disable();
        playerInput.PlayerControl.Move.canceled -= OnMove;
        playerInput.PlayerControl.CameraSwitch.performed -= TopCameraSwitch;
        playerInput.PlayerControl.Interact.performed -= OnInteract;
        playerInput.PlayerControl.Pause.performed += OnShowPauseMenu;

    }

    // ctx input behavior need use Invoke unity envents
    private void OnMove(InputAction.CallbackContext ctx)
    {
         Vector2 movementVector = ctx.ReadValue<Vector2>();
         Vector3 forward = Camera.main.transform.forward;
        forward.y = 0;
        Vector3 right = Camera.main.transform.right;
        right.y = 0;

        targetMovement = forward.normalized * movementVector.y + right.normalized * movementVector.x;
      
    }
    private void OnShowPauseMenu(InputAction.CallbackContext ctx)
    {
        UIManager.Instance.pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    private void OnInteract(InputAction.CallbackContext ctx)
    {
         var interactor = gameObject.GetComponent<Interactor>();
         interactor.PlayerTryInteract();
    }

    private void TopCameraSwitch(InputAction.CallbackContext ctx)
    {
        
        if(isTopView)
        {
            CameraManager.Instance.ActiveSoloCamera(followCamera);
            isTopView = false;
            isFollowCamera=true;
            CameraManager.Instance.isAlarmView = false;
        }
        else if (isFollowCamera)
        {
            CameraManager.Instance.ActiveSoloCamera(topCamera);
            isFollowCamera = false;
            isTopView= true;
            CameraManager.Instance.isAlarmView = false;
        }
        else if (CameraManager.Instance.isAlarmView)
        {
            CameraManager.Instance.ActiveSoloCamera(followCamera);
            isTopView = false;
            isFollowCamera=true;
            CameraManager.Instance.isAlarmView =false;
        }
     
    }
}
