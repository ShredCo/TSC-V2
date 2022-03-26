using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    // Warning: NO BUTTON METHODS INSIDE HERE. CAN CAUSE TROUBLE

    public static Inventory instance;

    // Currencys
    public int gems;
    public int money;

    // Checks if the character is in the inventory || All true for testing
    public bool geisha;
    public bool ninja;
    public bool samuraiGrunt;
    public bool samuraiWarrior;
    public bool sensei;
    public bool villageMan;
    public bool villageWoman;

    // positions Team 1
    public string pos1 = "standard";
    public string pos2 = "standard";
    public string pos3 = "standard";
    public string pos4 = "standard";
    public string pos5 = "standard";
    public string pos6 = "standard";
    public string pos7 = "standard";
    public string pos8 = "standard";
    public string pos9 = "standard";
    public string pos10 = "standard";
    public string pos11 = "standard";

    // positions Team 2
    public string pos12 = "standard";
    public string pos13 = "standard";
    public string pos14 = "standard";
    public string pos15 = "standard";
    public string pos16 = "standard";
    public string pos17 = "standard";
    public string pos18 = "standard";
    public string pos19 = "standard";
    public string pos20 = "standard";
    public string pos21 = "standard";
    public string pos22 = "standard";

    // Start is called before the first frame update
    void Start()
    {
      DontDestroyOnLoad(gameObject);
      // when gameobject exists already
      if(instance == null)
      {
          instance = this;
      }
      else
      {
          Destroy(gameObject);
      }

        // load saved data
        LoadInventory();

        Debug.Log("Geisha is active = " + geisha);
        Debug.Log("Ninja is active = " + ninja);
    }

    #region Add new characters to the inventory
    public void UnlockGeisha()
    {
        geisha = true;
        Debug.Log("Geisha was stored in the inventory" + geisha);
    }
    public void UnlockNinja()
    {
        ninja = true;
        Debug.Log("Ninja was stored in the inventory" + ninja);
    }
    public void UnlockSamuraiGrunt()
    {
        samuraiGrunt = true;
        Debug.Log("SamuraiGrunt was stored in the inventory" + samuraiGrunt);
    }

    public void UnlockSamuraiWarrior()
    {
        samuraiWarrior = true;
        Debug.Log("SamuraiWarrior was stored in the inventory" + samuraiWarrior);
    }
    public void UnlockSensei()
    {
        sensei = true;
        Debug.Log("Sensei was stored in the inventory" + sensei);
    }
    public void UnlockVillageMan()
    {
        villageMan = true;
        Debug.Log("VillageMan was stored in the inventory" + villageMan);
    }
    public void UnlockVillageWoman()
    {
        villageWoman = true;
        Debug.Log("VillageWoman was stored in the inventory" + ninja);
    }
    #endregion

    #region Currencys
    public void changeGems(int number)
    {
        gems = gems + number;
    }

    public void changeMoney(int number)
    {
        money = money + number;
    }
    #endregion

   

    void LoadStandardCharacters()
    {
        //Team1
       //ActivateSensei01();
       //ActivateSensei02();
       //ActivateSensei03();
       //ActivateSensei04();
       //ActivateSensei05();
       //ActivateSensei06();
       //ActivateSensei07();
       //ActivateSensei08();
       //ActivateSensei09();
       //ActivateSensei10();
       //ActivateSensei11();
       //
       ////Team2
       //ActivateSensei12();
       //ActivateSensei13();
       //ActivateSensei14();
       //ActivateSensei15();
       //ActivateSensei16();
       //ActivateSensei17();
       //ActivateSensei18();
       //ActivateSensei19();
       //ActivateSensei20();
       //ActivateSensei21();
       //ActivateSensei22();
    }

    // not used yet
    #region Get Value returns
    // Characters
    public bool GetGeisha()
    {
        return geisha;
    }
    public bool GetNinja()
    {
        return ninja;
    }
    public bool GetSamuraiGrunt()
    {
        return samuraiGrunt;
    }
    public bool GetSamuraiWarrior()
    {
        return samuraiWarrior;
    }
    public bool GetSensei()
    {
        return sensei;
    }
    public bool GetVillageMan()
    {
        return villageMan;
    }
    public bool GetVillageWoman()
    {
        return villageWoman;
    }

    // positions
    public string GetPos1()
    {
        return pos1;
    }
    #endregion

    public void SaveInventory()
    {
        // Saves currencys
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("gems", gems);

        // Save character positions
        PlayerPrefs.SetString("pos1", pos1);
        PlayerPrefs.SetString("pos2", pos2);
        PlayerPrefs.SetString("pos3", pos3);
        PlayerPrefs.SetString("pos4", pos4);
        PlayerPrefs.SetString("pos5", pos5);
        PlayerPrefs.SetString("pos6", pos6);
        PlayerPrefs.SetString("pos7", pos7);
        PlayerPrefs.SetString("pos8", pos8);
        PlayerPrefs.SetString("pos9", pos9);
        PlayerPrefs.SetString("pos10", pos10);
        PlayerPrefs.SetString("pos11", pos11);
        PlayerPrefs.SetString("pos12", pos12);
        PlayerPrefs.SetString("pos13", pos13);
        PlayerPrefs.SetString("pos14", pos14);
        PlayerPrefs.SetString("pos15", pos15);
        PlayerPrefs.SetString("pos16", pos16);
        PlayerPrefs.SetString("pos17", pos17);
        PlayerPrefs.SetString("pos18", pos18);
        PlayerPrefs.SetString("pos19", pos19);
        PlayerPrefs.SetString("pos20", pos20);
        PlayerPrefs.SetString("pos21", pos21);
        PlayerPrefs.SetString("pos22", pos22);


        // Saves skins
        if (geisha == true) { PlayerPrefs.SetInt("geisha", 1); }
        if (ninja == true) { PlayerPrefs.SetInt("ninja", 2); }
        if (samuraiGrunt == true) { PlayerPrefs.SetInt("samuraiGrunt", 3); }
        if (samuraiWarrior == true) { PlayerPrefs.SetInt("samuraiWarrior", 4); }
        if (sensei == true) { PlayerPrefs.SetInt("sensei", 5); }
        if (villageMan == true) { PlayerPrefs.SetInt("villageMan", 6); }
        if (villageWoman == true) { PlayerPrefs.SetInt("villageWoman", 7); }

        PlayerPrefs.Save();
        Debug.Log("Inventory saved");
    }

    public void LoadInventory()
    {
        // Load currencys
        money = PlayerPrefs.GetInt("money");
        gems = PlayerPrefs.GetInt("gems");

        // Load character positions
        pos1 = PlayerPrefs.GetString("pos1", pos1);  
        pos2 = PlayerPrefs.GetString("pos2", pos2);
        pos3 = PlayerPrefs.GetString("pos3", pos3);
        pos4 = PlayerPrefs.GetString("pos4", pos4);
        pos5 = PlayerPrefs.GetString("pos5", pos5);
        pos6 = PlayerPrefs.GetString("pos6", pos6);
        pos7 = PlayerPrefs.GetString("pos7", pos7);
        pos8 = PlayerPrefs.GetString("pos8", pos8);
        pos9 = PlayerPrefs.GetString("pos9", pos9);
        pos10 = PlayerPrefs.GetString("pos10", pos10);
        pos11 = PlayerPrefs.GetString("pos11", pos11);      
        pos12 = PlayerPrefs.GetString("pos12", pos12);     
        pos13 = PlayerPrefs.GetString("pos13", pos13);
        pos14 = PlayerPrefs.GetString("pos14", pos14);
        pos15 = PlayerPrefs.GetString("pos15", pos15);
        pos16 = PlayerPrefs.GetString("pos16", pos16);
        pos17 = PlayerPrefs.GetString("pos17", pos17);
        pos18 = PlayerPrefs.GetString("pos18", pos18);
        pos19 = PlayerPrefs.GetString("pos19", pos19);
        pos20 = PlayerPrefs.GetString("pos20", pos20);
        pos21 = PlayerPrefs.GetString("pos21", pos21);
        pos22 = PlayerPrefs.GetString("pos22", pos22);

        // Loads skins
        if (PlayerPrefs.HasKey("geisha"))
        {
            //int output = PlayerPrefs.GetInt("geisha");
            //if (output == 1) { geisha = true; }
            geisha = true;
        }
        else
{
            geisha = false;
        }

        if (PlayerPrefs.HasKey("ninja"))
        {
            ninja = true;
        }
        else
        {
            ninja = false;
        }

        if (PlayerPrefs.HasKey("samuraiGrunt"))
        {
            samuraiGrunt = true;
        }
        else
        {
            samuraiGrunt = false;
        }

        if (PlayerPrefs.HasKey("samuraiWarrior"))
        {
            samuraiWarrior = true;
        }
        else
        {
            samuraiWarrior = false;
        }

        if (PlayerPrefs.HasKey("sensei"))
        {
            sensei = true;
        }
        else
        {
            sensei = false;
        }

        if (PlayerPrefs.HasKey("villageMan"))
        {
            villageMan = true;
        }
        else
        {
            villageMan = false;
        }

        if (PlayerPrefs.HasKey("villageWoman"))
        {
            villageWoman = true;
        }
        else
        {
            villageWoman = false;
        }

        Debug.Log("Inventory loaded");
        PlayerPrefs.Save();
    }

    public void ResetGameData()
    {
        // resets data
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        // updates reseted data to all variables
        // Activate first scene
        SceneManager.LoadScene(0);
        LoadInventory();
        Application.Quit();
    }
}
