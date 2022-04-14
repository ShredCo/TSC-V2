using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PolesPlayer : MonoBehaviour
{
    // Singleton
    public static PolesPlayer Instance;

    Rigidbody rb;

    [Header("movement variables")]
    [SerializeField] public float rotationSpeed = 1500.0f;
    [SerializeField] public float moveSpeed = 2.0f;
    // speed of go back to normal rotation when resetet back
    float speed = 5000f;
    public bool lockedDownPressed = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GetAbility();
    }

    public void MoveAndRotate(Vector2 movement)
    {
        // rotation
        Quaternion testQuaternion = new Quaternion();
        testQuaternion.eulerAngles = new Vector3(0f, 0f, -movement.x);
        testQuaternion.eulerAngles += transform.rotation.eulerAngles;
        rb.MoveRotation(testQuaternion);

        // movement up & down
        rb.MovePosition(new Vector3(0f, 0f, -movement.y) + transform.position);

        // Sets the default limit for the movement
        rb.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -0.25f, 0.25f));
    }
    
    public void PoleLockedDown()
    {
        if (lockedDownPressed == true)
        {
            Debug.Log("locked down method used");
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

    #region Ability
    public int Pole;
    public Ability Ability;
    void GetAbility()
    {
        Ability = LineUpController.PlayerAbilityCardLineUP[Pole].Ability;
    }

    #endregion
}
