using System;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class Sense : MonoBehaviour
{
    public float checkRadius;
    public LayerMask checkLayers;

    public Collider closestPlayer;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        Array.Sort(colliders, new DistanceComparer(transform));

        closestPlayer = colliders[0];
        Debug.Log("Closest Enemy = " + closestPlayer);

        //foreach (Collider item in colliders)
        //{
        //    Debug.Log(item.name);
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
