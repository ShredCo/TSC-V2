using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITriggerbox3 : MonoBehaviour
{
    public CrewPole3AI crewPole3AI;

    public ShootingState shootingState;

    public IEnumerator LoadShot()
    {
        yield return new WaitForSeconds(2);
        // loads the shot
        var step = 300 * Time.deltaTime;
        Quaternion loadShot = Quaternion.Euler(0,0,-45);
        Quaternion loadedShot = Quaternion.RotateTowards(transform.rotation, loadShot, step);
        crewPole3AI.rb.MoveRotation(loadedShot);
        shootingState = ShootingState.Shooting;
    }
    
    public IEnumerator ShootShot()
    {
        yield return new WaitForSeconds(2);
        // Shoots the Ball
        var step = 500 * Time.deltaTime; 
        Quaternion shootShot = Quaternion.Euler(0,0,45);
        Quaternion shootedShot = Quaternion.RotateTowards(transform.rotation, shootShot, step);
        crewPole3AI.rb.MoveRotation(shootedShot);
        shootingState = ShootingState.Default;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            shootingState = ShootingState.Loading;
        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        shootingState = ShootingState.Default;
    }

    void FixedUpdate()
    {
        switch (shootingState)
        {
            case ShootingState.Default:
                break;
            case ShootingState.Loading:
                StartCoroutine(LoadShot());
                break;
            case ShootingState.Shooting:
                StartCoroutine(ShootShot());
                break;
        }
    }
}
