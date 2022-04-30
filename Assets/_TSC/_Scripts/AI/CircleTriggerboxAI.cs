using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleTriggerboxAI : MonoBehaviour
{
    public PoleShooting poleShooting;

    float timeCounter = 0f;
    float timeToShoot = 0.25f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            timeCounter = 0;
            poleShooting.AIState = AIState.Shooting;
        }
    }
  
    private void OnTriggerStay(Collider other)
    {
       //if(other.CompareTag("Ball") && poleShooting.AIState != AIState.InBackRange && poleShooting.AIState != AIState.Backflip)
       //{
       //    poleShooting.AIState = AIState.InCircleRange;
       //    timeCounter += 1 * Time.deltaTime;
       //    
       //   if (timeCounter >= timeToShoot && poleShooting.AIState == AIState.InCircleRange)
       //   {
       //       poleShooting.AIState = AIState.Shooting;
       //       poleShooting.ShootingState = ShootingState.Shot;
       //   }
       //}
    }
    private void OnTriggerExit(Collider other)
    {
        timeCounter = 0;
        if (other.CompareTag("Ball") && poleShooting.AIState != AIState.Backflip)
        {
            poleShooting.AIState = AIState.OutOfRange;
            poleShooting.ShootingState = ShootingState.Reset;
            
        }
    }
}
