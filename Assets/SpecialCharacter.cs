using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCharacter : MonoBehaviour
{
    // Singleton
    public static SpecialCharacter Instance;

    Rigidbody rb;

    [Header("movement variables")]
    [SerializeField] public float rotationSpeed = 1500.0f;
    [SerializeField] public float moveSpeed = 2.0f;

    public bool lockedDownPressed = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        rb = GetComponent<Rigidbody>();
    }

    public void MoveAbilityUpAndDown(Vector2 movement)
    {
        // movement up & down
        rb.MovePosition(new Vector3(0f, 0f, -movement.y) + transform.position);
        rb.velocity = new Vector3(0f,0f,-movement.y);

        Debug.Log("Movement Input: " + movement.y);

        if (movement.y >= 0)
        {
            rb.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            rb.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        // Sets the default limit for the movement
        //rb.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -0.6f, 0.6f));
    }
}
