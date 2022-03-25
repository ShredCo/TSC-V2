using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    private float cooldownTime;
    private float activeTime;

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    AbilityState state = AbilityState.ready;
    
    void Update()
    {
        var gamepad = Gamepad.current;
        
        switch (state)
        {
            case AbilityState.ready:
                if (gamepad.buttonWest.wasPressedThisFrame)
                {
                    ability.Activate(gameObject);
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                }
                break;
            case AbilityState.active:
                if (activeTime > 0)
                    cooldownTime -= Time.deltaTime;
                else
                {
                    ability.BeginnCooldown(gameObject);
                    state = AbilityState.ready;
                    cooldownTime = ability.cooldownTime;
                }
                    break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                    cooldownTime -= Time.deltaTime;
                else
                {
                    state = AbilityState.ready;
                }
                break;
        }
        
        
        
    }
}
