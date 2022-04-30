using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleTriggerboxAI : MonoBehaviour
{
    public AIController aiController;

    float timeCounter = 0f;
    float reactionTimeAI = 1f;

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
           if (timeCounter <= reactionTimeAI)
           {
               aiController.AIState = AIState.Shooting;
           }
       }
    }
    
    private void OnTriggerExit(Collider other)
    {
        timeCounter = 0;
        if (other.CompareTag("Ball"))
        {
            aiController.AIState = AIState.OutOfRange;
            aiController.ShootingState = ShootingState.Reset;
 
        }
    }
}
