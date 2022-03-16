using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Singleton
    public static PlayerController Instance;

    // Variables for the movement
   //[Header("movement variables")]
   //[SerializeField] public float rotationSpeed = 1500.0f;
   //[SerializeField] public float moveSpeed = 2.0f;

    private Vector2 movement;
    private Pole[] poles;
    private GameObject arrow;
    protected int currentPoleIndex;

    //public bool lockedDownPressed = false;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void FixedUpdate()
    {
        poles[currentPoleIndex].Move(movement * Time.deltaTime);
        poles[currentPoleIndex].PoleLockedDown();
    }

    // when a new player joins he receives an array of poles + an arrow to see which pole is selected
    internal void ReceivePoles(Pole[] poles)
    {
        this.poles = poles;
    }

    internal void ReceiveArrow(GameObject gO)
    {
        arrow = gO;
    }

    #region Input System Events
    public void OnMove(InputAction.CallbackContext context)
    {
        // x as rotation, y as movement
        movement = context.ReadValue<Vector2>();

        movement.x *= Pole.Instance.rotationSpeed;
        movement.y *= Pole.Instance.moveSpeed;
    }

    public void PolesMinus(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            if (currentPoleIndex > 0)
            {
                currentPoleIndex--;
                Vector3 offsetPosition = poles[currentPoleIndex].transform.position;
                offsetPosition.z = 0f;
                offsetPosition.y = 0f;
                arrow.transform.position = offsetPosition;
            }
    }

    public void PolesPlus(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            if (currentPoleIndex < poles.Length - 1)
            {
                currentPoleIndex++;
                Vector3 offsetPosition = poles[currentPoleIndex].transform.position;
                offsetPosition.z = 0f;
                offsetPosition.y = 0f;
                arrow.transform.position = offsetPosition;
            }
    }

    // TODO: not working yet
    public void LockPoleDown(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            //Pole.Instance.lockedDownPressed = true;
            poles[currentPoleIndex].lockedDownPressed = true;
        }

        if (context.phase == InputActionPhase.Canceled)
        {
            //Pole.Instance.lockedDownPressed = false;
            poles[currentPoleIndex].lockedDownPressed = false;
        }
    }
    #endregion




}
