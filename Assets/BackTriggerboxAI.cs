using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTriggerboxAI : MonoBehaviour
{
    public PoleShooting poleShooting;

    float timeCounter = 0f;
    float timeToShoot = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && poleShooting.shootingState != ShootingState.Backflip)
        {
            timeCounter = 0;
            poleShooting.shootingState = ShootingState.InBackRange;
            poleShooting.RotationLeft = 360;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball") && poleShooting.shootingState != ShootingState.InFrontRange)
        {
            poleShooting.shootingState = ShootingState.InBackRange;
            timeCounter += 1 * Time.deltaTime;

            if (timeCounter >= timeToShoot && poleShooting.shootingState == ShootingState.InBackRange)
            {
                poleShooting.shootingState = ShootingState.Backflip;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball") && poleShooting.shootingState != ShootingState.Backflip)
        {
            poleShooting.shootingState = ShootingState.OutOfRange;
        }
    }
}
