using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{
    //input fields
    private ThirdPersonActionsAsset playerActionsAsset;
    private InputAction move;

    //movement fields
    private Rigidbody rb;
    [SerializeField]
    private float movementForce = 1f;
    [SerializeField]
    private float maxSpeed = 3.5f;
    private Vector3 forceDirection = Vector3.zero;

    //camera fields
    [SerializeField]
    private Camera playerCamera;
    private Animator animator;

    private void Awake()
    {
        //
        rb = this.GetComponent<Rigidbody>();
        playerActionsAsset = new ThirdPersonActionsAsset();
        animator = this.GetComponent<Animator>();
        
        // Pause logic
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnEnable()
    {
        //playerActionsAsset.OverWorldPlayer.Jump.started += DoJump;
        playerActionsAsset.OverWorldPlayer.Attack.started += DoAttack;
        move = playerActionsAsset.OverWorldPlayer.Move;
        playerActionsAsset.OverWorldPlayer.Enable();
    }

    private void OnDisable()
    {
        //playerActionsAsset.OverWorldPlayer.Jump.started -= DoJump;
        playerActionsAsset.OverWorldPlayer.Attack.started -= DoAttack;
        playerActionsAsset.OverWorldPlayer.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 moveValue = move.ReadValue<Vector2>();
        forceDirection += moveValue.x * GetCameraRight(playerCamera) * movementForce;
        forceDirection += moveValue.y * GetCameraForward(playerCamera) * movementForce;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if (rb.velocity.y < 0f)
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;
        
        LookAt();
    }

    private void LookAt()
    {   
        Vector3 direction = rb.velocity;
        direction.y = 0f;
        
        if (move.ReadValue<Vector2>().sqrMagnitude > 0.01f && direction.sqrMagnitude > 0.01f)
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            rb.angularVelocity = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    /*private void DoJump(InputAction.CallbackContext obj)
    {
        if(IsGrounded())
        {
            forceDirection += Vector3.up * jumpForce;
        }
    }*/

    //Creates a sphere and checks for ground
    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
            return true;
        else
            return false; 
    }

    private void DoAttack(InputAction.CallbackContext obj)
    {
        animator.SetTrigger("attack");
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }
}