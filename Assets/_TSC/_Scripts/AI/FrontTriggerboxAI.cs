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
    Shooting,
    Backflip
}
public class FrontTriggerboxAI : MonoBehaviour
{
    public static FrontTriggerboxAI Instance;
    [SerializeField] private Rigidbody rigidbody;
    
    // Difficulty
    [SerializeField] private float loadingSpeed = 0.5f;
    [SerializeField] private float shotSpeed = 0.3f;
    
    // Gives the value how much we want it to rotate
    private Quaternion loadingAngle = Quaternion.Euler(0f, 0f, -45f);
    private Quaternion shotAngle = Quaternion.Euler(0f, 0f, 45f);
    private float timeToShoot = 0.5f;
    private float timeCounter = 0f;

    private float rotationSpeed = 1500f;
    private Vector3 backflip = new Vector3(0f, 0f, 360f);

    public ShootingState shootingState;


    public float RotateAmount = 1f;
    public int PlayerAmount;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            timeCounter = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Ball") && shootingState != ShootingState.InBackRange)
        {
            shootingState = ShootingState.InFrontRange;
            timeCounter += 1 * Time.deltaTime;
            
            if (timeCounter >= timeToShoot && shootingState == ShootingState.InFrontRange)
            {
                StartCoroutine(Shoot());
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
            // loads shot
            rigidbody.transform.rotation = Quaternion.Lerp(rigidbody.transform.rotation, loadingAngle, loadingSpeed);
            yield return new WaitForSeconds(0.5f);
            
            // shoots shot
            rigidbody.transform.rotation = Quaternion.Lerp(rigidbody.transform.rotation, shotAngle, shotSpeed);
            yield return new WaitForSeconds(1.5f);
            
            // Sets default values
            timeCounter = 0;
            rigidbody.transform.rotation = Quaternion.Lerp(rigidbody.transform.rotation, Quaternion.identity, 5 * Time.deltaTime);
        }
    }

    IEnumerator Backflip()
    {
        if (shootingState == ShootingState.Backflip)
        {
            rigidbody.transform.Rotate(Vector3.forward * RotateAmount / PlayerAmount);
            yield return new WaitForSeconds(3f);
        }
    }

    private void FixedUpdate()
    {
        if (shootingState == ShootingState.Backflip)
        {
            StartCoroutine(Backflip());
        } 
    }
}
