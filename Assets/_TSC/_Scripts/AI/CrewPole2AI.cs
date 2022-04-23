using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewPole2AI : MonoBehaviour
{
    [SerializeField] public Sense sense;
 
    public Transform BallTransform;
    public Transform PoleTransform;
    
    public Rigidbody Rb;

    [SerializeField]
    [Range(0f, 1f)]
    private float smoothSpeed = 0.5f;

    private float poleMovement;
    private Transform newPolePosition;

    [SerializeField] private Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        newPolePosition = transform;
        Rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Calbulates if the ball is in front ir behind the pole
        Vector3 poleForward = PoleTransform.right;
        Vector3 ballToPole = BallTransform.position - PoleTransform.position;
        float dotPro = Vector3.Dot(poleForward, ballToPole);

        if (dotPro >= 0)
        {
            Debug.Log("ball is in front pole");
        }
        else
        {
            Debug.Log("Ball is behind pole");
            // Calculate the z difference between the ball and the closest enemy player
            poleMovement = sense.closestPlayer.transform.position.z + BallTransform.transform.position.z;
            
            // Calculate new position of pole and interpolate player on pole with ball
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - poleMovement);
            Rb.transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        }
        
        if (sense.closestPlayer.name == "pos4" || sense.closestPlayer.name == "pos5" || sense.closestPlayer.name == "pos6" || sense.closestPlayer.name == "pos7" || sense.closestPlayer.name == "pos8")
        {
            // Calculate the difference between the ball and the closest enemy player
            poleMovement = sense.closestPlayer.transform.position.z - BallTransform.transform.position.z;
            // Calculate new position of pole and interpolate player on pole with ball
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - poleMovement);
            Rb.transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        }

        Rb.transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.1f, -0.1f), Mathf.Clamp(transform.position.y, 0.1116f, 0.1116f), Mathf.Clamp(transform.position.z, -0.1f, 0.1f));
    }
}
