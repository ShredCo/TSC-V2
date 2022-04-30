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
    
    [SerializeField] private PolesAI[] polesAI;
    
    private Vector2 movementPoleInput;
    public float rotationSpeed = 1500f;
    public float movementSpeed = 2f;
    
    [SerializeField]
    [Range(-1f, 1f)]
    private float movementInputValue = 0f;
    [SerializeField]
    [Range(-1f, 1f)]
    private float rotationInputValue = 0f;
    [SerializeField]
    [Range(0, 3)]
    public int currentPoleIndexAI = 0;

    public GameObject steeringWheelPoleAI;

    private void Update()
    {
        UpdateSteeringWheelPosition();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (AIState)
        {
            case AIState.OutOfRange:
                break;
            case AIState.InCircleRange:
                break;
            case AIState.InBackRange:
                break;
            case AIState.Loading:
                break;
            case AIState.Shooting:
                Debug.Log("Shoooooooting");
                StartCoroutine(MoveAndRotatePoles());
                break;
            case AIState.Backflip:
                //StartCoroutine(Backflip());
                break;
        }
    }

    IEnumerator MoveAndRotatePoles()
    {
        Debug.Log("Coroutine for shooting");
        movementPoleInput = new Vector2(rotationInputValue, movementInputValue);
        movementPoleInput.x *= rotationSpeed;
        movementPoleInput.y *= movementSpeed;
        
        polesAI[currentPoleIndexAI].MoveAndRotate(movementPoleInput * Time.deltaTime);
        yield return new WaitForSeconds(1);
    }

    void UpdateSteeringWheelPosition()
    {
        // updates to show the current pole
        Vector3 offsetPositionArrow = polesAI[currentPoleIndexAI].transform.position;
        offsetPositionArrow.z = 0f;
        offsetPositionArrow.y = 0f;
        steeringWheelPoleAI.transform.position = offsetPositionArrow;
    }
    
}
