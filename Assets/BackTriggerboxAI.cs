using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTriggerboxAI : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    
    // Difficulty
    [SerializeField] private float shotSpeed = 0.7f;
    
    // Gives the value how much we want it to rotate
    private Quaternion threeSixty = Quaternion.Euler(0f, 0f, 10f);
    private float timeToShoot = 0.4f;
    private float timeCounter = 0f;
    private float rotationSpeed = 1500f;
    private Vector3 backflip = new Vector3(0f, 0f, 360f);
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            timeCounter = 0;
            FrontTriggerboxAI.Instance.shootingState = ShootingState.InBackRange;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            timeCounter += 1 * Time.deltaTime;
            if (timeCounter >= timeToShoot && FrontTriggerboxAI.Instance.shootingState == ShootingState.InBackRange)
            {
                StartCoroutine(Backflip());
            }
        }
    }

    IEnumerator Backflip()
    {
        FrontTriggerboxAI.Instance.shootingState = ShootingState.Backflip;
        if (FrontTriggerboxAI.Instance.shootingState == ShootingState.Backflip)
        {
            Debug.Log("back shooting mode");
            // shoots shot
            rigidbody.transform.Rotate(backflip * rotationSpeed * Time.deltaTime);
            //rigidbody.transform.rotation = Quaternion.Lerp(rigidbody.transform.rotation, threeSixty, shotSpeed * Time.deltaTime);
            yield return new WaitForSeconds(3f);
            
            // Sets default values
            timeCounter = 0;
            rigidbody.transform.rotation = Quaternion.Lerp(rigidbody.transform.rotation, Quaternion.identity, 5 * Time.deltaTime);
        }
    }
}
