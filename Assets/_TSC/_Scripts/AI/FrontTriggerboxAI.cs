using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootingState
{
    OutOfRange,
    InFrontRange,
    InBackRange,
    Loading,
    Shooting,
    Backflip
}
public class FrontTriggerboxAI : MonoBehaviour
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
        if(other.CompareTag("Ball") && poleShooting.shootingState != ShootingState.InBackRange && poleShooting.shootingState != ShootingState.Backflip)
        {
            poleShooting.shootingState = ShootingState.InFrontRange;
            timeCounter += 1 * Time.deltaTime;
            
            if (timeCounter >= timeToShoot && poleShooting.shootingState == ShootingState.InFrontRange)
            {
                poleShooting.shootingState = ShootingState.Shooting;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball") && poleShooting.shootingState != ShootingState.Backflip)
        {
            poleShooting.shootingState = ShootingState.OutOfRange;
            timeCounter = 0;
        }
    }
}
