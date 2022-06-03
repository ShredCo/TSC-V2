using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreWindow : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool playMovement;
    private bool moveRight;

    // Start is called before the first frame update
    void Start()
    {
        playMovement = true;
        StartCoroutine(MovementStoreWindowPole());

    }

    private void Update()
    {
        if (moveRight)
        {
            transform.position += transform.up * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= transform.up * moveSpeed * Time.deltaTime;
        }
    }
    IEnumerator MovementStoreWindowPole()
    {
        while (playMovement)
        {
            moveRight = true;
            yield return new WaitForSeconds(5);
            moveRight = false;
            yield return new WaitForSeconds(5);
        }

    }
}
