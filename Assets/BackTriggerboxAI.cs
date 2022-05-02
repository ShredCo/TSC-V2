using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTriggerboxAI : MonoBehaviour
{
    public PoleShooting poleShooting;

    float timeCounter = 0f;
    float timeToShoot = 0.5f;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Ball") && poleShooting.AIState != AIState.Backflip)
    //    {
    //        timeCounter = 0;
    //        poleShooting.AIState = AIState.InBackRange;
    //        poleShooting.RotationLeft = 360;
    //    }
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Ball") && poleShooting.AIState != AIState.InCircleRange)
    //    {
    //        poleShooting.AIState = AIState.InBackRange;
    //        timeCounter += 1 * Time.deltaTime;
    //
    //        if (timeCounter >= timeToShoot && poleShooting.AIState == AIState.InBackRange)
    //        {
    //            poleShooting.AIState = AIState.Backflip;
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Ball") && poleShooting.AIState != AIState.Backflip)
    //    {
    //        poleShooting.AIState = AIState.OutOfRange;
    //    }
    //}
}
