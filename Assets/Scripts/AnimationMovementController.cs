using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationMovementController : MonoBehaviour
{
    PlayerInput PlayerInput;
    CharacterController characterController;
    public static Animator animator;
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;
    float rotationFactorPerFrame = 7f;
    int isWalkHash;
    public Transform mainCamera;
    Vector3 moveDirection;
    public float gravity = 9.8f;
    private float verticalVelocity = 0.0f;

    void Awake()
    {
        PlayerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        isWalkHash = Animator.StringToHash("isWalk");

        PlayerInput.Player.Move.started += onMovementInput;
        PlayerInput.Player.Move.performed += onMovementInput;
        PlayerInput.Player.Move.canceled += onMovementInput;
    }

    void Update()
    {
        handleGravity();
        handleAnimation();
        handleRotation();

        if (isMovementPressed)
        {
            characterController.Move(moveDirection * Time.deltaTime * 1.5f);
        }
    }

    void handleGravity()
    {
        if (characterController.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        characterController.Move(moveVector * Time.deltaTime);
    }

    void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void handleRotation()
    {
        Vector3 cameraForward = mainCamera.forward;
        Vector3 cameraRight = mainCamera.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        moveDirection = cameraForward * currentMovement.z + cameraRight * currentMovement.x;

        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }
    }



    void handleAnimation()
    {
        bool isWalk = animator.GetBool(isWalkHash);

        if (isMovementPressed && !isWalk)
        {
            animator.SetBool(isWalkHash, true);
        }
        else if (!isMovementPressed && isWalk)
        {
            animator.SetBool(isWalkHash, false);
        }
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
