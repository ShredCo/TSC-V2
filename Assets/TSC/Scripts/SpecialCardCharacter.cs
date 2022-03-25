using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCardCharacter : MonoBehaviour
{
    public static SpecialCardCharacter Instance;
    
    Rigidbody rb;
    [SerializeField] public float moveSpeed = 2.0f;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        
        rb = GetComponent<Rigidbody>();
    }

    public void MoveUpAndDown(Vector2 movement)
    {
        // movement up & down for character on pole
        rb.MovePosition(new Vector3(0f, 0f, -movement.y) + transform.position);

        // sets the default limit for the movement on the pole
        rb.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -0.6f, 0.6f));

    }
}
