using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCard : MonoBehaviour
{
    public static SpecialCard Instance;
    public float walkspeed;
    
    public float turntiming;
    public float timecounter;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        timecounter += Time.deltaTime;
        timecounter = Mathf.Round(timecounter);
        
        
        transform.position += transform.forward * walkspeed * Time.deltaTime;
        if(timecounter >= 4)
        {
            walkspeed = 0;
            transform.Rotate(0,90,0);
        }
    }
}
