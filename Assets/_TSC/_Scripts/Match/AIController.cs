using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum AIState
{
    OutOfRange,
    InCircleRange,
    BetweenPlayerPositions
}
public enum ShootingState
{
    Default,
    LoadShot,
    ShootFront,
    ShootBack,
}
public class AIController : MonoBehaviour
{
    public AIState AIState;
    public ShootingState ShootingState;
    
    [SerializeField] private Transform BallTransform;
    [SerializeField] private GameObject steeringWheelPoleAI;
    [SerializeField] public PolesAI[] polesAI;

    [SerializeField]
    [Range(-1f, 1f)]
    private float movementInputValue = 0.3f;
    [SerializeField]
    [Range(-1f, 1f)]
    private float rotationInputValue = 0.3f;
    [SerializeField]
    [Range(0, 3)]
    public int currentPoleIndexAI = 0;
    
    private Vector2 rotationPoleInput;

    // Movement stuff
    private Transform newPolePositionPoleMain;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    [Range(0f, 1f)]
    private float smoothSpeed = 0.5f;

    // ShootFront
    public int FrontShootRotationIndex;

    private void Start()
    {
        if(LineUpController.MovementInputValue > 0f)
            movementInputValue = LineUpController.MovementInputValue;
        if (LineUpController.RotationInputValue > 0f)
            rotationInputValue = LineUpController.RotationInputValue;
    }

    private void Update()
    {
        UpdateCurrentPoleAI();
        UpdateSteeringWheelPosition();
    }
    
    void FixedUpdate()
    {
        switch (AIState)
        {
            case AIState.OutOfRange:
                MovePolesInput();
                ResetPoleRotation();
                break;
            
            case AIState.InCircleRange:
                switch (ShootingState)
                {
                    case ShootingState.Default:
                        
                        break;
                    case ShootingState.ShootFront:
                        ShootFront();
                        break;
                    case ShootingState.ShootBack:
                        RotateAndMovePolesInput();
                        break;
                    default:
                        break;
                }
                //RotateAndMovePolesInput();
                break;
            
            case AIState.BetweenPlayerPositions:
                if (ShootingState == ShootingState.LoadShot)
                {
                    BallBetweenPlayers();
                }
                break;
        }

        // movement goalkeeper
        if (currentPoleIndexAI != 0)
            polesAI[0].MovementGoalkeeper(BallTransform);
    }

    public void RotateAndMovePolesInput()
    {
        rotationPoleInput = new Vector2(rotationInputValue, movementInputValue);
        rotationPoleInput.x *= PolesAI.Instance.rotationSpeed;
        polesAI[currentPoleIndexAI].RotatePoles(rotationPoleInput * Time.deltaTime);

        if (currentPoleIndexAI == 0)
        {
            polesAI[currentPoleIndexAI].MovementGoalkeeper(BallTransform);
        }
        else if (currentPoleIndexAI == 1)
        {
            polesAI[currentPoleIndexAI].MovementCrewPole1(BallTransform);
        }
        else if (currentPoleIndexAI == 2)
        {
            polesAI[currentPoleIndexAI].MovementCrewPole2(BallTransform);
        }
        else if (currentPoleIndexAI == 3)
        {
            polesAI[currentPoleIndexAI].MovementCrewPole3(BallTransform);
        }
    }

    public void RotatePolesInput()
    {
        rotationPoleInput = new Vector2(rotationInputValue, movementInputValue);
        rotationPoleInput.x *= PolesAI.Instance.rotationSpeed;
        polesAI[currentPoleIndexAI].RotatePoles(rotationPoleInput * Time.deltaTime);
    }

    public void MovePolesInput()
    {
        if (currentPoleIndexAI == 0)
        {
            polesAI[currentPoleIndexAI].MovementGoalkeeper(BallTransform);
        }
        else if (currentPoleIndexAI == 1)
        {
            polesAI[currentPoleIndexAI].MovementCrewPole1(BallTransform);
        }
        else if (currentPoleIndexAI == 2)
        {
            polesAI[currentPoleIndexAI].MovementCrewPole2(BallTransform);
        }
        else if (currentPoleIndexAI == 3)
        {
            polesAI[currentPoleIndexAI].MovementCrewPole3(BallTransform);
        }
    }

    public void ResetPoleRotation()
    {
        polesAI[0].ResetRotation();
        polesAI[1].ResetRotation();
        polesAI[2].ResetRotation();
        polesAI[3].ResetRotation();
    }

    public void ShootFront()
    {
        polesAI[currentPoleIndexAI].ShootFront();
    }
    
    public void BallBetweenPlayers()
    {
        polesAI[currentPoleIndexAI].BallBetweenPlayers();
    }

    IEnumerator FastShot()
    {
        polesAI[currentPoleIndexAI].lockedDownPressed = true;
        yield return new WaitForSeconds(0.2f);
        polesAI[currentPoleIndexAI].lockedDownPressed = false;
    }
    
    
    #region SteeringWheel + Current Pole Index Methods
    void UpdateSteeringWheelPosition()
    {
        // updates to show the current pole
        Vector3 offsetPositionArrow = polesAI[currentPoleIndexAI].transform.position;
        offsetPositionArrow.z = 0f;
        offsetPositionArrow.y = 0f;
        steeringWheelPoleAI.transform.position = offsetPositionArrow;
    }
    void UpdateCurrentPoleAI()
    {
        // Simple methods to see where the ball is on the field and change AI currentPoleIndex based on position of ball
        if (BallTransform.position.x < -0.6f)
        {
            currentPoleIndexAI = 0;
        }
        if (BallTransform.position.x is > -0.6f and < -0.3f)
        {
            currentPoleIndexAI = 1;
        }
        if (BallTransform.position.x is > -0.3f and < 0.1f)
        {
            currentPoleIndexAI = 2;
        }
        if (BallTransform.position.x > 0.1f)
        {
            currentPoleIndexAI = 3;
        }
    }
    #endregion 
}
