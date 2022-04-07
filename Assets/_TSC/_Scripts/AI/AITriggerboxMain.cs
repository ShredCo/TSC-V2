using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public enum ShootingState
{
    Default,
    Loading,
    Shooting,
}
public class AITriggerboxMain : MonoBehaviour
{
    public MainPoleAI mainPoleAI;
    public ShootingState shootingState;

    // Could be used to interpolate the shots cleaner
    [SerializeField] private AnimationCurve curve;
    
    // Gives the value how much we want it to rotate
    private Vector3 rotationLoading = new Vector3(0f,0f,-45f);
    private Vector3 rotationShooting  = new Vector3(0f,0f,45f);
    [SerializeField] private float loadingSpeed;
    [SerializeField] private float shootingSpeed;
    
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
        mainPoleAI.rb.transform.rotation = Quaternion.Lerp(mainPoleAI.rb.transform.rotation, Quaternion.identity, 5 * Time.deltaTime);
    }
    public IEnumerator LoadShot()
    {
        yield return new WaitForSeconds(1);
        mainPoleAI.rb.transform.Rotate(rotationLoading * loadingSpeed * Time.deltaTime);
        //yield return new WaitForSeconds(2f);
        shootingState = ShootingState.Shooting;
    }
    
    public IEnumerator ShootShot()
    {
        yield return new WaitForSeconds(1f);
        mainPoleAI.rb.transform.Rotate(rotationShooting * shootingSpeed * Time.deltaTime);
        yield return new WaitForSeconds(2f);
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
                StartCoroutine(LoadShot());
                break;
            case ShootingState.Shooting:
                StartCoroutine(ShootShot());
                break;
        }
    }
}
