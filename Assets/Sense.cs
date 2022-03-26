using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class Sense : MonoBehaviour
{
    public float checkRadius;
    public LayerMask checkLayers;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        Array.Sort(colliders, new DistanceComparer(transform));

        foreach (Collider item in colliders)
        {
            Debug.Log(item.name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
