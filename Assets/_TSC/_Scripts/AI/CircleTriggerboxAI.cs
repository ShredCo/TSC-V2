using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleTriggerboxAI : MonoBehaviour
{
    public PoleShooting poleShooting;

    float timeCounter = 0f;
    float timeToShoot = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            timeCounter = 0;

        }
    }
    

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Ball") && poleShooting.AIState != AIState.InBackRange && poleShooting.AIState != AIState.Backflip)
        {
            poleShooting.AIState = AIState.InFrontRange;
            timeCounter += 1 * Time.deltaTime;
            
           //if (timeCounter >= timeToShoot && poleShooting.AIState == AIState.InFrontRange)
           //{
           //    poleShooting.AIState = AIState.Shooting;
           //    poleShooting.ShootingState = ShootingState.Load;
           //}
            if (poleShooting.AIState == AIState.InFrontRange)
            {
                poleShooting.AIState = AIState.Shooting;
                poleShooting.ShootingState = ShootingState.Load;
            }
        }
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
