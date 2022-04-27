using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPoint : MonoBehaviour
{
    private float forceFactor = 20;

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
            rgdBalls.Add(other.GetComponent<Rigidbody>());
        }
            
        
    }

    private void OnTriggerExit(Collider other)
    {
        rgdBalls.Remove(other.GetComponent<Rigidbody>());
    }
}
