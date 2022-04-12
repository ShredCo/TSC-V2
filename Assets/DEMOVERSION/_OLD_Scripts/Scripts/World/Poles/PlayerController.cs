using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Singleton
    public static PlayerController Instance;

    private Pole1 pole1;

    // Input System -> Input Values
    private Vector2 movementPole;
    private Vector2 movementSpecialCard;

    private PolesPlayer[] polesPlayer;
    private SpecialCharacter[] specialCharacter;
    
    // Ability
    public Ability ability;
    private float cooldownTime;
    private float activeTime;

    private GameObject arrow;
    [SerializeField] protected int currentPoleIndex;
    
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

        switch (state)
        {
            case AbilityState.ready:
                Debug.Log("Ability is now ready");
                activeTime = ability.activeTime;
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

    private void FixedUpdate()
    {
        polesPlayer[currentPoleIndex].MoveAndRotate(movementPole * Time.deltaTime);
        polesPlayer[currentPoleIndex].PoleLockedDown();
        
        specialCharacter[1].MoveAndRotate(movementSpecialCard * Time.deltaTime);
       
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
        movementPole = context.ReadValue<Vector2>();

        movementPole.x *= PolesPlayer.Instance.rotationSpeed;
        movementPole.y *= PolesPlayer.Instance.moveSpeed;
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
    
    public void MoveSpecialCardCharacter(InputAction.CallbackContext context)
    {
        movementSpecialCard = context.ReadValue<Vector2>();
        movementSpecialCard.y *= SpecialCharacter.Instance.moveSpeed;
    }

    public void AttackOtherPole(InputAction.CallbackContext context)
    {
        
    }

    #region SpawnAbility

    public GameObject SpawnPointAbility;

    public PolesPlayer PoleMain;
    public PolesPlayer PoleCrew1;
    public PolesPlayer PoleCrew2;
    public PolesPlayer PoleCrew3;

    GameObject poleMainAbility;
    GameObject poleCrew1Ability;
    GameObject poleCrew2Ability;
    GameObject poleCrew3Ability;

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
                poleMainAbility = Instantiate(PoleMain.Ability.characterPrefab, SpawnPointAbility.transform);
                poleMainAbility.transform.parent = null;
                poleMainAbility.transform.localScale = abilitySize;
                mainAbility = true;
                yield return new WaitForSeconds(PoleMain.Ability.activeTime);
                mainAbility = false;
                Destroy(poleMainAbility);
            }
            else if (currentPoleIndex == 1)
            {
                poleCrew1Ability = Instantiate(PoleCrew1.Ability.characterPrefab, SpawnPointAbility.transform);
                poleCrew1Ability.transform.parent = null;
                poleCrew1Ability.transform.localScale = abilitySize;
                crew1Ability = true;
                yield return new WaitForSeconds(PoleCrew1.Ability.activeTime);
                crew1Ability = false;
                Destroy(poleCrew1Ability);
            }
            else if (currentPoleIndex == 2)
            {
                poleCrew2Ability = Instantiate(PoleCrew2.Ability.characterPrefab, SpawnPointAbility.transform);
                poleCrew2Ability.transform.parent = null;
                poleCrew2Ability.transform.localScale = abilitySize;
                crew2Ability = true;
                yield return new WaitForSeconds(PoleCrew2.Ability.activeTime);
                crew2Ability = false;
                Destroy(poleCrew2Ability);
            }
            else if (currentPoleIndex == 3)
            {
                poleCrew3Ability = Instantiate(PoleCrew3.Ability.characterPrefab, SpawnPointAbility.transform);
                poleCrew3Ability.transform.parent = null;
                poleCrew3Ability.transform.localScale = abilitySize;
                crew3Ability = true;
                yield return new WaitForSeconds(PoleCrew3.Ability.activeTime);
                crew3Ability = false;
                Destroy(poleCrew3Ability);
            }
        }
    }

    #endregion
}
