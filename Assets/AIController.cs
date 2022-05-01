using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum AIState
{
    OutOfRange,
    InCircleRange,
    InBackRange,
    Loading,
    Shooting,
    Backflip
}
public enum ShootingState
{
    Default,
    Load,
    Shot,
    Reset
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
    private float movementInputValue = 0f;
    [SerializeField]
    [Range(-1f, 1f)]
    private float rotationInputValue = 0f;
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
                break;
            case AIState.InCircleRange:
                RotatePolesInput();
                break;
            case AIState.InBackRange:
                break;
            case AIState.Loading:
                break;
            case AIState.Shooting:
                break;
            case AIState.Backflip:
                break;
        }
        
        // movement goalkeeper
        polesAI[0].MovementGoalkeeper(BallTransform);
        polesAI[1].MovementCrewPole1(BallTransform);
        polesAI[2].MovementCrewPole2(BallTransform);
        polesAI[3].MovementCrewPole3(BallTransform);
    }

    public void RotatePolesInput()
    {
        rotationPoleInput = new Vector2(rotationInputValue, movementInputValue);
        rotationPoleInput.x *= PolesAI.Instance.rotationSpeed;
        //rotationPoleInput.y *= PolesAI.Instance.moveSpeed;
        
        polesAI[1].RotatePoles(rotationPoleInput * Time.deltaTime);
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
        if (BallTransform.position.x <= -0.6f)
        {
            currentPoleIndexAI = 0;
        }
        if (BallTransform.position.x is >= -0.6f and <= -0.2f)
        {
            currentPoleIndexAI = 1;
        }
        if (BallTransform.position.x is >= -0.2f and <= 0.2f)
        {
            currentPoleIndexAI = 2;
        }
        if (BallTransform.position.x >= 0.2f)
        {
            currentPoleIndexAI = 3;
        }
    }
    #endregion 
}
