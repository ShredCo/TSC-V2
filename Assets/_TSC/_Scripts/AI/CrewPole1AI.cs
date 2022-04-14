using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewPole1AI : MonoBehaviour
{
    [SerializeField] public Sense sense;
 
    public Transform ball;
    public Rigidbody rb;

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
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (sense.closestPlayer.name == "pos2" || sense.closestPlayer.name == "pos3")
        {
            // Calculate the difference between the ball and the closest enemy player
            poleMovement = sense.closestPlayer.transform.position.z - ball.transform.position.z;
            // Calculate new position of pole and interpolate player on pole with ball
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - poleMovement);
            rb.transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        }
        rb.transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.5f, -0.5f), Mathf.Clamp(transform.position.y, 0.1116f, 0.1116f), Mathf.Clamp(transform.position.z, -0.25f, 0.25f));
    }
}
