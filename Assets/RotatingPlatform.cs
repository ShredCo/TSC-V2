using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatingPlatform : MonoBehaviour
{
    
     private Vector2 rotationValue;
     [SerializeField] private GameObject cameraSkinSettings;

     // Update is called once per frame
    void Update()
    {
        if (cameraSkinSettings.active)
        {
            transform.Rotate(0, rotationValue.x, 0 * Time.deltaTime);
        }
    }
    
    public void RotateSkin(InputAction.CallbackContext context)
    {
        // x as rotation, y as movement
        rotationValue = context.ReadValue<Vector2>();
    }
}
