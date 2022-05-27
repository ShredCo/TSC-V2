using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseGravity : MonoBehaviour
{
    [SerializeField] private Vector3 tableSoccerClashGravity = new Vector3(0, -20, 0);
    private void Start()
    {
        Physics.gravity = tableSoccerClashGravity;
    }
}
