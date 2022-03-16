using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject ball;

    [SerializeField]
    [Range(0, 5)]
    protected float moveSpeed;

    [SerializeField]
    [Range(0, 5)]
    protected float rangeX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        SpawnMovement();
    }

    void SpawnMovement()
    {
        float randomRangeX = Random.Range(-rangeX, rangeX);
        rb.AddForce(new Vector3(randomRangeX, 0, moveSpeed * Time.deltaTime), ForceMode.Impulse);
    }
}
