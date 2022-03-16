using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSoccerPlayers : MonoBehaviour
{

    [Header("Character")]
    public GameObject redGeisha;
    public GameObject ninja;
    public GameObject samuraiGrunt;
    public GameObject samuraiWarrior;
    public GameObject sensei;
    public GameObject villageMan;
    public GameObject villageWoman;

    public GameObject standardCharacterTeam1;
    public GameObject standardCharacterTeam2;

    [Header("Positions Team 1")]
    // Goalkeeper
    public GameObject position1;
    // Defensive
    public GameObject position2;
    public GameObject position3;
    // Middlefield
    public GameObject position4;
    public GameObject position5;
    public GameObject position6;
    public GameObject position7;
    public GameObject position8;
    // Offensive
    public GameObject position9;
    public GameObject position10;
    public GameObject position11;

    [Header("Positions Team 2")]
    // Goalkeeper
    public GameObject position12;
    // Defensive
    public GameObject position13;
    public GameObject position14;
    // Middlefield
    public GameObject position15;
    public GameObject position16;
    public GameObject position17;
    public GameObject position18;
    public GameObject position19;
    // Offensive
    public GameObject position20;
    public GameObject position21;
    public GameObject position22;

    [Header("Scripts")]
    public Inventory myInventory;


    void SetAllCharactersActive()
    {
        myInventory.geisha = true;
        myInventory.ninja = true;
        myInventory.samuraiGrunt = true;
        myInventory.samuraiWarrior = true;
        myInventory.sensei = true;
        myInventory.villageMan = true;
        myInventory.villageWoman = true;
    }

    private void Start()
    {
        //SetAllCharactersActive();
        myInventory = GameObject.FindObjectOfType<Inventory>();
        Inventory.instance.LoadInventory();
    
    }


    public void InstantiateAllPlayers()
    {
        InstantiateSoccerPlayer1();
        InstantiateSoccerPlayer2();
        InstantiateSoccerPlayer3();
        InstantiateSoccerPlayer4();
        InstantiateSoccerPlayer5();
        InstantiateSoccerPlayer6();
        InstantiateSoccerPlayer7();
        InstantiateSoccerPlayer8();
        InstantiateSoccerPlayer9();
        InstantiateSoccerPlayer10();
        InstantiateSoccerPlayer11();

        InstantiateSoccerPlayer12();
        InstantiateSoccerPlayer13();
        InstantiateSoccerPlayer14();
        InstantiateSoccerPlayer15();
        InstantiateSoccerPlayer16();
        InstantiateSoccerPlayer17();
        InstantiateSoccerPlayer18();
        InstantiateSoccerPlayer19();
        InstantiateSoccerPlayer20();
        InstantiateSoccerPlayer21();
        InstantiateSoccerPlayer22();
    }

    #region Team 1
    public void InstantiateSoccerPlayer1()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer1");

        if (Inventory.instance.pos1 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos1 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos1 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos1 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos1 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos1 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos1 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman); 
        // Set standard character
        if (Inventory.instance.pos1 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam1); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position1.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position1.transform);
    }

    public void InstantiateSoccerPlayer2()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer2");

        if (Inventory.instance.pos2 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos2 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos2 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos2 == "Samurai Warrior")soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos2 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos2 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos2 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos2 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam1); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position2.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position2.transform);
    }

    public void InstantiateSoccerPlayer3()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer3");

        if (Inventory.instance.pos3 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos3 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos3 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos3 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos3 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos3 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos3 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos3 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam1); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position3.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position3.transform);
    }

    public void InstantiateSoccerPlayer4()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer4");

        if (Inventory.instance.pos4 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos4 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos4 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos4 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos4 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos4 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos4 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos4 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam1); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position4.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position4.transform);
    }

    public void InstantiateSoccerPlayer5()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer5");

        if (Inventory.instance.pos5 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos5 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos5 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos5 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos5 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos5 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos5 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos5 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam1); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position5.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position5.transform);
    }

    public void InstantiateSoccerPlayer6()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer6");

        if (Inventory.instance.pos6 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos6 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos6 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos6 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos6 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos6 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos6 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos6 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam1); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position6.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position6.transform);
    }

    public void InstantiateSoccerPlayer7()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer7");

        if (Inventory.instance.pos7 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos7 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos7 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos7 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos7 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos7 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos7 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos7 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam1); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position7.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position7.transform);
    }

    public void InstantiateSoccerPlayer8()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer8");

        if (Inventory.instance.pos8 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos8 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos8 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos8 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos8 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos8 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos8 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos8 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam1); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position8.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position8.transform);
    }

    public void InstantiateSoccerPlayer9()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer9");

        if (Inventory.instance.pos9 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos9 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos9 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos9 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos9 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos9 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos9 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos9 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam1); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position9.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position9.transform);
    }

    public void InstantiateSoccerPlayer10()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer10");

        if (Inventory.instance.pos10 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos10 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos10 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos10 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos10 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos10 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos10 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos10 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam1); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position10.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position10.transform);
    }

    public void InstantiateSoccerPlayer11()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer11");

        if (Inventory.instance.pos11 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos11 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos11 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos11 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos11 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos11 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos11 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos11 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam1); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position11.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position11.transform);        
    }
    #endregion

    #region Team 2
    public void InstantiateSoccerPlayer12()
    {
            GameObject soccerPlayer = new GameObject("SoccerPlayer12");
            
            if (Inventory.instance.pos12 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
            if (Inventory.instance.pos12 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
            if (Inventory.instance.pos12 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
            if (Inventory.instance.pos12 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
            if (Inventory.instance.pos12 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
            if (Inventory.instance.pos12 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
            if (Inventory.instance.pos12 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
            // Set standard character
            if (Inventory.instance.pos12 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam2); }

            // Sets his position and right rotation
            soccerPlayer.transform.position = position12.transform.position;
            soccerPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
            // Sets his offsetPosition
            Vector3 offsetPosition = soccerPlayer.transform.position;
            offsetPosition.y = 0.0315f;
            soccerPlayer.transform.position = offsetPosition;
            // Binds the player to the pole
            soccerPlayer.transform.SetParent(position12.transform);
        
    }

    public void InstantiateSoccerPlayer13()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer13");

        if (Inventory.instance.pos13 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos13 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos13 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos13 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos13 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos13 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos13 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos13 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam2); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position13.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position13.transform);
    }

    public void InstantiateSoccerPlayer14()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer14");

        if (Inventory.instance.pos14 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos14 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos14 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos14 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos14 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos14 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos14 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos14 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam2); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position14.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position14.transform);
    }

    public void InstantiateSoccerPlayer15()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer15");

        if (Inventory.instance.pos15 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos15 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos15 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos15 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos15 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos15 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos15 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos15 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam2); }
        // Sets his position and right rotation
        soccerPlayer.transform.position = position15.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position15.transform);
    }

    public void InstantiateSoccerPlayer16()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer16");

        if (Inventory.instance.pos16 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos16 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos16 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos16 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos16 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos16 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos16 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos16 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam2); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position16.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position16.transform);
    }

    public void InstantiateSoccerPlayer17()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer17");

        if (Inventory.instance.pos17 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos17 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos17 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos17 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos17 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos17 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos17 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos17 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam2); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position17.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position17.transform);
    }

    public void InstantiateSoccerPlayer18()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer18");

        if (Inventory.instance.pos18 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos18 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos18 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos18 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos18 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos18 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos18 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos18 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam2); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position18.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position18.transform);
    }

    public void InstantiateSoccerPlayer19()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer19");

        if (Inventory.instance.pos19 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos19 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos19 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos19 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos19 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos19 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos19 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos19 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam2); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position19.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position19.transform);
    }

    public void InstantiateSoccerPlayer20()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer20");

        if (Inventory.instance.pos20 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos20 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos20 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos20 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos20 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos20 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos20 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos20 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam2); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position20.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position20.transform);
    }

    public void InstantiateSoccerPlayer21()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer21");

        if (Inventory.instance.pos21 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos21 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos21 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos21 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos21 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos21 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos21 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos21 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam2); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position21.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position21.transform);
    }

    public void InstantiateSoccerPlayer22()
    {
        GameObject soccerPlayer = new GameObject("SoccerPlayer22");

        if (Inventory.instance.pos22 == "Geisha") soccerPlayer = (GameObject)Instantiate(redGeisha);
        if (Inventory.instance.pos22 == "Ninja") soccerPlayer = (GameObject)Instantiate(ninja);
        if (Inventory.instance.pos22 == "Samurai Grunt") soccerPlayer = (GameObject)Instantiate(samuraiGrunt);
        if (Inventory.instance.pos22 == "Samurai Warrior") soccerPlayer = (GameObject)Instantiate(samuraiWarrior);
        if (Inventory.instance.pos22 == "Sensei") soccerPlayer = (GameObject)Instantiate(sensei);
        if (Inventory.instance.pos22 == "Village Man") soccerPlayer = (GameObject)Instantiate(villageMan);
        if (Inventory.instance.pos22 == "Village Woman") soccerPlayer = (GameObject)Instantiate(villageWoman);
        // Set standard character
        if (Inventory.instance.pos22 == "standard") { soccerPlayer = (GameObject)Instantiate(standardCharacterTeam2); }

        // Sets his position and right rotation
        soccerPlayer.transform.position = position22.transform.position;
        soccerPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        // Sets his offsetPosition
        Vector3 offsetPosition = soccerPlayer.transform.position;
        offsetPosition.y = 0.0315f;
        soccerPlayer.transform.position = offsetPosition;
        // Binds the player to the pole
        soccerPlayer.transform.SetParent(position22.transform);
    }
    #endregion


}
