using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class FireTornado : Ability
{
    public static FireTornado instance;


    public GameObject characterPrefab;
    GameObject Character;

   // public Transform spawn;
   // public GameObject characterSpawn;
    private Vector3 spawnPos;
    
    private void Awake()
    {
        if (instance = null)
            instance = this;
    }

    [SerializeField] public PlayerController playerController;

    // individual code logic for this ability
    public override void Activate(GameObject parent)
    {
        Debug.Log("FireTornado activated");
        
        // the gameobject "spawnpoint" is attached to the currentPoles already. So it is always on the current pole
        GameObject spawnpoint = GameObject.Find("SpecialCard_SpawnPoint");
        Rigidbody characterRB = characterPrefab.GetComponent<Rigidbody>();

        
        
        Instantiate(characterPrefab, spawnpoint.transform.position, Quaternion.identity);

        // movement up & down
        //characterRB.MovePosition(new Vector3(0f, 0f, -playerController.movementSpecialCard.y) + characterModel.transform.position);
    }

    public override void BeginnCooldown(GameObject parent)
    {
        Debug.Log("Cooldown activated");
        Destroy(characterPrefab);
    }
}