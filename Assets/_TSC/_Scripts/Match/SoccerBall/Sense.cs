using System;
using UnityEngine;

public class Sense : MonoBehaviour
{
    [SerializeField] private LayerMask checkLayers;
    [SerializeField] private float checkRadius;
    
    public Collider ClosestPlayer;

    private void Update()
    {
        // Makes an array and gets the distance of the ball and the other enemy player position
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        Array.Sort(colliders, new DistanceComparer(transform));

        if(colliders.Length > 0)
            ClosestPlayer = colliders[0];
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
