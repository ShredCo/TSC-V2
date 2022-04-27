using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPoint : MonoBehaviour
{
    private PoleShooting PoleShooting;
    private float forceFactor = 20;

    // A list because maybe we will add multiple balls during one game in the future.
    List<Rigidbody> rgdBalls = new List<Rigidbody>();

    Transform magnetPoint;

    // Start is called before the first frame update
    void Start()
    {
        magnetPoint = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        foreach(Rigidbody rgdBal in rgdBalls)
        {
            rgdBal.AddForce((magnetPoint.position - rgdBal.position) * forceFactor * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            forceFactor = 20;
            rgdBalls.Add(other.GetComponent<Rigidbody>());
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball") && PoleShooting.ShootingState == ShootingState.Shot)
        {
            forceFactor = -400;
            foreach(Rigidbody rgdBal in rgdBalls)
            {
                rgdBal.AddForce((magnetPoint.position - rgdBal.position) * forceFactor * Time.fixedDeltaTime);
            } 
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        rgdBalls.Remove(other.GetComponent<Rigidbody>());
        forceFactor = 20;
    }
}
