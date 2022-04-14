using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewPole2AI : MonoBehaviour
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

    void FixedUpdate()
    {
        if (sense.closestPlayer.name == "pos4" || sense.closestPlayer.name == "pos5" || sense.closestPlayer.name == "pos6" || sense.closestPlayer.name == "pos7" || sense.closestPlayer.name == "pos8")
        {
            // Calculate the difference between the ball and the closest enemy player
            poleMovement = sense.closestPlayer.transform.position.z - ball.transform.position.z;
            // Calculate new position of pole and interpolate player on pole with ball
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - poleMovement);
            rb.transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        }

        rb.transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.1f, -0.1f), Mathf.Clamp(transform.position.y, 0.1116f, 0.1116f), Mathf.Clamp(transform.position.z, -0.1f, 0.1f));
    }
}
