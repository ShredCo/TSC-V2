using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxFollowPole : MonoBehaviour
{
    public GameObject Pole;
    public GameObject PlayerToFollow;
    public bool Front = true;

    void Update()
    {
        if (Front)
        {
            transform.position = new Vector3(Pole.transform.position.x - 0.035f, transform.position.y, PlayerToFollow.transform.position.z);

            Debug.Log("Position = "+transform.position.x.ToString());
        }
    }
}
