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
    [SerializeField] private GameObject steeringWheelLeftHandAI;
    [SerializeField] private GameObject steeringWheelRightHandAI;
    [SerializeField] public PolesAI[] polesAI;

    [SerializeField]
    [Range(-3f, 3f)]
    private float movementInputValue = 3f;
    [SerializeField]
    [Range(-1f, 1f)]
    private float rotationInputValue = 0.3f;
    [SerializeField]
    [Range(0, 3)]
    public int currentPoleIndexLeftHand = 0;
    
    private Vector2 rotationPoleInput;

    // Movement stuff
    private Transform newPolePositionPoleMain;
    private Vector3 velocity = Vector3.zero;
    
    // HUD Pole Condition Gameobjects 
    [SerializeField] private Animator player2_pole1;
    [SerializeField] private Animator player2_pole2;
    [SerializeField] private Animator player2_pole3;
    [SerializeField] private Animator player2_pole4;

    public GameObject pointer1;
    public GameObject pointer2;
    public GameObject pointer3;
    public GameObject pointer4;
    
    // ShootFront
    public int FrontShootRotationIndex;

    private void Start()
    {
        if (LineUpController.RotationInputValue > 0f)
            rotationInputValue = LineUpController.RotationInputValue;
    }

    private void Update()
    {
        UpdateCurrentPoleAI();
        UpdateHUD();
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
        if (currentPoleIndexLeftHand != 0)
            polesAI[0].MovementOneManPole(BallTransform);
    }

    public void RotateAndMovePolesInput()
    {
        rotationPoleInput = new Vector2(rotationInputValue, movementInputValue);
        rotationPoleInput.x *= PolesAI.Instance.rotationSpeed;
        polesAI[currentPoleIndexLeftHand].RotatePoles(rotationPoleInput * Time.deltaTime);

        if (currentPoleIndexLeftHand == 0)
        {
            polesAI[currentPoleIndexLeftHand].MovementOneManPole(BallTransform);
        }
        else if (currentPoleIndexLeftHand == 1)
        {
            polesAI[currentPoleIndexLeftHand].MovementTwoManPole(BallTransform);
        }
        else if (currentPoleIndexLeftHand == 2)
        {
            polesAI[currentPoleIndexLeftHand].MovementFiveManPole(BallTransform);
        }
        else if (currentPoleIndexLeftHand == 3)
        {
            polesAI[currentPoleIndexLeftHand].MovementThreeManPole(BallTransform);
        }
    }

    public void RotatePolesInput()
    {
        rotationPoleInput = new Vector2(rotationInputValue, movementInputValue);
        rotationPoleInput.x *= PolesAI.Instance.rotationSpeed;
        polesAI[currentPoleIndexLeftHand].RotatePoles(rotationPoleInput * Time.deltaTime);
    }

    public void MovePolesInput()
    {
        if (currentPoleIndexLeftHand == 0)
        {
            polesAI[currentPoleIndexLeftHand].MovementOneManPole(BallTransform);
        }
        else if (currentPoleIndexLeftHand == 1)
        {
            polesAI[currentPoleIndexLeftHand].MovementTwoManPole(BallTransform);
        }
        else if (currentPoleIndexLeftHand == 2)
        {
            polesAI[currentPoleIndexLeftHand].MovementFiveManPole(BallTransform);
        }
        else if (currentPoleIndexLeftHand == 3)
        {
            polesAI[currentPoleIndexLeftHand].MovementThreeManPole(BallTransform);
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
        polesAI[currentPoleIndexLeftHand].ShootFront();
    }
    
    public void BallBetweenPlayers()
    {
        polesAI[currentPoleIndexLeftHand].BallBetweenPlayers();
    }

    IEnumerator FastShot()
    {
        polesAI[currentPoleIndexLeftHand].lockedDownPressed = true;
        yield return new WaitForSeconds(0.2f);
        polesAI[currentPoleIndexLeftHand].lockedDownPressed = false;
    }
    
    
    #region SteeringWheel + Current Pole Index Methods
    void UpdateCurrentPoleAI()
    {
        // Simple methods to see where the ball is on the field and change AI currentPoleIndex based on position of ball
        if (BallTransform.position.x < -6f)
        {
            currentPoleIndexLeftHand = 0;
            
            // updates to show the current pole
            Vector3 wheelPositionLeftHand = polesAI[0].transform.position;
            wheelPositionLeftHand.z = 0f;
            wheelPositionLeftHand.y = 0f;
            steeringWheelLeftHandAI.transform.position = wheelPositionLeftHand;
            
            // updates to show the current pole
            Vector3 wheelPositionRightHand = polesAI[1].transform.position;
            wheelPositionRightHand.z = 0f;
            wheelPositionRightHand.y = 0f;
            steeringWheelRightHandAI.transform.position = wheelPositionRightHand;
        }
        if (BallTransform.position.x is > -6f and < -3f)
        {
            currentPoleIndexLeftHand = 1;
            
            // updates to show the current pole
            Vector3 wheelPositionLeftHand = polesAI[1].transform.position;
            wheelPositionLeftHand.z = 0f;
            wheelPositionLeftHand.y = 0f;
            steeringWheelLeftHandAI.transform.position = wheelPositionLeftHand;
            
            // updates to show the current pole
            Vector3 wheelPositionRightHand = polesAI[2].transform.position;
            wheelPositionRightHand.z = 0f;
            wheelPositionRightHand.y = 0f;
            steeringWheelRightHandAI.transform.position = wheelPositionRightHand;
        }
        if (BallTransform.position.x is > -3f and < 1f)
        {
            currentPoleIndexLeftHand = 2;
            
            // updates to show the current pole
            Vector3 wheelPositionLeftHand = polesAI[2].transform.position;
            wheelPositionLeftHand.z = 0f;
            wheelPositionLeftHand.y = 0f;
            steeringWheelLeftHandAI.transform.position = wheelPositionLeftHand;
            
            // updates to show the current pole
            Vector3 wheelPositionRightHand = polesAI[3].transform.position;
            wheelPositionRightHand.z = 0f;
            wheelPositionRightHand.y = 0f;
            steeringWheelRightHandAI.transform.position = wheelPositionRightHand;
        }
        if (BallTransform.position.x > 1f)
        {
            currentPoleIndexLeftHand = 3;
        }
    }
    #endregion 
    
    #region HUD
    // HUD
    void UpdateHUD()
    {
        switch (currentPoleIndexLeftHand)
        {
            case 0:
                ResetConditionAnimations();
                pointer1.SetActive(true);
                player2_pole1.SetTrigger("Selected");
                player2_pole2.SetTrigger("NotSelected");
                player2_pole3.SetTrigger("NotSelected");
                player2_pole4.SetTrigger("NotSelected");
                break;
            case 1:
                ResetConditionAnimations();
                pointer2.SetActive(true);
                player2_pole1.SetTrigger("NotSelected");
                player2_pole2.SetTrigger("Selected");
                player2_pole3.SetTrigger("NotSelected");
                player2_pole4.SetTrigger("NotSelected");
                break;
            case 2:
                ResetConditionAnimations();
                pointer3.SetActive(true);
                player2_pole1.SetTrigger("NotSelected");
                player2_pole2.SetTrigger("NotSelected");
                player2_pole3.SetTrigger("Selected");
                player2_pole4.SetTrigger("NotSelected");
                break;
            case 3:
                ResetConditionAnimations();
                pointer4.SetActive(true);
                player2_pole1.SetTrigger("NotSelected");
                player2_pole2.SetTrigger("NotSelected");
                player2_pole3.SetTrigger("NotSelected");
                player2_pole4.SetTrigger("Selected");
                break;
        }
    }

    void ResetConditionAnimations()
    {
        player2_pole1.ResetTrigger("Selected");
        player2_pole2.ResetTrigger("Selected");
        player2_pole3.ResetTrigger("Selected");
        player2_pole4.ResetTrigger("Selected");
        
        player2_pole1.ResetTrigger("NotSelected");
        player2_pole2.ResetTrigger("NotSelected");
        player2_pole3.ResetTrigger("NotSelected");
        player2_pole4.ResetTrigger("NotSelected");
        
        // Pointers
        pointer1.SetActive(false);
        pointer2.SetActive(false);
        pointer3.SetActive(false);
        pointer4.SetActive(false);
    }
    #endregion
}
