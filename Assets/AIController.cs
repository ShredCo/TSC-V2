using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    
    [SerializeField] private PolesAI[] polesAI;

    
    private Vector2 movementPoleInput;
    public float rotationSpeed = 1500f;
    public float movementSpeed = 2f;
    
    [SerializeField]
    [Range(-1f, 1f)]
    private float movementInputValue = 0f;
    [SerializeField]
    [Range(-1f, 1f)]
    private float rotationInputValue = 0f;
    [SerializeField]
    [Range(0, 3)]
    private int currentPoleIndexAI = 0;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        movementPoleInput = new Vector2(rotationInputValue, movementInputValue);
        movementPoleInput.x *= rotationSpeed;
        movementPoleInput.y *= movementSpeed;
        
        Debug.Log("movement input value= " + movementPoleInput.x);

        //polesShooting[currentPole].MoveAndRotate(movementPoleInput * Time.deltaTime);
        polesAI[currentPoleIndexAI].MoveAndRotate(movementPoleInput * Time.deltaTime);
    }
}
