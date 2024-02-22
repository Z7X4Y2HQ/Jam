using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    private PlayerInput PlayerInput;
    private string input;
    private new Transform camera;
    private bool isCrouched = false;
    private Vector2 currentMovementInput;
    private Vector3 currentMovement;
    private Vector3 moveDirection;

    private float verticalVelocity = 0.0f;
    public float gravity = 9.8f;


    private void Awake()
    {
        PlayerInput = new PlayerInput();
        // PlayerInput.Movement.Move.performed += CharacterMovementStart;
        PlayerInput.Player.Move.performed += diagonalMovementBS;
        // PlayerInput.Movement.Move.canceled += CharacterMovementStop;
    }
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        camera = GameObject.Find("Main Camera").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isCrouched)
        {
            isCrouched = true;
            HandleAnimatorState();
            animator.SetBool("isCrouched", true);
        }
        else if (Input.GetKeyDown(KeyCode.C) && isCrouched)
        {
            isCrouched = false;
            HandleAnimatorState();
            animator.SetBool("isCrouched", false);
        }

        if (!isCrouched)
        {
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isWalkForward", true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isWalkBackward", true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("isWalkLeft", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("isWalkRight", true);
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetBool("isWalkForward", false);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                animator.SetBool("isWalkBackward", false);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                animator.SetBool("isWalkLeft", false);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("isWalkRight", false);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isWalkForwardCrouched", true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isWalkBackwardCrouched", true);
                animator.SetLayerWeight(1, 1);
            }
            // else if (Input.GetKeyDown(KeyCode.A))
            // {
            //     animator.SetBool("isWalkLeft", true);
            // }
            // else if (Input.GetKeyDown(KeyCode.D))
            // {
            //     animator.SetBool("isWalkRight", true);
            // }

            if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetBool("isWalkForwardCrouched", false);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                animator.SetBool("isWalkBackwardCrouched", false);
                animator.SetLayerWeight(1, 0);
            }
            // else if (Input.GetKeyUp(KeyCode.A))
            // {
            //     animator.SetBool("isWalkLeft", false);
            // }
            // else if (Input.GetKeyUp(KeyCode.D))
            // {
            //     animator.SetBool("isWalkRight", false);
            // }
        }

        if (!Input.anyKey)
        {
            HandleAnimatorState();
        }

        if ((Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) || (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))))
        {
            Vector3 cameraForward = camera.forward;
            Vector3 cameraRight = camera.right;
            cameraForward.y = 0f;
            cameraRight.y = 0f;
            cameraForward = cameraForward.normalized;
            cameraRight = cameraRight.normalized;
            moveDirection = cameraForward * currentMovementInput.y + cameraRight * currentMovementInput.x;
            characterController.Move(moveDirection * Time.deltaTime * 1.5f);
        }

        HandleRotation();

    }

    void diagonalMovementBS(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
    }
    private void CharacterMovementStart(InputAction.CallbackContext context)
    {
        input = context.control.displayName;

        Debug.Log("Start" + context);

        switch (input)
        {
            case "W":
                animator.SetBool("isWalkForward", true);
                break;
            case "S":
                animator.SetBool("isWalkBackward", true);
                break;
            case "A":
                animator.SetBool("isWalkLeft", true);
                break;
            case "D":
                animator.SetBool("isWalkRight", true);
                break;
            default:
                break;
        }
    }

    private void CharacterMovementStop(InputAction.CallbackContext context)
    {
        Debug.Log("Stop" + context);
        switch (input)
        {
            case "W":
                animator.SetBool("isWalkForward", false);
                break;
            case "S":
                animator.SetBool("isWalkBackward", false);
                break;
            case "A":
                animator.SetBool("isWalkLeft", false);
                break;
            case "D":
                animator.SetBool("isWalkRight", false);
                break;
            default:
                break;
        }

    }

    void HandleGravity()
    {
        if (characterController.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        UnityEngine.Vector3 moveVector = new UnityEngine.Vector3(0, verticalVelocity, 0);
        characterController.Move(moveVector * Time.deltaTime);
    }

    void HandleRotation()
    {
        UnityEngine.Vector3 cameraForward = camera.forward;
        UnityEngine.Vector3 cameraRight = camera.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        UnityEngine.Quaternion targetRotation = UnityEngine.Quaternion.LookRotation(cameraForward);
        transform.rotation = UnityEngine.Quaternion.Slerp(transform.rotation, targetRotation, 3.4f * Time.deltaTime);
    }

    void HandleAnimatorState()
    {
        animator.SetBool("isWalkBackward", false);
        animator.SetBool("isWalkForward", false);
        animator.SetBool("isWalkRight", false);
        animator.SetBool("isWalkLeft", false);
        animator.SetBool("isWalkBackwardCrouched", false);
        animator.SetBool("isWalkForwardCrouched", false);
    }



    void OnEnable()
    {
        PlayerInput.Player.Enable();
    }
    void OnDisable()
    {
        PlayerInput.Player.Disable();
    }
}
