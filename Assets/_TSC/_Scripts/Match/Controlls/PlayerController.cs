using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Singleton
    public static PlayerController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion

    #region Variables / References
    // Input System -> Input Values
    private Vector2 movementPoleInput;
    private Vector2 movementAbilityInput;
    private Vector2 rotationWindAbilityInput;

    private PolesPlayer[] polesPlayer;
    private SpecialCharacter[] specialCharacter;

    private GameObject steeringWheelPole;

    public int currentPoleIndex;

    // Ability Cards move speed;
    public float characterVelocity = 750f;

    public BallManager ball;
    #endregion

    private void FixedUpdate()
    {
        if (currentPoleIndex == 0) // check for active pole
        {
            if (mainAbility) // check if ability is active, move ability instead of pole
            {
                polesPlayer[0].PoleFreeze();
                poleMainAbility.MoveAbilityUpAndDown(movementAbilityInput * Time.deltaTime);

                if (rotationWindAbilityInput.x > 0.1f || rotationWindAbilityInput.y > 0.1f)
                {
                    poleMainAbilityPrefabVFX.transform.localEulerAngles = new Vector3(0f, Mathf.Atan2(-rotationWindAbilityInput.x, -rotationWindAbilityInput.y) * 180 / Mathf.PI, 0f);
                }

                poleMainAbilityPrefabVFX.transform.position = poleMainAbility.transform.position;
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

                if (rotationWindAbilityInput.x > 0.1f || rotationWindAbilityInput.y > 0.1f)
                {
                    crewPole1AbilityPrefabVFX.transform.localEulerAngles = new Vector3(0f, Mathf.Atan2(-rotationWindAbilityInput.x, -rotationWindAbilityInput.y) * 180 / Mathf.PI, 0f);
                }

                crewPole1AbilityPrefabVFX.transform.position = poleCrew1Ability.transform.position;
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

                if (rotationWindAbilityInput.x > 0.1f || rotationWindAbilityInput.y > 0.1f)
                {
                    crewPole2AbilityPrefabVFX.transform.localEulerAngles = new Vector3(0f, Mathf.Atan2(-rotationWindAbilityInput.x, -rotationWindAbilityInput.y) * 180 / Mathf.PI, 0f);
                }

                crewPole2AbilityPrefabVFX.transform.position = poleCrew2Ability.transform.position;
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

                if (rotationWindAbilityInput.x > 0.1f || rotationWindAbilityInput.y > 0.1f)
                {
                    crewPole3AbilityPrefabVFX.transform.localEulerAngles = new Vector3(0f, Mathf.Atan2(-rotationWindAbilityInput.x, -rotationWindAbilityInput.y) * 180 / Mathf.PI, 0f);
                }

                crewPole3AbilityPrefabVFX.transform.position = poleCrew3Ability.transform.position;
            }
            else
            {
                polesPlayer[currentPoleIndex].MoveAndRotate(movementPoleInput * Time.deltaTime);
                polesPlayer[currentPoleIndex].PoleLockedDown();
            }
        }
    }

    #region Player Set Up
    internal void ReceivePolesPlayer(PolesPlayer[] poles)
    {
        this.polesPlayer = poles;
        Debug.Log("Added Poles to " + this.gameObject);
    }

    internal void ReceiveAbility(SpecialCharacter[] character)
    {
        this.specialCharacter = character;
    }

    internal void ReceiveArrow(GameObject gO)
    {
        steeringWheelPole = gO;
    }
    #endregion

    #region Input System -> Gets the movement values from controller

    public void MoveMainPole(InputAction.CallbackContext context)
    {
        // x as rotation, y as movement
        movementPoleInput = context.ReadValue<Vector2>();

        movementPoleInput.x *= PolesPlayer.Instance.RotationSpeed;
        movementPoleInput.y *= PolesPlayer.Instance.MoveSpeed;
    }

    #endregion

    #region Input System -> Gets the input for switching poles and switches special card spawns

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
                steeringWheelPole.transform.position = offsetPositionArrow;
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
                steeringWheelPole.transform.position = offsetPosition;
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

    #region Ability Cards System

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

    GameObject poleMainAbilityPrefabVFX;
    GameObject crewPole1AbilityPrefabVFX;
    GameObject crewPole2AbilityPrefabVFX;
    GameObject crewPole3AbilityPrefabVFX;

    Vector3 abilitySize = new Vector3(1f, 1f, 1f);
    
    public void MoveAbility(InputAction.CallbackContext context)
    {
        movementAbilityInput = context.ReadValue<Vector2>();
    }

    public void RotateWind(InputAction.CallbackContext context)
    {
        rotationWindAbilityInput = context.ReadValue<Vector2>();
    }

    #region Input System -> Special Cards
    // Spawn the Special Cards
    public void SpecialCard_MainPole(InputAction.CallbackContext context)
    {
        StartCoroutine(MainPole_AbilityCharacter());
    }
    public void SpecialCard_CrewPole1(InputAction.CallbackContext context)
    {
        StartCoroutine(CrewPole1_AbilityCharacter());
    }
    public void SpecialCard_CrewPole2(InputAction.CallbackContext context)
    {
        StartCoroutine(CrewPole2_AbilityCharacter());
    }
    public void SpecialCard_CrewPole3(InputAction.CallbackContext context)
    {
        StartCoroutine(CrewPole3_AbilityCharacter());
    }
    #endregion
    
    #region Input System -> Abilitys
    // Activate abilitys from the Special Cards
    public void Ability_MainPole(InputAction.CallbackContext context)
    {
        MainPole_Ability();
    }
    public void Ability_CrewPole1(InputAction.CallbackContext context)
    {
        CrewPole1_Ability();
    }
    public void Ability_CrewPole2(InputAction.CallbackContext context)
    {
        CrewPole2_Ability();
    }
    public void Ability_CrewPole3(InputAction.CallbackContext context)
    {
        CrewPole3_Ability();
    }
    #endregion
    
    #region Methods Special Cards -> Characters
    // Main Pole
    IEnumerator MainPole_AbilityCharacter()
    {
        Debug.Log("main ability = " + mainAbility);
        if (currentPoleIndex == 0 && mainAbility == false)
        {
            if (GameManagerSoccermatch.Instance.powerpointsCountRed >= PoleMain.Ability.PowerpointsCost)
            {
                // Instantiates special card character on main pole
                GameManagerSoccermatch.Instance.powerpointsCountRed -= PoleMain.Ability.PowerpointsCost;
                poleMainAbilityPrefab = Instantiate(PoleMain.Ability.CharacterPrefab, SpawnPointAbility.transform);
                poleMainAbilityPrefab.transform.parent = null;
                poleMainAbilityPrefab.transform.localScale = abilitySize;
                poleMainAbility = poleMainAbilityPrefab.GetComponent<SpecialCharacter>();
                mainAbility = true;
                yield return new WaitForSeconds(PoleMain.Ability.ActiveTime);
                mainAbility = false;
                Destroy(poleMainAbilityPrefabVFX);
                Destroy(poleMainAbilityPrefab);
            }
        }
    }
    // Pole 1
    IEnumerator CrewPole1_AbilityCharacter()
    {
        if (currentPoleIndex == 1 && crew1Ability == false)
        {
            if (GameManagerSoccermatch.Instance.powerpointsCountRed >= PoleCrew1.Ability.PowerpointsCost)
            {
                // Instantiates special card character on crew pole 1
                GameManagerSoccermatch.Instance.powerpointsCountRed -= PoleCrew1.Ability.PowerpointsCost;
                poleCrew1AbilityPrefab = Instantiate(PoleCrew1.Ability.CharacterPrefab, SpawnPointAbility.transform);
                poleCrew1AbilityPrefab.transform.parent = null;
                poleCrew1AbilityPrefab.transform.localScale = abilitySize;
                poleCrew1Ability = poleCrew1AbilityPrefab.GetComponent<SpecialCharacter>();
                crew1Ability = true;
                yield return new WaitForSeconds(PoleCrew1.Ability.ActiveTime);
                crew1Ability = false;
                Destroy(crewPole1AbilityPrefabVFX);
                Destroy(poleCrew1AbilityPrefab);
            }
        }
    }
    IEnumerator CrewPole2_AbilityCharacter()
    {
        if (currentPoleIndex == 2 && crew2Ability == false)
        {
            if (GameManagerSoccermatch.Instance.powerpointsCountRed >= PoleCrew2.Ability.PowerpointsCost)
            {
                // Instantiates special card character on crew pole 2
                GameManagerSoccermatch.Instance.powerpointsCountRed -= PoleCrew2.Ability.PowerpointsCost;
                poleCrew2AbilityPrefab = Instantiate(PoleCrew2.Ability.CharacterPrefab, SpawnPointAbility.transform);
                poleCrew2AbilityPrefab.transform.parent = null;
                poleCrew2AbilityPrefab.transform.localScale = abilitySize;
                poleCrew2Ability = poleCrew2AbilityPrefab.GetComponent<SpecialCharacter>();
                crew2Ability = true;
                yield return new WaitForSeconds(PoleCrew2.Ability.ActiveTime);
                crew2Ability = false;
                Destroy(crewPole2AbilityPrefabVFX);
                Destroy(poleCrew2AbilityPrefab);
            }
        }
    }
    IEnumerator CrewPole3_AbilityCharacter()
    {
        if (currentPoleIndex == 3 && crew3Ability == false)
        {
            if (GameManagerSoccermatch.Instance.powerpointsCountRed >= PoleCrew3.Ability.PowerpointsCost)
            {
                // Instantiates special card character on crew pole 3
                GameManagerSoccermatch.Instance.powerpointsCountRed -= PoleCrew3.Ability.PowerpointsCost;
                poleCrew3AbilityPrefab = Instantiate(PoleCrew3.Ability.CharacterPrefab, SpawnPointAbility.transform);
                poleCrew3AbilityPrefab.transform.parent = null;
                poleCrew3AbilityPrefab.transform.localScale = abilitySize;
                poleCrew3Ability = poleCrew3AbilityPrefab.GetComponent<SpecialCharacter>();
                crew3Ability = true;
                yield return new WaitForSeconds(PoleCrew3.Ability.ActiveTime);
                crew3Ability = false;
                Destroy(crewPole3AbilityPrefabVFX);
                Destroy(poleCrew3AbilityPrefab);
            }
        }
    }
    #endregion
    
    #region Methods Special Cards -> Abilitys
    void MainPole_Ability()
    {
        if (mainAbility == true && poleMainAbilityPrefabVFX == null)
        {
            poleMainAbilityPrefabVFX = Instantiate(PoleMain.Ability.AbilityPrefab);
        }
    }
    void CrewPole1_Ability()
    {
        if (crew1Ability == true && crewPole1AbilityPrefabVFX == null)
        {
            crewPole1AbilityPrefabVFX = Instantiate(PoleCrew1.Ability.AbilityPrefab);
        }
    }
    void CrewPole2_Ability()
    {
        if (crew2Ability == true && crewPole2AbilityPrefabVFX == null)
        {
            crewPole2AbilityPrefabVFX = Instantiate(PoleCrew2.Ability.AbilityPrefab);
        }
    }
    void CrewPole3_Ability()
    {
        if (crew3Ability == true && crewPole3AbilityPrefabVFX == null)
        {
            crewPole3AbilityPrefabVFX = Instantiate(PoleCrew3.Ability.AbilityPrefab);
        }
    }
    #endregion

    #endregion
}