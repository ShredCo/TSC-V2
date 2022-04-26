using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITriggerbox2 : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    //public ShootingState shootingState;

    // Gives the value how much we want it to rotate
    private Quaternion loadingAngle = Quaternion.Euler(0f, 0f, -45f);
    private Quaternion shotAngle = Quaternion.Euler(0f, 0f, 45f);
    public Quaternion currentAngle;

    // Difficulty
    public float LoadingSpeed = 0.5f;
    public float ShotSpeed = 0.3f;
    
    private bool isShooting = false;
    private float timeToShoot = 0.5f;
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
        if(other.CompareTag("Ball") && !isShooting)
        {
            timeInTrigger += 1 * Time.deltaTime;
            if (timeInTrigger >= timeToShoot)
            {
                isShooting = true;
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
        rigidbody.transform.rotation = Quaternion.Lerp(rigidbody.transform.rotation, loadingAngle, LoadingSpeed);
        yield return new WaitForSeconds(0.5f);
        
        // shoots shot
        rigidbody.transform.rotation = Quaternion.Lerp(rigidbody.transform.rotation, shotAngle, ShotSpeed);
        yield return new WaitForSeconds(1.5f);

        // Sets default values
        timeInTrigger = 0;
        rigidbody.transform.rotation = Quaternion.Lerp(rigidbody.transform.rotation, Quaternion.identity, 5 * Time.deltaTime);
        isShooting = false;
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
