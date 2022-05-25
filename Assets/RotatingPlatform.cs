using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatingPlatform : MonoBehaviour
{
    
     private Vector2 rotationValue;
     [SerializeField] private GameObject cameraSkinSettings;
     [SerializeField] private MainCharacterCreator mainCharacterCreator;

     private Vector3 showHead = new Vector3(0,0, -2.5f);
     private Vector3 showUpperBody = new Vector3(0,0.5f, -2.5f);
     private Vector3 showLegs = new Vector3(0,1.3f, -2.5f);
     private Vector3 startPosition;
     private float desiredDuration = 3f;
     private float elapsedTime;

     private void Start()
     {
         startPosition = transform.position;
     }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredDuration;
        
        if (cameraSkinSettings.active)
        {
            transform.Rotate(0, rotationValue.x, 0 * Time.deltaTime);
        }

        if (mainCharacterCreator.CurrentBodypartIndex < 4)
        {
            transform.position = Vector3.Lerp(transform.position, showHead, 3f * Time.deltaTime);
        }
        if (mainCharacterCreator.CurrentBodypartIndex == 4)
        {
            transform.position = Vector3.Lerp(transform.position, showUpperBody, 3f * Time.deltaTime);
        }
        if (mainCharacterCreator.CurrentBodypartIndex == 5)
        {
            transform.position = Vector3.Lerp(transform.position, showLegs, 3f * Time.deltaTime);
        }
    }
    
    public void RotateSkin(InputAction.CallbackContext context)
    {
        // x as rotation, y as movement
        rotationValue = context.ReadValue<Vector2>();
    }
}
