using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public enum ShootingState
{
    Default,
    Loaded,
    Shooted
}
public class AIShootingTriggerBoxes : MonoBehaviour
{
    public CrewPole2AI crewPole2AI;

    private float currentCount = 0f;
    private float startCountDown = 2f;

    public ShootingState shootingState;

    public IEnumerator LoadShot()
    {
        yield return new WaitForSeconds(2);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            currentCount = startCountDown;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        shootingState = ShootingState.Default;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            currentCount -= 1f * Time.deltaTime;
            Debug.Log(currentCount);
            if (currentCount <= 0)
            {
                // loads the shot
                var step = 300 * Time.deltaTime;
                Quaternion loadShot = Quaternion.Euler(0,0,-45);
                Quaternion loadedShot = Quaternion.RotateTowards(transform.rotation, loadShot, step);
                crewPole2AI.rb.MoveRotation(loadedShot);
                shootingState = ShootingState.Loaded;
            }

            if (shootingState == ShootingState.Loaded)
            {
                currentCount = startCountDown;

                if (currentCount <= 1)
                {
                    // Shoots the Ball
                    var step = 2000 * Time.deltaTime; 
                    Quaternion shootShot = Quaternion.Euler(0,0,45);
                    Quaternion shootedShot = Quaternion.RotateTowards(transform.rotation, shootShot, step);
                    crewPole2AI.rb.MoveRotation(shootedShot);
                    shootingState = ShootingState.Shooted;
                }
            }
        }
    }
}
