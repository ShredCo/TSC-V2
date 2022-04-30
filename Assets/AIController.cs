using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public PoleShooting[] polesShooting;
    public PolesPlayer[] polesPlayers;
    [SerializeField] private PolesAI[] polesAI;
    
    [SerializeField] private float movement = 1f;
    private Vector2 movementPoleInput;

    public float speed = 1500f;
    
    
    [SerializeField]
    [Range(0f, 1f)]
    private float movementInputValue = 0f;
    [SerializeField]
    [Range(0f, 1f)]
    private float rotationInputValue = 0f;
    [SerializeField]
    [Range(0, 3)]
    private int currentPole = 0;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        movementPoleInput = new Vector2(rotationInputValue, 0f);
        movementPoleInput.x *= speed;
        
        Debug.Log("movement input value= " + movementPoleInput.x);

        //polesShooting[currentPole].MoveAndRotate(movementPoleInput * Time.deltaTime);
        polesAI[currentPole].MoveAndRotate(movementPoleInput * Time.deltaTime);
    }
}
