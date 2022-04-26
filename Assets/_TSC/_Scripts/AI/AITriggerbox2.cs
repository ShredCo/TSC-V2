using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITriggerbox2 : MonoBehaviour
{
    public CrewPole2AI crewPole2AI;
    //public ShootingState shootingState;

    // Gives the value how much we want it to rotate
    private Quaternion loadingAngle = Quaternion.Euler(0f, 0f, -45f);
    private Quaternion shotAngle = Quaternion.Euler(0f, 0f, 45f);
    public Quaternion currentAngle;

    // Difficulty
    public float LoadingSpeed = 0.5f;
    public float ShotSpeed = 0.3f;
    
    private bool isInZone = false;
    private float timeToShoot = 1f;
    private float timeInTrigger = 0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            timeInTrigger = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            timeInTrigger += Time.deltaTime;
            if (timeInTrigger >= timeToShoot)
            {
                StartCoroutine(Shoot());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        timeInTrigger = 0;
    }
    
    IEnumerator Shoot()
    {
        // loads shot
        crewPole2AI.Rb.transform.rotation = Quaternion.Lerp(crewPole2AI.Rb.transform.rotation, currentAngle, LoadingSpeed);
        yield return new WaitForSeconds(0.5f);
        
        // shoots shot
        crewPole2AI.Rb.transform.rotation = Quaternion.Lerp(crewPole2AI.Rb.transform.rotation, currentAngle, ShotSpeed);
        
        // Sets default values
        yield return new WaitForSeconds(1.5f);
        timeInTrigger = 0;
        crewPole2AI.Rb.transform.rotation = Quaternion.Lerp(crewPole2AI.Rb.transform.rotation, Quaternion.identity, 5 * Time.deltaTime);
    }

  // void FixedUpdate()
  // {
  //     switch (shootingState)
  //     {
  //         case ShootingState.Default:
  //             break;
  //     }
  // }
}
