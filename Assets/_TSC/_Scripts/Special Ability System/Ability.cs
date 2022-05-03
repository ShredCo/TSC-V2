using UnityEngine;
using UnityEngine.Serialization;

public class Ability : ScriptableObject
{
    public string Name;
    public float CooldownTime;
    public float ActiveTime;
    public int PowerpointsCost;
    
    // Prefab and spawn position of the spawned character from special card
    public GameObject CharacterPrefab;
    public GameObject AbilityPrefab;
    protected Rigidbody rb;

    public virtual void Activate(GameObject parent)
    {
        
    }
    public virtual void BeginnCooldown(GameObject parent)
    {
        
    }
}
