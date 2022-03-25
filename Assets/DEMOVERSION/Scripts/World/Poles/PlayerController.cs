using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Singleton
    public static PlayerController Instance;

    // Input System -> Input Values
    private Vector2 movementPole;
    public Vector2 movementSpecialCard;

    private PolesPlayer[] polesPlayer;
    private SpecialCard specialCard;
    private GameObject arrow;   
    protected int currentPoleIndex;
    
    // Special Cards move speed;
    public float characterVelocity = 750f;
    
    
    public BallManager ball;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void FixedUpdate()
    {
        polesPlayer[currentPoleIndex].MoveAndRotate(movementPole * Time.deltaTime);
        polesPlayer[currentPoleIndex].PoleLockedDown();
       
    }

    // when a new player joins he receives an array of poles + an arrow to see which pole is selected
    internal void ReceivePolesPlayer(PolesPlayer[] poles)
    {
        this.polesPlayer = poles;
    }

    internal void ReceiveArrow(GameObject gO)
    {
        arrow = gO;
    }

    #region Input System -> Gets the movement values from controller
    public void MoveMainPole(InputAction.CallbackContext context)
    {
        // x as rotation, y as movement
        movementPole = context.ReadValue<Vector2>();

        movementPole.x *= PolesPlayer.Instance.rotationSpeed;
        movementPole.y *= PolesPlayer.Instance.moveSpeed;
    }

    #endregion

    #region Input System -> Gets the input for switching  poles
    public void PolesMinus(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            if (currentPoleIndex > 0)
            {
                currentPoleIndex--;
                Vector3 offsetPosition = polesPlayer[currentPoleIndex].transform.position;
                offsetPosition.z = 0f;
                offsetPosition.y = 0f;
                arrow.transform.position = offsetPosition;
            }
    }

    public void PolesPlus(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            if (currentPoleIndex < polesPlayer.Length - 1)
            {
                currentPoleIndex++;
                Vector3 offsetPosition = polesPlayer[currentPoleIndex].transform.position;
                offsetPosition.z = 0f;
                offsetPosition.y = 0f;
                arrow.transform.position = offsetPosition;              
            }
    }

    #endregion

    #region Input System -> Gets Input for reset current pole rotation
    public void LockPoleDown(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            //Pole.Instance.lockedDownPressed = true;
            polesPlayer[currentPoleIndex].lockedDownPressed = true;
        }

        if (context.phase == InputActionPhase.Canceled)
        {
            //Pole.Instance.lockedDownPressed = false;
            polesPlayer[currentPoleIndex].lockedDownPressed = false;
        }
    }
    #endregion
    
    public void MoveSpecialCardCharacter(InputAction.CallbackContext context)
    {
        
        movementSpecialCard = context.ReadValue<Vector2>();

        movementSpecialCard.y *= characterVelocity;
    }
    
}
