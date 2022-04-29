using System.Collections;
using UnityEngine;
public enum AIState
{
    OutOfRange,
    InFrontRange,
    InBackRange,
    Loading,
    Shooting,
    Backflip
}

public enum ShootingState
{
    Default,
    Load,
    Shot,
    Reset
}

public class PoleShooting : MonoBehaviour
{
    // Difficulty
    [SerializeField] private float loadingSpeed = 0.5f;
    [SerializeField] private float shotSpeed = 0.3f;

    // Gives the value how much we want it to rotate
    private Quaternion loadingAngle = Quaternion.Euler(0f, 0f, -45f);
    private Quaternion shotAngle = Quaternion.Euler(0f, 0f, 45f);

    public AIState AIState;
    public ShootingState ShootingState;

    float RotateAmount = 5f;


    #region New AI version
    private float speed = 1f;
    public Transform BallPosition;
    
    
    
    #endregion
    
    
    IEnumerator Shoot()
    {
        AIState = AIState.Shooting;
        if (AIState == AIState.Shooting)
        {
            switch (ShootingState)
            {
                case ShootingState.Load:
                    // loads shot
                    transform.rotation = Quaternion.Lerp(transform.rotation, loadingAngle, loadingSpeed);
                    yield return new WaitForSeconds(0.5f);
                    ShootingState = ShootingState.Shot;
                    break;
                case ShootingState.Shot:
                    // shoots shot
                    transform.rotation = Quaternion.Lerp(transform.rotation, shotAngle, shotSpeed);
                    yield return new WaitForSeconds(1.5f);
                    ShootingState = ShootingState.Reset;
                    break;
                case ShootingState.Reset:
                    // Sets default values
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, 5 * Time.deltaTime);
                    AIState = AIState.OutOfRange;
                    yield return new WaitForSeconds(1.5f);
                    ShootingState = ShootingState.Default;
                    break;
            }
        }
    }

    public float RotationLeft = 360;
    float rotationspeed = 1600;
    IEnumerator Backflip()
    {
        if (AIState == AIState.Backflip)
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
            AIState = AIState.OutOfRange;
            yield return null;
        }
    }


    private void FixedUpdate()
    {
       //switch (AIState)
       //{
       //    case AIState.OutOfRange:
       //        break;
       //    case AIState.InFrontRange:
       //        break;
       //    case AIState.InBackRange:
       //        break;
       //    case AIState.Loading:
       //        break;
       //    case AIState.Shooting:
       //        StartCoroutine(Shoot());
       //        break;
       //    case AIState.Backflip:
       //        StartCoroutine(Backflip());
       //        break;
       //}
       
       
       // new AI Version
       LookCoroutine = StartCoroutine(LookAt());
    }

    
    #region new AI verion
    private Coroutine LookCoroutine;

    public void StartRotating()
    {
        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(LookAt());
    }

    private IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(BallPosition.position - transform.position);

        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);
            time += Time.deltaTime * speed;

            yield return null;
        }
    }
    #endregion
}
