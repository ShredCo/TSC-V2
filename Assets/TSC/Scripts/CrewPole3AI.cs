using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewPole3AI : MonoBehaviour
{
    public float difficulty = 25;
    public Transform ball;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.position = Vector3.Lerp(transform.position, ball.transform.position, difficulty * Time.deltaTime);

        // Sets the default limit for the movement
        rb.transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0.3f, 0.3f), Mathf.Clamp(transform.position.y, 0.1116f, 0.1116f), Mathf.Clamp(transform.position.z, -0.2f, 0.2f));

    }
}
