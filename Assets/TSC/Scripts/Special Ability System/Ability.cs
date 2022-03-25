using UnityEngine;
using UnityEngine.Serialization;

public class Ability : ScriptableObject
{
    public new string name;
    public float cooldownTime;
    public float activeTime;

    public virtual void Activate(GameObject parent) {}
    public virtual void BeginnCooldown(GameObject parent) {}

}
