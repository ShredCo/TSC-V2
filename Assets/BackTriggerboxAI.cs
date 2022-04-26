using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTriggerboxAI : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    
    // Difficulty
    [SerializeField] private float shotSpeed = 0.7f;
    
    // Gives the value how much we want it to rotate
    private Quaternion threeSixty = Quaternion.Euler(0f, 0f, 360f);
    
    private float timeToShoot = 0.2f;
    private float timeCounter = 0f;
    ShootingState shootingState;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            timeCounter = 0;
            StartCoroutine(Shoot());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            shootingState = ShootingState.InFrontRange;
            timeCounter += 1 * Time.deltaTime;
            
            if (timeCounter >= timeToShoot && shootingState == ShootingState.InFrontRange)
            {
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        shootingState = ShootingState.OutOfRange;
        timeCounter = 0;
    }
    
    IEnumerator Shoot()
    {
        shootingState = ShootingState.Shooting;
        if (shootingState == ShootingState.Shooting)
        {
            // shoots shot
            rigidbody.transform.rotation = Quaternion.Lerp(rigidbody.transform.rotation, threeSixty, shotSpeed);
            yield return new WaitForSeconds(1.5f);
            
            // Sets default values
            timeCounter = 0;
            rigidbody.transform.rotation = Quaternion.Lerp(rigidbody.transform.rotation, Quaternion.identity, 5 * Time.deltaTime);
        }
    }
}
