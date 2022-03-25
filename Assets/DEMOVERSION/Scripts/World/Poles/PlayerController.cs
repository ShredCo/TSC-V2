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
    private GameObject arrow;
    public GameObject cardSpawnPos;
    private SpecialCardCharacter specialCardCharacter;

    public Vector3 offsetPositionCard;
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
        specialCardCharacter.MoveUpAndDown(movementSpecialCard * Time.deltaTime);
       
    }

    // NOTE: Do some more research about this topic
    // when a new player joins he receives an array of poles + an arrow to see which pole is selected
    internal void ReceivePolesPlayer(PolesPlayer[] poles)
    {
        this.polesPlayer = poles;
    }

    internal void ReceiveArrow(GameObject gO)
    {
        arrow = gO;
    }
    
    internal void ReceiveCardSpawnPos(GameObject gO)
    {
        cardSpawnPos = gO;
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

    #region Input System -> Gets the input for switching  poles and switches special card spawns
    public void PolesMinus(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            if (currentPoleIndex > 0)
            {
                currentPoleIndex--;

                // updates to show the current pole
                Vector3 offsetPositionArrow = polesPlayer[currentPoleIndex].transform.position;
                offsetPositionArrow.z = 0f;
                offsetPositionArrow.y = 0f;
                arrow.transform.position = offsetPositionArrow;
                
                // updates the spawnPos of special cards
                offsetPositionCard = polesPlayer[currentPoleIndex].transform.position;
                offsetPositionCard.z = -0.4734f;
                offsetPositionCard.y = 0.1223f;
                cardSpawnPos.transform.position = offsetPositionCard;
            }
    }

    public void PolesPlus(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            if (currentPoleIndex < polesPlayer.Length - 1)
            {
                currentPoleIndex++;

                // updates to show the current pole
                Vector3 offsetPosition = polesPlayer[currentPoleIndex].transform.position;
                offsetPosition.z = 0f;
                offsetPosition.y = 0f;
                arrow.transform.position = offsetPosition;   
                
                // updates the spawnPos of special cards
                offsetPositionCard = polesPlayer[currentPoleIndex].transform.position;
                offsetPositionCard.z = -0.4734f;
                offsetPositionCard.y = 0.12f;
                cardSpawnPos.transform.position = offsetPositionCard;
            }
    }
    #endregion

    #region Input System -> Gets Input to reset current pole rotation
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

        movementSpecialCard.y *= SpecialCardCharacter.Instance.moveSpeed;
    }
    
}
