using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pole1 : MonoBehaviour
{
    public Ability ability;
    
    
    [Header("Variables")]
    public FloatVariable Pole1Health;
    
    [Header("Game Events")]
    public GameEvent PoleHit;

    
    
   void Update()
   {
       var gamepad = Gamepad.current;
       
       
   }
    
    
    // Scriptable Object stuff
    
    
    private void Damage()
    {
        Pole1Health.RuntimeValue -= 10;
        PoleHit.Raise();
    }
    
    public void AttackPole1()
    {
        Damage();
    }

  // private void OnTriggerEnter(Collider other)
  // {
  //     if (!other.CompareTag("SpecialAbility"))
  //     {
  //         return;
  //     }
  //     
  //     Destroy(other.gameObject);
  //     Damage();
  // }
}
