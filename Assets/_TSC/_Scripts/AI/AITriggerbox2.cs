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
    Shooting
}
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

    ShootingState shootingState;

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
            shootingState = ShootingState.InFrontRange;
            timeInTrigger += 1 * Time.deltaTime;
            
            if (timeInTrigger >= timeToShoot && shootingState == ShootingState.InFrontRange)
            {
                Debug.Log("Ball is long enough in front range");
                StartCoroutine(Shoot());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        shootingState = ShootingState.OutOfRange;
        timeInTrigger = 0;
    }
    
    IEnumerator Shoot()
    {
        shootingState = ShootingState.Shooting;
        if (shootingState == ShootingState.Shooting)
        {
            // loads shot
            currentAngle = loadingAngle;
            rigidbody.transform.rotation = Quaternion.Lerp(rigidbody.transform.rotation, currentAngle, LoadingSpeed);
            yield return new WaitForSeconds(0.5f);
            
            // shoots shot
            currentAngle = shotAngle;
            rigidbody.transform.rotation = Quaternion.Lerp(rigidbody.transform.rotation, currentAngle, ShotSpeed);
            yield return new WaitForSeconds(1.5f);
            
            // Sets default values
            timeInTrigger = 0;
            rigidbody.transform.rotation = Quaternion.Lerp(rigidbody.transform.rotation, Quaternion.identity, 5 * Time.deltaTime);
        }
    }
}
