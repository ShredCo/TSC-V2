using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Variables / References
    public Transform Ball;

    private float cameraFollowSpeed = 1.5f;

    private Vector3 offsetPosition;
    #endregion

    private void Start()
    {
        offsetPosition.y = 1.2f;
        offsetPosition.z = 0.7f;
    }

    void Update()
    {
        offsetPosition = Ball.transform.position;
        
        transform.position = Vector3.Lerp(transform.position, offsetPosition, cameraFollowSpeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.5f, 0.5f),transform.position.y, transform.position.z);
    }
}
