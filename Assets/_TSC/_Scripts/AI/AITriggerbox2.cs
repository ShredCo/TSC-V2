using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITriggerbox2 : MonoBehaviour
{
    public CrewPole2AI crewPole2AI;
    public ShootingState shootingState;

    // Gives the value how much we want it to rotate
    private Quaternion loadingAngle = Quaternion.Euler(0f, 0f, -45f);
    private Quaternion shotAngle = Quaternion.Euler(0f, 0f, 45f);
    public Quaternion currentAngle;

    // Difficulty
    public float LoadingSpeed = 0.5f;
    public float ShotSpeed = 0.3f;
    
    private bool isInZone = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            shootingState = ShootingState.Loading;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            isInZone = true;
            if (shootingState == ShootingState.Default)
            {
                StartCoroutine(CheckForShot());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        shootingState = ShootingState.Default;
        isInZone = false;
    }

    // Coroutines
    public IEnumerator CheckForShot()
    {
        if (isInZone == true)
        {
            yield return new WaitForSeconds(1f);
            shootingState = ShootingState.Loading;
        }
    }
    public IEnumerator ResetPole()
    {
        yield return new WaitForSeconds(1.5f);
        crewPole2AI.Rb.transform.rotation = Quaternion.Lerp(crewPole2AI.Rb.transform.rotation, Quaternion.identity, 5 * Time.deltaTime);
    }
    public IEnumerator LoadShot()
    {
        
        yield return new WaitForSeconds(1);
        //crewPole2AI.rb.transform.Rotate(rotationLoading * loadingSpeed * Time.deltaTime);
        crewPole2AI.Rb.transform.rotation = Quaternion.Lerp(crewPole2AI.Rb.transform.rotation, currentAngle, LoadingSpeed);
        yield return new WaitForSeconds(0.5f);
        shootingState = ShootingState.Shooting;
    }
    
    public IEnumerator ShootShot()
    {
        crewPole2AI.Rb.transform.rotation = Quaternion.Lerp(crewPole2AI.Rb.transform.rotation, currentAngle, ShotSpeed);
        yield return new WaitForSeconds(1f);
        shootingState = ShootingState.Default;
    }

    void FixedUpdate()
    {
        switch (shootingState)
        {
            case ShootingState.Default:
                StartCoroutine(ResetPole());
                break;
            case ShootingState.Loading:
                currentAngle = loadingAngle;
                StartCoroutine(LoadShot());
                break;
            case ShootingState.Shooting:
                currentAngle = shotAngle;
                StartCoroutine(ShootShot());
                break;
        }
    }
}
