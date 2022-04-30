using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleTriggerboxAI : MonoBehaviour
{
    public AIController aiController;

    float timeCounter = 0f;
    float timeToShoot = 0.25f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            timeCounter = 0;
            aiController.AIState = AIState.Shooting;
            Debug.Log("Shoooooooting");
        }
    }
  
    private void OnTriggerStay(Collider other)
    {
       if(other.CompareTag("Ball"))
       {
           
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
