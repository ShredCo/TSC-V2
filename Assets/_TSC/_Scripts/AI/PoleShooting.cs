using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleShooting : MonoBehaviour
{
    // Difficulty
    [SerializeField] private float loadingSpeed = 0.5f;
    [SerializeField] private float shotSpeed = 0.3f;

    // Gives the value how much we want it to rotate
    private Quaternion loadingAngle = Quaternion.Euler(0f, 0f, -45f);
    private Quaternion shotAngle = Quaternion.Euler(0f, 0f, 45f);

    public ShootingState shootingState;

    float RotateAmount = 5f;
    IEnumerator Shoot()
    {
        shootingState = ShootingState.Shooting;
        if (shootingState == ShootingState.Shooting)
        {
            // loads shot
            transform.rotation = Quaternion.Lerp(transform.rotation, loadingAngle, loadingSpeed);
            yield return new WaitForSeconds(0.5f);

            // shoots shot
            transform.rotation = Quaternion.Lerp(transform.rotation, shotAngle, shotSpeed);
            yield return new WaitForSeconds(1.5f);

            // Sets default values
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, 5 * Time.deltaTime);

            shootingState = ShootingState.OutOfRange;
        }
    }

    public float RotationLeft = 360;
    float rotationspeed = 1600;
    IEnumerator Backflip()
    {
        if (shootingState == ShootingState.Backflip)
        {
            float rotation = rotationspeed * Time.deltaTime;
            if (RotationLeft > rotation)
            {
                RotationLeft -= rotation;
            }
            else
            {
                rotation = RotationLeft;
                RotationLeft = 0;
            }
            transform.Rotate(0, 0, rotation);
            yield return new WaitForSeconds(1f);
            shootingState = ShootingState.OutOfRange;
            yield return null;
        }
    }


    private void FixedUpdate()
    {
        switch (shootingState)
        {
            case ShootingState.OutOfRange:
                break;
            case ShootingState.InFrontRange:
                break;
            case ShootingState.InBackRange:
                break;
            case ShootingState.Loading:
                break;
            case ShootingState.Shooting:
                StartCoroutine(Shoot());
                break;
            case ShootingState.Backflip:
                StartCoroutine(Backflip());
                break;
            default:
                break;
        }
    }
}
