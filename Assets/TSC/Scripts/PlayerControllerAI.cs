using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerAI : MonoBehaviour
{
    // Singleton
    public static PlayerControllerAI Instance;

    public float difficulty = 25;
    public BallManager ball;

    private Vector2 pos;
    private PolesAI[] polesAI;
    private GameObject arrow;
    protected int currentPoleIndex;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void FixedUpdate()
    {
        
        polesAI[currentPoleIndex].MoveAndRotate(Vector3.Lerp(transform.position, ball.transform.position, difficulty * Time.deltaTime));
    }

    // give the AI an array of Poles
    internal void ReceivePolesAI(PolesAI[] poles)
    {
        this.polesAI = poles;
    }

    internal void ReceiveArrowAI(GameObject gO)
    {
        arrow = gO;
    }

    #region Input System -> Gets the movement values from controller
    public void MoveMainPole(Vector3 pos)
    {
        // x as rotation, y as movement
        pos = Vector3.Lerp(transform.position, new Vector2(transform.position.x, ball.transform.position.y), difficulty * Time.deltaTime);

        pos.x *= PolesPlayer.Instance.rotationSpeed;
        pos.y *= PolesPlayer.Instance.moveSpeed;
    }

    #endregion

    #region Input System -> Gets the input for switching  poles
    public void PolesMinus(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            if (currentPoleIndex > 0)
            {
                currentPoleIndex--;
                Vector3 offsetPosition = polesAI[currentPoleIndex].transform.position;
                offsetPosition.z = 0f;
                offsetPosition.y = 0f;
                arrow.transform.position = offsetPosition;
            }
    }

    public void PolesPlus(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            if (currentPoleIndex < polesAI.Length - 1)
            {
                currentPoleIndex++;
                Vector3 offsetPosition = polesAI[currentPoleIndex].transform.position;
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
            polesAI[currentPoleIndex].lockedDownPressed = true;
        }

        if (context.phase == InputActionPhase.Canceled)
        {
            //Pole.Instance.lockedDownPressed = false;
            polesAI[currentPoleIndex].lockedDownPressed = false;
        }
    }
    #endregion
}
