using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInventory : MonoBehaviour
{
    public NPCInventorySO nPCInventory;

    public void SetNPCLineUp()
    {
        LineUpController.AIDefaultCardLineUP = nPCInventory.AIDefaultCardLineUP;
        LineUpController.AIAbilityCardLineUP = nPCInventory.AIAbilityCardLineUP;

        LineUpController.MainPoleDifficulty = nPCInventory.mainPoleDifficulty;
        LineUpController.Crew1PoleDifficulty = nPCInventory.crew1PoleDifficulty;
        LineUpController.Crew2PoleDifficulty = nPCInventory.crew2PoleDifficulty;
        LineUpController.Crew3PoleDifficulty = nPCInventory.crew3PoleDifficulty;
    }
}
