using UnityEngine;

public class PolesPlayer : MonoBehaviour
{
    #region Singleton
    public static PolesPlayer Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        
        rb = GetComponent<Rigidbody>();
    }
    #endregion

    [Header("Movement")]
    public float RotationSpeed;
    public float MoveSpeed;
    public float DefaultRotationSpeed;
    public float LowSensitivityRotationSpeed;

    [Header("Ability")]
    public int Pole;
    public Ability Ability;
    
    private Rigidbody rb;
    
    // reset rotation
    private float speed = 5000f;
    public bool ResetShotSelectedPolePressed = false;
    public bool ResetShotUnselectedPolesPressed = false;
    
    private void Start()
    {
        GetAbility();
        RotationSpeed = DefaultRotationSpeed;
    }

    #region Methods -> Movement Poles
    public void MoveAndRotatePole(Vector2 movement)
    {
        movement *= 6f;

        // rotation
        Quaternion testQuaternion = new Quaternion();
        testQuaternion.eulerAngles = new Vector3(0f, 0f, -movement.x);
        //testQuaternion.eulerAngles += transform.rotation.eulerAngles;
        rb.MoveRotation(testQuaternion);

        //movement *= 6f;

        // movement up & down

        rb.MovePosition(new Vector3(0f, 0f, -movement.y));
        //rb.MovePosition(new Vector3(0f, 0f, -movement.y) + transform.position);
    }
   
    public void ResetShotSelectedPole()
    {
        if (ResetShotSelectedPolePressed == true)
        {
            var step = speed * Time.deltaTime;
            Quaternion normalQuaternion = Quaternion.identity;
            Quaternion lockedUpQuaternion = Quaternion.RotateTowards(transform.rotation, normalQuaternion, step);
            rb.MoveRotation(lockedUpQuaternion);
        }
    }
    public void ResetShotUnselectedPoles()
    {
        if (ResetShotUnselectedPolesPressed == true)
        {
            var step = speed * Time.deltaTime;
            Quaternion normalQuaternion = Quaternion.identity;
            Quaternion lockedUpQuaternion = Quaternion.RotateTowards(transform.rotation, normalQuaternion, step);
            rb.MoveRotation(lockedUpQuaternion);
        }
    }
    public void PoleFreeze()
    {
        var step = speed * Time.deltaTime;
        Quaternion normalQuaternion = Quaternion.identity;
        Quaternion lockedUpQuaternion = Quaternion.RotateTowards(transform.rotation, normalQuaternion, step);
        rb.MoveRotation(lockedUpQuaternion);
    }
    #endregion

    #region Methods -> Ability
    void GetAbility()
    {
        if(LineUpController.PlayerAbilityCardLineUP[Pole].Ability != null)
            Ability = LineUpController.PlayerAbilityCardLineUP[Pole].Ability;
    }
    #endregion
}
