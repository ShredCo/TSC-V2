using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Ball;
    private float cameraFollowSpeed = 5f;

    private Vector3 offsetPosition;
    // Update is called once per frame
    void Update()
    {
        offsetPosition = Ball.transform.position;
        offsetPosition.y = 1.2f;
        offsetPosition.z = 0.7f;
        
        transform.position = Vector3.Lerp(transform.position, offsetPosition, cameraFollowSpeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.5f, 0.5f),transform.position.y, transform.position.z);
    }
}
