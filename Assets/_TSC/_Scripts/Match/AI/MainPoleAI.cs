using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPoleAI : MonoBehaviour
{
    [SerializeField] public Sense sense;
    [SerializeField] private Transform BallTransform;
    
    public Rigidbody Rb;

    [SerializeField] [Range(0f, 1f)]
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
            // Calculate the difference between the ball and the closest enemy player
            //poleMovement = sense.closestPlayer.transform.position.z - ball.transform.position.z;
            // Calculate new position of pole and interpolate player on pole with ball
            //Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - poleMovement);
            Rb.transform.position = Vector3.SmoothDamp(transform.position, BallTransform.position, ref velocity, smoothSpeed);
        
        Rb.transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.7f, -0.7f), Mathf.Clamp(transform.position.y, 0.1116f, 0.1116f), Mathf.Clamp(transform.position.z, -0.25f, 0.25f));
    }
}
