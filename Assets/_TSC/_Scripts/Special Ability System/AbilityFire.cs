using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] 
public class AbilityFire : Ability
{
    [Header("movement variables")]
    [SerializeField] public float rotationSpeed = 1500.0f;
    [SerializeField] public float moveSpeed = 2.0f;
    
    public override void Activate(GameObject parent)
    {
        GameObject fireMan = GameObject.Instantiate(characterPrefab, SpawnPointSpecialCards.instance.specialCardSpawnPos.transform.position, Quaternion.identity);
        

        rb = fireMan.GetComponent<Rigidbody>();
    }
    
    public void MoveAndRotate(Vector2 movement)
    {
        // movement up & down
        rb.MovePosition(new Vector3(0f, 0f, -movement.y) + rb.transform.position);

        // Sets the default limit for the movement
        rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, Mathf.Clamp(rb.transform.position.z, -0.25f, 0.25f));

    }
}
