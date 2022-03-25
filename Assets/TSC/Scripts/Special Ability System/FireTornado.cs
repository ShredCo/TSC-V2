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

    public Transform spawn;
    public GameObject characterSpawn;
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
        
        PlayerController playerController = parent.GetComponent<PlayerController>();
        Debug.Log("Vector 3 Values: " + playerController.offsetPositionCard);
        Rigidbody characterRB = characterPrefab.GetComponent<Rigidbody>();

        
        
        Instantiate(characterPrefab, playerController.offsetPositionCard, Quaternion.identity);

        // movement up & down
        //characterRB.MovePosition(new Vector3(0f, 0f, -playerController.movementSpecialCard.y) + characterModel.transform.position);
    }

    public override void BeginnCooldown(GameObject parent)
    {
        Debug.Log("Cooldown activated");
        Destroy(characterPrefab);
    }
}