using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PolesAI : MonoBehaviour
{
   // Singleton
    public static PolesAI Instance;
    
    Rigidbody rb;

    Vector3[] shootFrontRotations = new Vector3[2] {new Vector3(0f, 180f, 45f), new Vector3(0f, 180f, -45f) };
    public int ShootIndex = 0;
    float shootTime = 0f;

    [Header("movement variables")]
    [SerializeField] public float rotationSpeed = 1500.0f;
    [SerializeField] public float moveSpeed = 2.0f;
    // speed of go back to normal rotation when resetet back
    float speed = 5000f;
    public bool lockedDownPressed = false;

    // movement stuff
    private Vector3 velocity = Vector3.zero;
    private float smoothSpeed = 0.5f;
    
    public Transform PoleTransform;
    [SerializeField] public Sense sense;
    private float poleMovement;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GetAbility();
        if (LineUpController.SmoothSpeed > 0f)
            smoothSpeed = LineUpController.SmoothSpeed;
    }
    
    #region Movement & Rotation -> Methods
    public void RotatePoles(Vector2 movement)
    {
        // rotation
        Quaternion poleRotationQuaternion = new Quaternion();
        poleRotationQuaternion.eulerAngles = new Vector3(0f, 0f, -movement.x);
        poleRotationQuaternion.eulerAngles += transform.rotation.eulerAngles;
        rb.MoveRotation(poleRotationQuaternion);
    }
    public void ResetRotation()
    {
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0f, 180f, 0f)), 3f * Time.deltaTime));
    }
    public void MovementGoalkeeper(Transform ballTransform)
    {
        //transform.position = Vector3.SmoothDamp(transform.position, ballTransform.position, ref velocity, smoothSpeed);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.7f, -0.7f),
                                         Mathf.Clamp(transform.position.y, 0.1116f, 0.1116f), 
                                         Mathf.Clamp(transform.position.z, -0.3f, 0.3f));

        rb.MovePosition(Vector3.SmoothDamp(transform.position, ballTransform.position, ref velocity, smoothSpeed));
    }
    public void MovementCrewPole1(Transform ballTransform)
    {
        if (ballTransform.position.x >= PoleTransform.position.x - 0.08f)
        {
            // Calculate the z difference between the ball and the closest enemy player
            poleMovement = sense.ClosestPlayer.transform.position.z - ballTransform.transform.position.z;
            
            if (sense.ClosestPlayer.name is "pos2" or "pos3")
            {
                // if ball is in front of pole it lerps towards the ball position
                // Calculate new position of pole and interpolate player on pole with ball
                Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - poleMovement);
                rb.MovePosition(Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed));
            }
            else
            {
                // When the ball is out of reach from pos2 or pos3 but still infront of pole 1
                Vector3 defaultPosition = new Vector3(transform.position.x, transform.position.y, 0f);
                rb.MovePosition(Vector3.SmoothDamp(transform.position, defaultPosition, ref velocity, smoothSpeed));
            }
        }
        else
        {
            // If ball is behind pole it should interpolate away 
            // Calculate new position of pole and interpolate player on pole with ball
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - poleMovement);
            rb.MovePosition(Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed));
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.5f, -0.5f), Mathf.Clamp(transform.position.y, 0.1116f, 0.1116f), Mathf.Clamp(transform.position.z, -0.14f, 0.14f));
    }
    public void MovementCrewPole2(Transform ballTransform)
    {
        if (ballTransform.position.x >= PoleTransform.position.x - 0.08f)
        {
            // Calculate the z difference between the ball and the closest enemy player
            poleMovement = sense.ClosestPlayer.transform.position.z - ballTransform.transform.position.z;
            
            if (sense.ClosestPlayer.name is "pos4" or "pos5" or "pos6" or "pos7" or "pos8")
            {
                // Calculate new position of pole and interpolate player on pole with ball
                Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - poleMovement);
                rb.MovePosition(Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed));
            }
        }
        else
        {
            // Calculate new position of pole and interpolate player on pole with ball
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - poleMovement);
            rb.MovePosition(Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed));
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.1f, -0.1f), 
                                         Mathf.Clamp(transform.position.y, 0.1116f, 0.1116f), 
                                         Mathf.Clamp(transform.position.z, -0.1f, 0.1f));
    }
    public void MovementCrewPole3(Transform ballTransform)
    {
        if (ballTransform.position.x >= PoleTransform.position.x - 0.08f)
        {
            // Calculate the difference between the ball and the closest enemy player
            poleMovement = sense.ClosestPlayer.transform.position.z - ballTransform.transform.position.z;
            
            if (sense.ClosestPlayer.name is "pos9" or "pos10" or "pos11")
            {
                // Calculate new position of pole and interpolate player on pole with ball
                Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - poleMovement);
                rb.MovePosition(Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed));
            }
        }
        else
        {
            // Calculate new position of pole and interpolate player on pole with ball
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - poleMovement);
            rb.MovePosition(Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed));
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0.3f, 0.3f), 
                                         Mathf.Clamp(transform.position.y, 0.1116f, 0.1116f), 
                                         Mathf.Clamp(transform.position.z, -0.15f, 0.15f));
    }

    public void ShootFront()
    {
        Quaternion poleRotationQuaternion = Quaternion.Euler(shootFrontRotations[ShootIndex]);
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, poleRotationQuaternion, 10f * Time.deltaTime));

        shootTime = Mathf.Lerp(shootTime, 1f, 10f * Time.deltaTime);

        if (shootTime > 0.9f)
        {
            shootTime = 0f;
            if (ShootIndex == 0)
                ShootIndex++;
            else
                ShootIndex = 0;
        }
    }

    public void BallBetweenPlayers()
    {
        Quaternion poleRotationQuaternion = Quaternion.Euler(shootFrontRotations[ShootIndex]);
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, poleRotationQuaternion, 10f * Time.deltaTime));

        shootTime = Mathf.Lerp(shootTime, 1f, 10f * Time.deltaTime);

        if (shootTime > 0.9f)
        {
            shootTime = 0f;
            if (ShootIndex == 0)
                ShootIndex++;
            else
                ShootIndex = 0;
        } 
    }
    #endregion
    
    public void PoleLockedDown()
    {
        Debug.Log("FastShot/PoleReset activated");
        if (lockedDownPressed == true)
        {
            var step = speed * Time.deltaTime;
            Quaternion normalQuaternion = Quaternion.identity;
            Quaternion lockedUpQuaternion = Quaternion.RotateTowards(transform.rotation, normalQuaternion, step);
            rb.MoveRotation(lockedUpQuaternion);
        }
    }
    public void PoleFreeze()
    {
        var step = speed * Time.deltaTime;
        Quaternion normalQuaternion = Quaternion.identity;
        Quaternion lockedUpQuaternion = Quaternion.RotateTowards(transform.rotation, normalQuaternion, step);
        rb.MoveRotation(lockedUpQuaternion);
    }

    

    #region Ability
    public int Pole;
    public Ability Ability;
    void GetAbility()
    {
        //Ability = LineUpController.PlayerAbilityCardLineUP[Pole].Ability;
    }
    #endregion
    
}
