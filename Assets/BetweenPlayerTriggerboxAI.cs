using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenPlayerTriggerboxAI : MonoBehaviour
{
    public AIController AIController;
    public PolesAI PolesAI;
    
    float timeCounter = 0f;
    float reactionTimeAI = 3f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            timeCounter = 0;
            
        } 
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            timeCounter += Time.deltaTime;
            if (timeCounter >= reactionTimeAI)
            {
                AIController.AIState = AIState.BetweenPlayerPositions;
                if (AIController.ShootingState == ShootingState.ShootBack)
                {

                }
                else
                {
                    AIController.ShootingState = ShootingState.LoadShot;
                    PolesAI.ShootIndex = 1;
                }
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            timeCounter = 0;
            AIController.AIState = AIState.OutOfRange;
        }
    }
}
