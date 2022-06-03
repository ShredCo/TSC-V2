using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeManPole : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -1.2f, 1.2f));
    }
}
