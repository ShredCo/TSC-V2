using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Singleton
    public static PlayerController Instance;

    private Pole1 pole1;

    // Input System -> Input Values
    private Vector2 movementPoleInput;
    private Vector2 movementAbilityInput;

    private PolesPlayer[] polesPlayer;
    private SpecialCharacter[] specialCharacter;
    
    // Ability
    public Ability ability;
    private float cooldownTime;
    private float activeTime;

    private GameObject arrow;

    protected int currentPoleIndex;
    public int powerpointsCount = 0;
    
    // Special Cards move speed;
    public float characterVelocity = 750f;
    
    
    public BallManager ball;
    
    enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    AbilityState state = AbilityState.ready;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        StartCoroutine(PlayerSpawnAbility());

        

        //switch (state)
        //{
        //    case AbilityState.ready:
        //        activeTime = ability.activeTime;
        //        break;
        //    case AbilityState.active:
        //        if (activeTime > 0)
        //            cooldownTime -= Time.deltaTime;
        //        else
        //        {
        //            ability.BeginnCooldown(gameObject);
        //            state = AbilityState.ready;
        //            cooldownTime = ability.cooldownTime;
        //        }
        //        break;
        //    case AbilityState.cooldown:
        //        if (cooldownTime > 0)
        //            cooldownTime -= Time.deltaTime;
        //        else
        //        {
        //
        //            state = AbilityState.ready;
        //        }
        //        break;
        //}
    }

    private void FixedUpdate()
    {
        if (currentPoleIndex == 0)
        {
            if (mainAbility)
            {
                polesPlayer[0].PoleFreeze();
                poleMainAbility.MoveAbilityUpAndDown(movementAbilityInput * Time.deltaTime);
            }
            else
            {
                polesPlayer[currentPoleIndex].MoveAndRotate(movementPoleInput * Time.deltaTime);
                polesPlayer[currentPoleIndex].PoleLockedDown();
            }
        }
        else if (currentPoleIndex == 1)
        {
            if (crew1Ability)
            {
                polesPlayer[1].PoleFreeze();
                poleCrew1Ability.MoveAbilityUpAndDown(movementAbilityInput * Time.deltaTime);
            }
            else
            {
                polesPlayer[currentPoleIndex].MoveAndRotate(movementPoleInput * Time.deltaTime);
                polesPlayer[currentPoleIndex].PoleLockedDown();
            }
        }
        else if (currentPoleIndex == 2)
        {
            if (crew2Ability)
            {
                polesPlayer[2].PoleFreeze();
                poleCrew2Ability.MoveAbilityUpAndDown(movementAbilityInput * Time.deltaTime);
            }
            else
            {
                polesPlayer[currentPoleIndex].MoveAndRotate(movementPoleInput * Time.deltaTime);
                polesPlayer[currentPoleIndex].PoleLockedDown();
            }
        }
        else if (currentPoleIndex == 3)
        {
            if (crew3Ability)
            {
                polesPlayer[3].PoleFreeze();
                poleCrew3Ability.MoveAbilityUpAndDown(movementAbilityInput * Time.deltaTime);
            }
            else
            {
                polesPlayer[currentPoleIndex].MoveAndRotate(movementPoleInput * Time.deltaTime);
                polesPlayer[currentPoleIndex].PoleLockedDown();
            }
        }
    }

    // NOTE: Do some more research about this topic
    // when a new player joins he receives an array of poles + an arrow to see which pole is selected
    internal void ReceivePolesPlayer(PolesPlayer[] poles)
    {
        this.polesPlayer = poles;
    }
    
    internal void ReceiveAbility(SpecialCharacter[] character)
    {
        this.specialCharacter = character;
    }

    internal void ReceiveArrow(GameObject gO)
    {
        arrow = gO;
    }



    #region Input System -> Gets the movement values from controller
    public void MoveMainPole(InputAction.CallbackContext context)
    {
        // x as rotation, y as movement
        movementPoleInput = context.ReadValue<Vector2>();

        movementPoleInput.x *= PolesPlayer.Instance.rotationSpeed;
        movementPoleInput.y *= PolesPlayer.Instance.moveSpeed;
    }

    #endregion

    #region Input System -> Gets the input for switching  poles and switches special card spawns
    public void PolesMinus(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            if (currentPoleIndex > 0)
            {
                currentPoleIndex--;

                // updates to show the current pole
                Vector3 offsetPositionArrow = polesPlayer[currentPoleIndex].transform.position;
                offsetPositionArrow.z = 0f;
                offsetPositionArrow.y = 0f;
                arrow.transform.position = offsetPositionArrow;
            }
    }

    public void PolesPlus(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            if (currentPoleIndex < polesPlayer.Length - 1)
            {
                currentPoleIndex++;

                // updates to show the current pole
                Vector3 offsetPosition = polesPlayer[currentPoleIndex].transform.position;
                offsetPosition.z = 0f;
                offsetPosition.y = 0f;
                arrow.transform.position = offsetPosition;
            }
    }
    #endregion

    #region Input System -> Gets Input to reset current pole rotation
    public void LockPoleDown(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            //Pole.Instance.lockedDownPressed = true;
            polesPlayer[currentPoleIndex].lockedDownPressed = true;
        }

        if (context.phase == InputActionPhase.Canceled)
        {
            //Pole.Instance.lockedDownPressed = false;
            polesPlayer[currentPoleIndex].lockedDownPressed = false;
        }
    }
    #endregion

    #region Input System -> Special Cards
    
    // Button North
    //public void InstantiateAbility1(InputAction.CallbackContext context)
    //{
    //    if (context.phase == InputActionPhase.Performed)
    //    {
    //        switch (state)
    //        {
    //            case AbilityState.ready:
    //                Debug.Log("Special Ability North is activated");
    //                ability.Activate(gameObject);
                    
    //                // Sets the ability on active and sets the timer for how long it is active
    //                state = AbilityState.active;
    //                activeTime = ability.activeTime;
    //                break;
    //        }
    //    }
    //}
    
    //// Button East
    //public void InstantiateAbility2(InputAction.CallbackContext context)
    //{
    //    if (context.phase == InputActionPhase.Performed)
    //    {
    //        switch (state)
    //        {
    //            case AbilityState.ready:
    //                Debug.Log("Special Ability East is activated");

                    
    //                state = AbilityState.active;
    //                activeTime = ability.activeTime;
    //                break;
    //        }
    //    }
    //}
    
    // Button South
    //public void InstantiateAbility3(InputAction.CallbackContext context)
    //{
    //    if (context.phase == InputActionPhase.Performed)
    //    {
    //        switch (state)
    //        {
    //            case AbilityState.ready:
    //                Debug.Log("Special Ability South is activated");

                    
    //                state = AbilityState.active;
    //                activeTime = ability.activeTime;
    //                break;
    //        }
    //    }
    //}
    
    // Button West
    //public void InstantiateAbility4(InputAction.CallbackContext context)
    //{
    //    if (context.phase == InputActionPhase.Performed)
    //    {
    //        switch (state)
    //        {
    //            case AbilityState.ready:
    //                Debug.Log("Special Ability West is activated");

                    
    //                state = AbilityState.active;
    //                activeTime = ability.activeTime;
    //                break;
    //        }
    //    }
    //}
    
    #endregion
    
    public void MoveAbility(InputAction.CallbackContext context)
    {
        movementAbilityInput = context.ReadValue<Vector2>();
        movementAbilityInput.y *= SpecialCharacter.Instance.moveSpeed;
    }

    #region SpawnAbility

    public GameObject SpawnPointAbility;

    public PolesPlayer PoleMain;
    public PolesPlayer PoleCrew1;
    public PolesPlayer PoleCrew2;
    public PolesPlayer PoleCrew3;

    GameObject poleMainAbilityPrefab;
    GameObject poleCrew1AbilityPrefab;
    GameObject poleCrew2AbilityPrefab;
    GameObject poleCrew3AbilityPrefab;

    SpecialCharacter poleMainAbility;
    SpecialCharacter poleCrew1Ability;
    SpecialCharacter poleCrew2Ability;
    SpecialCharacter poleCrew3Ability;

    bool mainAbility = false;
    bool crew1Ability = false;
    bool crew2Ability = false;
    bool crew3Ability = false;

    Vector3 abilitySize = new Vector3(0.07f, 0.07f, 0.07f);
    
    IEnumerator PlayerSpawnAbility()
    {
        var gamepad = Gamepad.current;
        if (gamepad.buttonNorth.wasPressedThisFrame)
        {
            if (currentPoleIndex == 0 && mainAbility == false)
            {
                poleMainAbilityPrefab = Instantiate(PoleMain.Ability.characterPrefab, SpawnPointAbility.transform);
                poleMainAbilityPrefab.transform.parent = null;
                poleMainAbilityPrefab.transform.localScale = abilitySize;
                poleMainAbility = poleMainAbilityPrefab.GetComponent<SpecialCharacter>();
                mainAbility = true;
                yield return new WaitForSeconds(PoleMain.Ability.activeTime);
                mainAbility = false;
                Destroy(poleMainAbilityPrefab);
            }
            else if (currentPoleIndex == 1 && crew1Ability == false)
            {
                poleCrew1AbilityPrefab = Instantiate(PoleCrew1.Ability.characterPrefab, SpawnPointAbility.transform);
                poleCrew1AbilityPrefab.transform.parent = null;
                poleCrew1AbilityPrefab.transform.localScale = abilitySize;
                poleCrew1Ability = poleCrew1AbilityPrefab.GetComponent<SpecialCharacter>();
                crew1Ability = true;
                yield return new WaitForSeconds(PoleCrew1.Ability.activeTime);
                crew1Ability = false;
                Destroy(poleCrew1AbilityPrefab);
            }
            else if (currentPoleIndex == 2 && crew2Ability == false)
            {
                poleCrew2AbilityPrefab = Instantiate(PoleCrew2.Ability.characterPrefab, SpawnPointAbility.transform);
                poleCrew2AbilityPrefab.transform.parent = null;
                poleCrew2AbilityPrefab.transform.localScale = abilitySize;
                poleCrew2Ability = poleCrew2AbilityPrefab.GetComponent<SpecialCharacter>();
                crew2Ability = true;
                yield return new WaitForSeconds(PoleCrew2.Ability.activeTime);
                crew2Ability = false;
                Destroy(poleCrew2AbilityPrefab);
            }
            else if (currentPoleIndex == 3 && crew3Ability == false)
            {
                poleCrew3AbilityPrefab = Instantiate(PoleCrew3.Ability.characterPrefab, SpawnPointAbility.transform);
                poleCrew3AbilityPrefab.transform.parent = null;
                poleCrew3AbilityPrefab.transform.localScale = abilitySize;
                poleCrew3Ability = poleCrew3AbilityPrefab.GetComponent<SpecialCharacter>();
                crew3Ability = true;
                yield return new WaitForSeconds(PoleCrew3.Ability.activeTime);
                crew3Ability = false;
                Destroy(poleCrew3AbilityPrefab);
            }
        }
    }

    #endregion
}
