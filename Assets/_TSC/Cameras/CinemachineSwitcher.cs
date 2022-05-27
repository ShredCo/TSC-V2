using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum CameraState
{
    Soccerfield,
    Goal1,
    Goal2,
    SpecialAbility
}
public class CinemachineSwitcher : MonoBehaviour
{
    
    public static CinemachineSwitcher Instance;
    
    [SerializeField] private InputAction action;

    private Animator animator;
    private CameraState cameraState;

    private bool soccerfieldCamera = true;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        
        animator = GetComponent<Animator>();
        cameraState = CameraState.Soccerfield;
    }

    private void OnEnable()
    {
        action.Enable();
    }
    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        action.performed += _ => SwitchCameraGoal1();
    }

    public void SwitchCameraGoal1()
    {
        if (soccerfieldCamera)
        {
            animator.Play("CameraGoal1");
            Debug.Log("Activate CameraGoal1");
        }
        else
        {
            Debug.Log("Activate Camera Soccerfield");
            animator.Play("CameraSoccerfield");
        }
        soccerfieldCamera = !soccerfieldCamera;
    }
}
