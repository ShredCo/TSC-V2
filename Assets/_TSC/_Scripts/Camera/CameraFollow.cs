using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ball;
    public float lerpSpeed = 0.001f;

    private Vector3 offsetPosition;
    // Update is called once per frame
    void Update()
    {
        offsetPosition = ball.transform.position;
        offsetPosition.y = 1.2f;
        offsetPosition.z = 0.7f;
        
        
        transform.position = Vector3.Lerp(transform.position, offsetPosition, lerpSpeed * Time.deltaTime); 
    }
}
