using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Singleton
    public static PlayerController Instance;

    private Vector2 movementMainPole;
    private Vector2 movementCrewPole;
    private MainPole[] mainPole;
    private CrewPoles[] crewPoles;
    private GameObject arrow;

    
    protected int currentMainPoleIndex;
    protected int currentCrewPoleIndex;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void FixedUpdate()
    {
        mainPole[currentMainPoleIndex].MoveAndRotate(movementMainPole * Time.deltaTime);
        mainPole[currentMainPoleIndex].PoleLockedDown();

        crewPoles[currentCrewPoleIndex].MoveAndRotate(movementCrewPole * Time.deltaTime);
        crewPoles[currentCrewPoleIndex].PoleLockedDown();
        
    }

    // when a new player joins he receives an array of poles + an arrow to see which pole is selected
    internal void ReceiveMainPoles(MainPole[] poles)
    {
        this.mainPole = poles;
    }
    internal void ReceiveCrewPoles(CrewPoles[] poles)
    {
        this.crewPoles = poles;
    }


    internal void ReceiveArrow(GameObject gO)
    {
        arrow = gO;
    }

    #region Input System -> Gets the movement values from controller
    public void MoveMainPole(InputAction.CallbackContext context)
    {
        // x as rotation, y as movement
        movementMainPole = context.ReadValue<Vector2>();

        movementMainPole.x *= MainPole.Instance.rotationSpeed;
        movementMainPole.y *= MainPole.Instance.moveSpeed;
    }
    public void MoveCrewPoles(InputAction.CallbackContext context)
    {
        // x as rotation, y as movement
        movementCrewPole = context.ReadValue<Vector2>();

        movementCrewPole.x *= CrewPoles.Instance.rotationSpeed;
        movementCrewPole.y *= CrewPoles.Instance.moveSpeed;
    }

    #endregion

    #region Input System -> Gets the input for switching crew poles
    public void PolesMinus(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            if (currentCrewPoleIndex > 0)
            {
                currentCrewPoleIndex--;
                Vector3 offsetPosition = crewPoles[currentCrewPoleIndex].transform.position;
                offsetPosition.z = 0f;
                offsetPosition.y = 0f;
                arrow.transform.position = offsetPosition;
                Debug.Log(currentCrewPoleIndex);
            }
    }

    public void PolesPlus(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            if (currentCrewPoleIndex < crewPoles.Length - 1)
            {
                currentCrewPoleIndex++;
                Vector3 offsetPosition = crewPoles[currentCrewPoleIndex].transform.position;
                offsetPosition.z = 0f;
                offsetPosition.y = 0f;
                arrow.transform.position = offsetPosition;
                Debug.Log(currentCrewPoleIndex);
            }
    }

    #endregion

    #region Input System -> Gets Input for reset current pole rotation
    public void LockPoleDown(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            //Pole.Instance.lockedDownPressed = true;
            mainPole[currentCrewPoleIndex].lockedDownPressed = true;
        }

        if (context.phase == InputActionPhase.Canceled)
        {
            //Pole.Instance.lockedDownPressed = false;
            mainPole[currentCrewPoleIndex].lockedDownPressed = false;
        }
    }
    #endregion
}
