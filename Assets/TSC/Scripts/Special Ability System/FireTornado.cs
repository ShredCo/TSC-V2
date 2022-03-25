using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class FireTornado : Ability
{
    public GameObject characterModel;
    
    // individual code logic for this ability
    public override void Activate(GameObject parent)
    {
        PlayerController playerController = parent.GetComponent<PlayerController>();
        Rigidbody characterRB = characterModel.GetComponent<Rigidbody>();

        Instantiate(characterModel, new Vector3(-0.3f, 0.1213f, -0.693f), Quaternion.identity);
        characterRB.velocity = playerController.movementSpecialCard.normalized * playerController.characterVelocity;
    }

    public override void BeginnCooldown(GameObject parent)
    {
        base.BeginnCooldown(parent);
    }
}