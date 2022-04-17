using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityWind : MonoBehaviour
{
    private Rigidbody ballRb;
    private float speed = 1000f;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Ball is in Windzone");
            ballRb = other.GetComponent<Rigidbody>();
            ballRb.AddForce(speed * Time.deltaTime,0f,0f);
        }
    }
}
