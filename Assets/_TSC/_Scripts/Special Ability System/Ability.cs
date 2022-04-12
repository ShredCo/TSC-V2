using UnityEngine;
using UnityEngine.Serialization;

public class Ability : ScriptableObject
{
    public new string name;
    public float cooldownTime;
    public float activeTime;

    // Prefab and spawn position of the spawned character from special card
    public GameObject characterPrefab;
    protected Rigidbody rb;

    public virtual void Activate(GameObject parent)
    {
        
    }
    public virtual void BeginnCooldown(GameObject parent) {}

}
