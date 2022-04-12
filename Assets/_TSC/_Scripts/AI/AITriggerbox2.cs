using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITriggerbox2 : MonoBehaviour
{
    public CrewPole2AI crewPole2AI;
    public GameObject AiTriggerbox2;
    public ShootingState shootingState;

    // Gives the value how much we want it to rotate
    private Quaternion loadingAngle = Quaternion.Euler(0f, 0f, -45f);
    private Quaternion shotAngle = Quaternion.Euler(0f, 0f, 45f);
    public Quaternion currentAngle;

    // Difficulty
    public float LoadingSpeed = 0.5f;
    public float ShotSpeed = 0.3f;
    
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

    // Coroutines
    public IEnumerator ResetPole()
    {
        yield return new WaitForSeconds(1.5f);
        crewPole2AI.rb.transform.rotation = Quaternion.Lerp(crewPole2AI.rb.transform.rotation, Quaternion.identity, 5 * Time.deltaTime);
    }
    public IEnumerator LoadShot()
    {
        
        yield return new WaitForSeconds(1);
        //crewPole2AI.rb.transform.Rotate(rotationLoading * loadingSpeed * Time.deltaTime);
        crewPole2AI.rb.transform.rotation = Quaternion.Lerp(crewPole2AI.rb.transform.rotation, currentAngle, LoadingSpeed);
        yield return new WaitForSeconds(0.5f);
        shootingState = ShootingState.Shooting;
        AiTriggerbox2.SetActive(false);
    }
    
    public IEnumerator ShootShot()
    {
        crewPole2AI.rb.transform.rotation = Quaternion.Lerp(crewPole2AI.rb.transform.rotation, currentAngle, ShotSpeed);
        yield return new WaitForSeconds(1f);
        shootingState = ShootingState.Default;
        AiTriggerbox2.SetActive(true);
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
