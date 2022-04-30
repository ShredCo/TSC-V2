using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PolesAI : MonoBehaviour
{
   // Singleton
    public static PolesAI Instance;
    
    Rigidbody rb;

    [Header("movement variables")]
    [SerializeField] public float rotationSpeed = 1500.0f;
    [SerializeField] public float moveSpeed = 2.0f;
    // speed of go back to normal rotation when resetet back
    float speed = 5000f;
    public bool lockedDownPressed = false;

    // movement stuff
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    [Range(0f, 1f)]
    private float smoothSpeed = 0.5f;
    
   //public Transform Pole1Transform;
   //public Transform Pole2Transform;
   //public Transform Pole3Transform;
    public Transform PoleTransform;
    [SerializeField] public Sense sense;
    private float pole1Movement;
    private float pole2Movement;
    private float pole3Movement;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GetAbility();
    }

    
    
    #region Movement & Rotation -> Methods
    public void RotatePoles(Vector2 movement)
    {
        // rotation
        Quaternion poleRotationQuaternion = new Quaternion();
        poleRotationQuaternion.eulerAngles = new Vector3(0f, 0f, -movement.x);
        poleRotationQuaternion.eulerAngles += transform.rotation.eulerAngles;
        rb.MoveRotation(poleRotationQuaternion);

        // movement up & down
        //rb.MovePosition(new Vector3(0f, 0f, -movement.y) + transform.position);
    }
    public void MovementGoalkeeper(Transform ballTransform)
    {
        transform.position = Vector3.SmoothDamp(transform.position, ballTransform.position, ref velocity, smoothSpeed);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.7f, -0.7f), 
                                         Mathf.Clamp(transform.position.y, 0.1116f, 0.1116f),
                                         Mathf.Clamp(transform.position.z, -0.25f, 0.25f));
    }
    public void MovementCrewPole1(Transform ballTransform)
    {
        if (ballTransform.position.x >= PoleTransform.position.x - 0.08f)
        {
            // Calculate the z difference between the ball and the closest enemy player
            pole1Movement = sense.closestPlayer.transform.position.z - ballTransform.transform.position.z;
            
            if (sense.closestPlayer.name == "pos2" || sense.closestPlayer.name == "pos3")
            {
                // if ball is in front of pole it lerps towards the ball position
                // Calculate new position of pole and interpolate player on pole with ball
                Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - pole1Movement);
                transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.5f, -0.5f),
                                                 Mathf.Clamp(transform.position.y, 0.1116f, 0.1116f),
                                                 Mathf.Clamp(transform.position.z, -0.25f, 0.25f));
            }
            else
            {
                // When the ball is out of reach from pos2 or pos3 but still infront of pole 1
                Vector3 defaultPosition = new Vector3(transform.position.x, transform.position.y, 0f);
                transform.position = Vector3.SmoothDamp(transform.position, defaultPosition, ref velocity, smoothSpeed);
            }
        }
        else
        {
            // If ball is behind pole it should interpolate away 
            // Calculate new position of pole and interpolate player on pole with ball
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - pole1Movement);
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.5f, -0.5f), 
                                             Mathf.Clamp(transform.position.y, 0.1116f, 0.1116f),
                                             Mathf.Clamp(transform.position.z, -0.05f, 0.05f));
        }
    }
    public void MovementCrewPole2(Transform ballTransform)
    {
        if (ballTransform.position.x >= PoleTransform.position.x - 0.08f)
        {
            // Calculate the z difference between the ball and the closest enemy player
            pole2Movement = sense.closestPlayer.transform.position.z + ballTransform.transform.position.z;
            
            if (sense.closestPlayer.name == "pos4" || sense.closestPlayer.name == "pos5" || sense.closestPlayer.name == "pos6" || sense.closestPlayer.name == "pos7" || sense.closestPlayer.name == "pos8")
            {
                // Calculate new position of pole and interpolate player on pole with ball
                Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - pole2Movement);
                transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            }
        }
        else
        {
            // Calculate new position of pole and interpolate player on pole with ball
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - pole2Movement);
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
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
            pole3Movement = sense.closestPlayer.transform.position.z - ballTransform.transform.position.z;
            
            if (sense.closestPlayer.name == "pos9" || sense.closestPlayer.name == "pos10" || sense.closestPlayer.name == "pos11")
            {
                // Calculate new position of pole and interpolate player on pole with ball
                Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - pole3Movement);
                transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            }
        }
        else
        {
            // Calculate new position of pole and interpolate player on pole with ball
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - pole3Movement);
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0.3f, 0.3f), 
                                         Mathf.Clamp(transform.position.y, 0.1116f, 0.1116f), 
                                         Mathf.Clamp(transform.position.z, -0.15f, 0.15f));
    }
    #endregion
    
    public void PoleLockedDown()
    {
        Debug.Log("Fast shot activated");
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
