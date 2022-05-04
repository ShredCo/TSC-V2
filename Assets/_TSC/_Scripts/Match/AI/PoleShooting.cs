using System;
using System.Collections;
using UnityEngine;


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

    public float speed = 1500f;
    public GameObject BallPosition;
    public Rigidbody rb;
    #endregion
    
    

   //IEnumerator Shoot()
   //{
   //    AIState = AIState.Shooting;
   //    if (AIState == AIState.Shooting)
   //    {
   //        switch (ShootingState)
   //        {
   //            case ShootingState.Load:
   //                // loads shot
   //                transform.rotation = Quaternion.Lerp(transform.rotation, loadingAngle, loadingSpeed);
   //                yield return new WaitForSeconds(0.5f);
   //                ShootingState = ShootingState.Shot;
   //                break;
   //            case ShootingState.Shot:
   //                // shoots shot
   //                transform.rotation = Quaternion.Lerp(transform.rotation, shotAngle, shotSpeed);
   //                yield return new WaitForSeconds(1.5f);
   //                ShootingState = ShootingState.Reset;
   //                break;
   //            case ShootingState.Reset:
   //                // Sets default values
   //                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, 5 * Time.deltaTime);
   //                AIState = AIState.OutOfRange;
   //                yield return new WaitForSeconds(1.5f);
   //                ShootingState = ShootingState.Default;
   //                break;
   //        }
   //    }
   //}

    public float RotationLeft = 360;
    [SerializeField]
    [Range(0f, 1f)]
    private float rotationValue = 0.5f;

   //IEnumerator Backflip()
   //{
   //    if (AIState == AIState.Backflip)
   //    {
   //        float rotation = rotationspeed * Time.deltaTime;
   //        if (RotationLeft > rotation)
   //        {
   //            RotationLeft -= rotation;
   //        }
   //        else
   //        {
   //            rotation = RotationLeft;
   //            RotationLeft = 0;
   //        }

   //        transform.Rotate(0, 0, rotation);
   //        yield return new WaitForSeconds(1f);
   //        AIState = AIState.OutOfRange;
   //        yield return null;
   //    }
   //}


   private void Awake()
   {
       rb = GetComponent<Rigidbody>();
   }

   //private void FixedUpdate()
   // {
   //    switch (AIState)
   //    {
   //        case AIState.OutOfRange:
   //            break;
   //        case AIState.InCircleRange:
   //            break;
   //        case AIState.InBackRange:
   //            break;
   //        case AIState.Loading:
   //            break;
   //        case AIState.Shooting:
   //            LookCoroutine = StartCoroutine(LookAt());
   //            break;
   //        case AIState.Backflip:
   //            //StartCoroutine(Backflip());
   //            break;
   //    }
   //
   //
   //     // new AI Version
   //     // x as rotation, y as movement
   //     
   //     
   // }


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
        var newRotation = Quaternion.LookRotation(transform.position - BallPosition.transform.position, Vector3.back);
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speed * Time.deltaTime);
        yield return new WaitForSeconds(1.5f);
    }
    
    public void MoveAndRotate(Vector2 movement)
    {
        // rotation
        Quaternion poleRotation = new Quaternion();
        poleRotation.eulerAngles = new Vector3(0f, 0f, -movement.x);
        poleRotation.eulerAngles += transform.rotation.eulerAngles;
        rb.MoveRotation(poleRotation);
    }
    
    public void MoveMainPole()
    {
        
    }
    #endregion
}
