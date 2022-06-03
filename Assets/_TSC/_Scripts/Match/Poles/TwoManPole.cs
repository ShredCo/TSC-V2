using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoManPole : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -2.5f, 2.5f));
    }
}
