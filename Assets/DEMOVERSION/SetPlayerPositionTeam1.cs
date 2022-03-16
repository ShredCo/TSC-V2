using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPositionTeam1 : MonoBehaviour
{
    [Header("Scripts")]
    public InventoryUIManager myInventoryUIManager;

    #region Set Characters Team 1
    #region Set Character pos1
    public void ActivateGeisha01()
    {
        if (Inventory.instance.geisha == true)
        {
            Inventory.instance.pos1 = "Geisha"; 
            PlayerPrefs.SetString("pos1", Inventory.instance.pos1);
            myInventoryUIManager.UpdateLineUpText1();
            myInventoryUIManager.ClosePanel1();
        }
    }
    public void ActivateNinja01()
    {
        if (Inventory.instance.ninja == true)
        {
            Inventory.instance.pos1 = "Ninja";
            PlayerPrefs.SetString("pos2", Inventory.instance.pos2);
            myInventoryUIManager.UpdateLineUpText1();
            myInventoryUIManager.ClosePanel1();
        }
    }
    public void ActivateSamuraiGrunt01()
    {
        if (Inventory.instance.samuraiGrunt == true) 
        {
            Inventory.instance.pos1 = "Samurai Grunt";
            PlayerPrefs.SetString("pos3", Inventory.instance.pos3);
            myInventoryUIManager.UpdateLineUpText1();
            myInventoryUIManager.ClosePanel1();
        }
    }
    public void ActivateSamuraiWarrior01()
    {
        if (Inventory.instance.samuraiWarrior == true) 
        {
            Inventory.instance.pos1 = "Samurai Warrior";
            PlayerPrefs.SetString("pos4", Inventory.instance.pos4);
            myInventoryUIManager.UpdateLineUpText1();
            myInventoryUIManager.ClosePanel1();
        }
    }
    public void ActivateSensei01()
    {
        if (Inventory.instance.sensei == true) 
        {
            Inventory.instance.pos1 = "Sensei";
            PlayerPrefs.SetString("pos5", Inventory.instance.pos5);
            myInventoryUIManager.UpdateLineUpText1();
            myInventoryUIManager.ClosePanel1();  
        }
    }
    public void ActivateVillageMan01()
    {
        if (Inventory.instance.villageMan == true) 
        {
            Inventory.instance.pos1 = "Village Man";
            PlayerPrefs.SetString("pos6", Inventory.instance.pos6);
            myInventoryUIManager.UpdateLineUpText1();
            myInventoryUIManager.ClosePanel1();
        }
    }
    public void ActivateVillageWoman01()
    {
        if (Inventory.instance.villageWoman == true) 
        {
            Inventory.instance.pos1 = "Village Woman";
            PlayerPrefs.SetString("pos7", Inventory.instance.pos7);
            myInventoryUIManager.UpdateLineUpText1();
            myInventoryUIManager.ClosePanel1();
        }
    }
    #endregion

    #region Set Character pos2
    public void ActivateGeisha02() 
    { 
        if (Inventory.instance.geisha == true) 
        {
            Inventory.instance.pos2 = "Geisha"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText2();
            myInventoryUIManager.ClosePanel2();
        } 
    }
    public void ActivateNinja02()
    { 
        if (Inventory.instance.ninja == true) 
        {
            Inventory.instance.pos2 = "Ninja"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText2();
            myInventoryUIManager.ClosePanel2();
        } 
    }
    public void ActivateSamuraiGrunt02() 
    { 
        if (Inventory.instance.samuraiGrunt == true) 
        {
            Inventory.instance.pos2 = "Samurai Grunt"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText2();
            myInventoryUIManager.ClosePanel2();
        }
    }
    public void ActivateSamuraiWarrior02() 
    { 
        if (Inventory.instance.samuraiWarrior == true) 
        {
            Inventory.instance.pos2 = "Samurai Warrior"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText2();
            myInventoryUIManager.ClosePanel2();
        } 
    }
    public void ActivateSensei02() 
    { 
        if (Inventory.instance.sensei == true) 
        {
            Inventory.instance.pos2 = "Sensei"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText2();
            myInventoryUIManager.ClosePanel2();
        } 
    }
    public void ActivateVillageMan02() 
    { 
        if (Inventory.instance.villageMan == true) 
        {
            Inventory.instance.pos2 = "Village Man"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText2();
            myInventoryUIManager.ClosePanel2();
        } 
    }
    public void ActivateVillageWoman02() 
    { 
        if (Inventory.instance.villageWoman == true) 
        {
            Inventory.instance.pos2 = "Village Woman"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText2();
            myInventoryUIManager.ClosePanel2();
        } 
    }
    #endregion

    #region Set Character pos3
    public void ActivateGeisha03() 
    { 
        if (Inventory.instance.geisha == true) 
        {
            Inventory.instance.pos3 = "Geisha"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText3();
            myInventoryUIManager.ClosePanel3();
        } 
    }
    public void ActivateNinja03() 
    { 
        if (Inventory.instance.ninja == true) 
        {
            Inventory.instance.pos3 = "Ninja"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText3();
            myInventoryUIManager.ClosePanel3();
        } 
    }
    public void ActivateSamuraiGrunt03() 
    { 
        if (Inventory.instance.samuraiGrunt == true) 
        {
            Inventory.instance.pos3 = "Samurai Grunt"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText3();
            myInventoryUIManager.ClosePanel3();
        } 
    }
    public void ActivateSamuraiWarrior03() 
    { 
        if (Inventory.instance.samuraiWarrior == true)
        {
            Inventory.instance.pos3 = "Samurai Warrior"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText3();
            myInventoryUIManager.ClosePanel3();
        } 
    }
    public void ActivateSensei03() 
    { 
        if (Inventory.instance.sensei == true)
        {
            Inventory.instance.pos3 = "Sensei"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText3();
            myInventoryUIManager.ClosePanel3();
        } 
    }
    public void ActivateVillageMan03() 
    { 
        if (Inventory.instance.villageMan == true) 
        {
            Inventory.instance.pos3 = "Village Man"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText3();
            myInventoryUIManager.ClosePanel3();
        } 
    }
    public void ActivateVillageWoman03() 
    { 
        if (Inventory.instance.villageWoman == true) 
        {
            Inventory.instance.pos3 = "Village Woman"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText3();
            myInventoryUIManager.ClosePanel3();
        } 
    }
    #endregion

    #region Set Character pos4
    public void ActivateGeisha04() 
    { 
        if (Inventory.instance.geisha == true)
        {
            Inventory.instance.pos4 = "Geisha"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText4();
            myInventoryUIManager.ClosePanel4();
        } 
    }
    public void ActivateNinja04() 
    { 
        if (Inventory.instance.ninja == true) 
        {
            Inventory.instance.pos4 = "Ninja"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText4();
            myInventoryUIManager.ClosePanel4();
        } 
    }
    public void ActivateSamuraiGrunt04() 
    { 
        if (Inventory.instance.samuraiGrunt == true) 
        {
            Inventory.instance.pos4 = "Samurai Grunt"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText4();
            myInventoryUIManager.ClosePanel4();
        } 
    }
    public void ActivateSamuraiWarrior04() 
    { 
        if (Inventory.instance.samuraiWarrior == true) 
        {
            Inventory.instance.pos4 = "Samurai Warrior"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText4();
            myInventoryUIManager.ClosePanel4();
        } 
    }
    public void ActivateSensei04() 
    { 
        if (Inventory.instance.sensei == true) 
        {
            Inventory.instance.pos4 = "Sensei"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText4();
            myInventoryUIManager.ClosePanel4();
        } 
    }
    public void ActivateVillageMan04() 
    { 
        if (Inventory.instance.villageMan == true) 
        {
            Inventory.instance.pos4 = "Village Man"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText4();
            myInventoryUIManager.ClosePanel4();
        } 
    }
    public void ActivateVillageWoman04() 
    { 
        if (Inventory.instance.villageWoman == true) 
        {
            Inventory.instance.pos4 = "Village Woman"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText4();
            myInventoryUIManager.ClosePanel4();
        } 
    }
    #endregion

    #region Set Character pos5
    public void ActivateGeisha05() 
    {
        if (Inventory.instance.geisha == true) 
        {
            Inventory.instance.pos5 = "Geisha"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText5();
            myInventoryUIManager.ClosePanel5();
        } 
    }
    public void ActivateNinja05() 
    { 
        if (Inventory.instance.ninja == true) 
        {
            Inventory.instance.pos5 = "Ninja"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText5();
            myInventoryUIManager.ClosePanel5();
        } 
    }
    public void ActivateSamuraiGrunt05() 
    { 
        if (Inventory.instance.samuraiGrunt == true) 
        {
            Inventory.instance.pos5 = "Samurai Grunt"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText5();
            myInventoryUIManager.ClosePanel5();
        } 
    }
    public void ActivateSamuraiWarrior05() 
    { 
        if (Inventory.instance.samuraiWarrior == true) 
        {
            Inventory.instance.pos5 = "Samurai Warrior"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText5();
            myInventoryUIManager.ClosePanel5();
        } 
    }
    public void ActivateSensei05() 
    { 
        if (Inventory.instance.sensei == true) 
        {
            Inventory.instance.pos5 = "Sensei"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText5();
            myInventoryUIManager.ClosePanel5();
        } 
    }
    public void ActivateVillageMan05() 
    { 
        if (Inventory.instance.villageMan == true)
        {
            Inventory.instance.pos5 = "Village Man"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText5();
            myInventoryUIManager.ClosePanel5();
        } 
    }
    public void ActivateVillageWoman05()
    { 
        if (Inventory.instance.villageWoman == true) 
        {
            Inventory.instance.pos5 = "Village Woman"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText5();
            myInventoryUIManager.ClosePanel5();
        }
    }
    #endregion

    #region Set Character pos6
    public void ActivateGeisha06() 
    { 
        if (Inventory.instance.geisha == true)
        {
            Inventory.instance.pos6 = "Geisha"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText6();
            myInventoryUIManager.ClosePanel6();
        } 
    }
    public void ActivateNinja06() 
    { 
        if (Inventory.instance.ninja == true)
        {
            Inventory.instance.pos6 = "Ninja"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText6();
            myInventoryUIManager.ClosePanel6();
        }
    }
    public void ActivateSamuraiGrunt06() 
    { 
        if (Inventory.instance.samuraiGrunt == true) 
        {
            Inventory.instance.pos6 = "Samurai Grunt"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText6();
            myInventoryUIManager.ClosePanel6();
        } 
    }
    public void ActivateSamuraiWarrior06() 
    { 
        if (Inventory.instance.samuraiWarrior == true) 
        {
            Inventory.instance.pos6 = "Samurai Warrior"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText6();
            myInventoryUIManager.ClosePanel6();
        }
    }
    public void ActivateSensei06() 
    { 
        if (Inventory.instance.sensei == true) 
        {
            Inventory.instance.pos6 = "Sensei"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText6();
            myInventoryUIManager.ClosePanel6();
        } 
    }
    public void ActivateVillageMan06() 
    { 
        if (Inventory.instance.villageMan == true) 
        {
            Inventory.instance.pos6 = "Village Man"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText6();
            myInventoryUIManager.ClosePanel6();
        }
    }
    public void ActivateVillageWoman06() 
    { 
        if (Inventory.instance.villageWoman == true) 
        {
            Inventory.instance.pos6 = "Village Woman"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText6();
            myInventoryUIManager.ClosePanel6();
        } 
    }
    #endregion

    #region Set Character pos7
    public void ActivateGeisha07() 
    { 
        if (Inventory.instance.geisha == true) 
        {
            Inventory.instance.pos7 = "Geisha"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText7();
            myInventoryUIManager.ClosePanel7();
        } 
    }
    public void ActivateNinja07() 
    { 
        if (Inventory.instance.ninja == true) 
        {
            Inventory.instance.pos7 = "Ninja"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText7();
            myInventoryUIManager.ClosePanel7();
        }
    }
    public void ActivateSamuraiGrunt07() 
    {
        if (Inventory.instance.samuraiGrunt == true) 
        {
            Inventory.instance.pos7 = "Samurai Grunt"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText7();
            myInventoryUIManager.ClosePanel7();
        } 
    }
    public void ActivateSamuraiWarrior07() 
    { 
        if (Inventory.instance.samuraiWarrior == true)
        {
            Inventory.instance.pos7 = "Samurai Warrior"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText7();
            myInventoryUIManager.ClosePanel7();
        } 
    }
    public void ActivateSensei07() 
    { 
        if (Inventory.instance.sensei == true) 
        {
            Inventory.instance.pos7 = "Sensei"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText7();
            myInventoryUIManager.ClosePanel7();
        }
    }
    public void ActivateVillageMan07() 
    { 
        if (Inventory.instance.villageMan == true) 
        {
            Inventory.instance.pos7 = "Village Man"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText7();
            myInventoryUIManager.ClosePanel7();
        }
    }
    public void ActivateVillageWoman07() 
    {
        if (Inventory.instance.villageWoman == true)
        {
            Inventory.instance.pos7 = "Village Woman"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText7();
            myInventoryUIManager.ClosePanel7();
        }
    }
    #endregion

    #region Set Character pos8
    public void ActivateGeisha08() 
    { 
        if (Inventory.instance.geisha == true) 
        {
            Inventory.instance.pos8 = "Geisha"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText8();
            myInventoryUIManager.ClosePanel8();
        } 
    }
    public void ActivateNinja08() 
    { 
        if (Inventory.instance.ninja == true)
        {
            Inventory.instance.pos8 = "Ninja"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText8();
            myInventoryUIManager.ClosePanel8();
        } 
    }
    public void ActivateSamuraiGrunt08() 
    { 
        if (Inventory.instance.samuraiGrunt == true) 
        {
            Inventory.instance.pos8 = "Samurai Grunt"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText8();
            myInventoryUIManager.ClosePanel8();
        }
    }
    public void ActivateSamuraiWarrior08() 
    { 
        if (Inventory.instance.samuraiWarrior == true)
        {
            Inventory.instance.pos8 = "Samurai Warrior"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText8();
            myInventoryUIManager.ClosePanel8();
        } 
    }
    public void ActivateSensei08() 
    { 
        if (Inventory.instance.sensei == true) 
        {
            Inventory.instance.pos8 = "Sensei"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText8();
            myInventoryUIManager.ClosePanel8();
        } 
    }
    public void ActivateVillageMan08() 
    { 
        if (Inventory.instance.villageMan == true) 
        {
            Inventory.instance.pos8 = "Village Man"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText8();
            myInventoryUIManager.ClosePanel8();
        } 
    }
    public void ActivateVillageWoman08() 
    { 
        if (Inventory.instance.villageWoman == true) 
        {
            Inventory.instance.pos8 = "Village Woman"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText8();
            myInventoryUIManager.ClosePanel8();
        } 
    }
    #endregion

    #region Set Character pos9
    public void ActivateGeisha09() 
    { 
        if (Inventory.instance.geisha == true) 
        {
            Inventory.instance.pos9 = "Geisha"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText9();
            myInventoryUIManager.ClosePanel9();
        }
    }
    public void ActivateNinja09() 
    { 
        if (Inventory.instance.ninja == true) 
        {
            Inventory.instance.pos9 = "Ninja"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText9();
            myInventoryUIManager.ClosePanel9();
        } 
    }
    public void ActivateSamuraiGrunt09() 
    { 
        if (Inventory.instance.samuraiGrunt == true) 
        {
            Inventory.instance.pos9 = "Samurai Grunt"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText9();
            myInventoryUIManager.ClosePanel9();
        }
    }
    public void ActivateSamuraiWarrior09() 
    { 
        if (Inventory.instance.samuraiWarrior == true) 
        {
            Inventory.instance.pos9 = "Samurai Warrior"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText9();
            myInventoryUIManager.ClosePanel9();
        } 
    }
    public void ActivateSensei09() 
    { 
        if (Inventory.instance.sensei == true)
        {
            Inventory.instance.pos9 = "Sensei"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText9();
            myInventoryUIManager.ClosePanel9();
        } 
    }
    public void ActivateVillageMan09() 
    {
        if (Inventory.instance.villageMan == true) 
        {
            Inventory.instance.pos9 = "Village Man"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText9();
            myInventoryUIManager.ClosePanel9();
        } 
    }
    public void ActivateVillageWoman09() 
    { 
        if (Inventory.instance.villageWoman == true) 
        {
            Inventory.instance.pos9 = "Village Woman"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText9();
            myInventoryUIManager.ClosePanel9();
        }
    }
    #endregion

    #region Set Character pos10
    public void ActivateGeisha10() 
    { 
        if (Inventory.instance.geisha == true) 
        {
            Inventory.instance.pos10 = "Geisha"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText10();
            myInventoryUIManager.ClosePanel10();
        } 
    }
    public void ActivateNinja10() 
    { 
        if (Inventory.instance.ninja == true) 
        {
            Inventory.instance.pos10 = "Ninja"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText10();
            myInventoryUIManager.ClosePanel10();
        } 
    }
    public void ActivateSamuraiGrunt10() 
    { 
        if (Inventory.instance.samuraiGrunt == true) 
        {
            Inventory.instance.pos10 = "Samurai Grunt"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText10();
            myInventoryUIManager.ClosePanel10();
        } 
    }
    public void ActivateSamuraiWarrior10() 
    { 
        if (Inventory.instance.samuraiWarrior == true) 
        {
            Inventory.instance.pos10 = "Samurai Warrior"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText10();
            myInventoryUIManager.ClosePanel10();
        } 
    }
    public void ActivateSensei10() 
    { 
        if (Inventory.instance.sensei == true) 
        {
            Inventory.instance.pos10 = "Sensei"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText10();
            myInventoryUIManager.ClosePanel10();
        } 
    }
    public void ActivateVillageMan10() 
    { 
        if (Inventory.instance.villageMan == true)
        {
            Inventory.instance.pos10 = "Village Man"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText10();
            myInventoryUIManager.ClosePanel10();
        } 
    }
    public void ActivateVillageWoman10() 
    { 
        if (Inventory.instance.villageWoman == true) 
        {
            Inventory.instance.pos10 = "Village Woman"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText10();
            myInventoryUIManager.ClosePanel10();
        } 
    }
    #endregion

    #region Set Character pos11
    public void ActivateGeisha11() 
    { 
        if (Inventory.instance.geisha == true) 
        {
            Inventory.instance.pos11 = "Geisha"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText11();
            myInventoryUIManager.ClosePanel11();
        } 
    }
    public void ActivateNinja11() 
    { 
        if (Inventory.instance.ninja == true) 
        {
            Inventory.instance.pos11 = "Ninja"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText11();
            myInventoryUIManager.ClosePanel11();
        } 
    }
    public void ActivateSamuraiGrunt11() 
    { 
        if (Inventory.instance.samuraiGrunt == true) 
        {
            Inventory.instance.pos11 = "Samurai Grunt"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText11();
            myInventoryUIManager.ClosePanel11();
        } 
    }
    public void ActivateSamuraiWarrior11() 
    { 
        if (Inventory.instance.samuraiWarrior == true) 
        {
            Inventory.instance.pos11 = "Samurai Warrior"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText11();
            myInventoryUIManager.ClosePanel11();
        } 
    }
    public void ActivateSensei11() 
    { 
        if (Inventory.instance.sensei == true) 
        {
            Inventory.instance.pos11 = "Sensei"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText11();
            myInventoryUIManager.ClosePanel11();
        } 
    }
    public void ActivateVillageMan11() 
    { 
        if (Inventory.instance.villageMan == true) 
        {
            Inventory.instance.pos11 = "Village Man"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText11();
            myInventoryUIManager.ClosePanel11();
        } 
    }
    public void ActivateVillageWoman11() 
    { 
        if (Inventory.instance.villageWoman == true) 
        {
            Inventory.instance.pos11 = "Village Woman"; Inventory.instance.SaveInventory();
            myInventoryUIManager.UpdateLineUpText11();
            myInventoryUIManager.ClosePanel11();
        }
    }
    #endregion
    #endregion

}
