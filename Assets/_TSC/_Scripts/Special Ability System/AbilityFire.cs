using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] 
public class AbilityFire : Ability
{
    // Prefab and spawn position of the spawned character from special card
    public GameObject characterPrefab;
    
    public override void Activate(GameObject parent)
    {
        Instantiate(characterPrefab, SpawnPointSpecialCards.instance.specialCardSpawnPos.transform.position, Quaternion.identity);
        
        
    }
}
