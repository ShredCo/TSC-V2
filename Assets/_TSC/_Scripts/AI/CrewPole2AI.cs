using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewPole2AI : MonoBehaviour
{
    [SerializeField] public Sense sense;

    
    [SerializeField] private float difficulty = 0.01f;
    
    public Transform ball;
    public Rigidbody rb;

    private float poleMovement;
    private Transform newPolePosition;

    private void Start()
    {
        newPolePosition = transform;
        rb = GetComponent<Rigidbody>();

        var myValue = Mathf.Lerp(0, 10, 0.5f);
    }

    void Update()
    {
        if (sense.closestPlayer.name == "pos4" || sense.closestPlayer.name == "pos5" || sense.closestPlayer.name == "pos6" || sense.closestPlayer.name == "pos7" || sense.closestPlayer.name == "pos8")
        {
            // Calculate the difference between the ball and the closest enemy player
            poleMovement = sense.closestPlayer.transform.position.z - ball.transform.position.z;
            // Calculate new position of pole
            newPolePosition.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - poleMovement);
            // Set new position with Lerp
            rb.transform.position = Vector3.Lerp(transform.position, newPolePosition.position, difficulty * Time.deltaTime);
        }

        rb.transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.1f, -0.1f), Mathf.Clamp(transform.position.y, 0.1116f, 0.1116f), Mathf.Clamp(transform.position.z, -0.1f, 0.1f));
    }
}
