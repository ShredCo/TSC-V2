using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewPole3AI : MonoBehaviour
{
    [SerializeField] public Sense sense;

    public float difficulty = 0.01f;
    public Transform ball;

    public Rigidbody rb;

    private float poleMovement;
    private Transform newPolePosition;

    private void Start()
    {
        newPolePosition = transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (sense.closestPlayer.name == "pos9" || sense.closestPlayer.name == "pos10" || sense.closestPlayer.name == "pos11")
        {
            // Calculate the difference between the ball and the closest enemy player
            poleMovement = sense.closestPlayer.transform.position.z - ball.transform.position.z;
            // Calculate new position of pole
            newPolePosition.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - poleMovement);
            // Set new position with Lerp
            rb.transform.position = Vector3.Lerp(transform.position, newPolePosition.position, difficulty * Time.deltaTime);
        }
        rb.transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0.3f, 0.3f), Mathf.Clamp(transform.position.y, 0.1116f, 0.1116f), Mathf.Clamp(transform.position.z, -0.15f, 0.15f));
    }
}
