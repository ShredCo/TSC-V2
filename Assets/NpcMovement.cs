using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    [SerializeField]
    float walkspeed;
    [SerializeField]
    float turntiming;
    [SerializeField]
    Vector3 turnrotation;
    float timecounter;
    
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward*walkspeed * Time.deltaTime;
        timecounter += Time.deltaTime;
        if (timecounter >= turntiming)
        {
            transform.Rotate (turnrotation);
            timecounter = 0;

        }
        
        
    }
}
