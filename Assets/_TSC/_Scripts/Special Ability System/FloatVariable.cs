using System;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver 
{
    [NonSerialized]
    public float RuntimeValue;
    public float InitialValue;

    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }
}
