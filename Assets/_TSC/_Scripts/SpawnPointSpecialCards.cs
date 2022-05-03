using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointSpecialCards : MonoBehaviour
{
    public static SpawnPointSpecialCards instance;
    public Transform specialCardSpawnPos;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
