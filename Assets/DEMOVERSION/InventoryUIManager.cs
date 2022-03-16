using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public static InventoryUIManager instance;

    [Header("Panels")]
    public GameObject panelLineup;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject panel7;
    public GameObject panel8;
    public GameObject panel9;
    public GameObject panel10;
    public GameObject panel11;

    public GameObject panel12;
    public GameObject panel13;
    public GameObject panel14;
    public GameObject panel15;
    public GameObject panel16;
    public GameObject panel17;
    public GameObject panel18;
    public GameObject panel19;
    public GameObject panel20;
    public GameObject panel21;
    public GameObject panel22;

    [Header("Team 1 Buttons")]
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;
    public GameObject button10;
    public GameObject button11;
    [Header("Team 2 Buttons")]
    public GameObject button12;
    public GameObject button13;
    public GameObject button14;
    public GameObject button15;
    public GameObject button16;
    public GameObject button17;
    public GameObject button18;
    public GameObject button19;
    public GameObject button20;
    public GameObject button21;
    public GameObject button22;

    [Header("Team 1 go back Buttons")]
    public GameObject goBack1;
    public GameObject goBack2;
    public GameObject goBack3;
    public GameObject goBack4;
    public GameObject goBack5;
    public GameObject goBack6;
    public GameObject goBack7;
    public GameObject goBack8;
    public GameObject goBack9;
    public GameObject goBack10;
    public GameObject goBack11;
    [Header("Team 2 go back Buttons")]
    public GameObject goBack12;
    public GameObject goBack13;
    public GameObject goBack14;
    public GameObject goBack15;
    public GameObject goBack16;
    public GameObject goBack17;
    public GameObject goBack18;
    public GameObject goBack19;
    public GameObject goBack20;
    public GameObject goBack21;
    public GameObject goBack22;

    [Header("Team 1 Line up texts")]
    [SerializeField] private Text positionText1;
    [SerializeField] private Text positionText2;
    [SerializeField] private Text positionText3;
    [SerializeField] private Text positionText4;
    [SerializeField] private Text positionText5;
    [SerializeField] private Text positionText6;
    [SerializeField] private Text positionText7;
    [SerializeField] private Text positionText8;
    [SerializeField] private Text positionText9;
    [SerializeField] private Text positionText10;
    [SerializeField] private Text positionText11;
    [Header("Team 2 Line up texts")]
    [SerializeField] private Text positionText12;
    [SerializeField] private Text positionText13;
    [SerializeField] private Text positionText14;
    [SerializeField] private Text positionText15;
    [SerializeField] private Text positionText16;
    [SerializeField] private Text positionText17;
    [SerializeField] private Text positionText18;
    [SerializeField] private Text positionText19;
    [SerializeField] private Text positionText20;
    [SerializeField] private Text positionText21;
    [SerializeField] private Text positionText22;


    private void Start()
    {
        if (instance == null)
            instance = this;

        UpdateLineUpTexts();
    }

    public void UpdateLineUpTexts()
    {
        UpdateLineUpText1();
        UpdateLineUpText2();
        UpdateLineUpText3();
        UpdateLineUpText4();
        UpdateLineUpText5();
        UpdateLineUpText6();
        UpdateLineUpText7();
        UpdateLineUpText8();
        UpdateLineUpText9();
        UpdateLineUpText10();
        UpdateLineUpText11();
        UpdateLineUpText12();
        UpdateLineUpText13();
        UpdateLineUpText14();
        UpdateLineUpText15();
        UpdateLineUpText16();
        UpdateLineUpText17();
        UpdateLineUpText18();
        UpdateLineUpText19();
        UpdateLineUpText20();
        UpdateLineUpText21();
        UpdateLineUpText22();
    }


    #region Open Panels Methods
    public void OpenPanel1()
    {
        panelLineup.SetActive(false);
        panel1.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack1);
    }
    public void OpenPanel2()
    {
        panelLineup.SetActive(false);
        panel2.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack2);
    }
    public void OpenPanel3()
    {
        panelLineup.SetActive(false);
        panel3.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack3);
    }
    public void OpenPanel4()
    {
        panelLineup.SetActive(false);
        panel4.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack4);
    }
    public void OpenPanel5()
    {
        panelLineup.SetActive(false);
        panel5.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack5);
    }
    public void OpenPanel6()
    {
        panelLineup.SetActive(false);
        panel6.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack6);
    }
    public void OpenPanel7()
    {
        panelLineup.SetActive(false);
        panel7.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack7);
    }
    public void OpenPanel8()
    {
        panelLineup.SetActive(false);
        panel8.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack8);
    }
    public void OpenPanel9()
    {
        panelLineup.SetActive(false);
        panel9.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack9);
    }
    public void OpenPanel10()
    {
        panelLineup.SetActive(false);
        panel10.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack10);
    }
    public void OpenPanel11()
    {
        panelLineup.SetActive(false);
        panel11.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack11);
    }

    // Team 2
    public void OpenPanel12()
    {
        panelLineup.SetActive(false);
        panel12.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack12);
    }
    public void OpenPanel13()
    {
        panelLineup.SetActive(false);
        panel13.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack13);
    }
    public void OpenPanel14()
    {
        panelLineup.SetActive(false);
        panel14.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack14);
    }
    public void OpenPanel15()
    {
        panelLineup.SetActive(false);
        panel15.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack15);
    }
    public void OpenPanel16()
    {
        panelLineup.SetActive(false);
        panel16.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack16);
    }
    public void OpenPanel17()
    {
        panelLineup.SetActive(false);
        panel17.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack17);
    }
    public void OpenPanel18()
    {
        panelLineup.SetActive(false);
        panel18.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack18);
    }
    public void OpenPanel19()
    {
        panelLineup.SetActive(false);
        panel19.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack19);
    }
    public void OpenPanel20()
    {
        panelLineup.SetActive(false);
        panel20.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack20);
    }
    public void OpenPanel21()
    {
        panelLineup.SetActive(false);
        panel21.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack21);
    }
    public void OpenPanel22()
    {
        panelLineup.SetActive(false);
        panel22.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goBack22);
    }
    #endregion

    #region Close Panels Methods
    public void ClosePanel1()
    {
        panelLineup.SetActive(true);
        panel1.SetActive(false);
        
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button1);
    }
    public void ClosePanel2()
    {
        panelLineup.SetActive(true);
        panel2.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button2);
    }
    public void ClosePanel3()
    {
        panelLineup.SetActive(true);
        panel3.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button3);
    }
    public void ClosePanel4()
    {
        panelLineup.SetActive(true);
        panel4.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button4);
    }
    public void ClosePanel5()
    {
        panelLineup.SetActive(true);
        panel5.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button5);
    }
    public void ClosePanel6()
    {
        panelLineup.SetActive(true);
        panel6.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button6);
    }
    public void ClosePanel7()
    {
        panelLineup.SetActive(true);
        panel7.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button7);
    }
    public void ClosePanel8()
    {
        panelLineup.SetActive(true);
        panel8.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button8);
    }
    public void ClosePanel9()
    {
        panelLineup.SetActive(true);
        panel9.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button9);
    }
    public void ClosePanel10()
    {
        panelLineup.SetActive(true);
        panel10.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button10);
    }
    public void ClosePanel11()
    {
        panelLineup.SetActive(true);
        panel11.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button11);
    }
    public void ClosePanel12()
    {
        panelLineup.SetActive(true);
        panel12.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button12);
    }
    public void ClosePanel13()
    {
        panelLineup.SetActive(true);
        panel13.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button13);
    }
    public void ClosePanel14()
    {
        panelLineup.SetActive(true);
        panel14.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button14);
    }
    public void ClosePanel15()
    {
        panelLineup.SetActive(true);
        panel15.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button15);
    }
    public void ClosePanel16()
    {
        panelLineup.SetActive(true);
        panel16.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button16);
    }
    public void ClosePanel17()
    {
        panelLineup.SetActive(true);
        panel17.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button17);
    }
    public void ClosePanel18()
    {
        panelLineup.SetActive(true);
        panel18.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button18);
    }
    public void ClosePanel19()
    {
        panelLineup.SetActive(true);
        panel19.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button19);
    }
    public void ClosePanel20()
    {
        panelLineup.SetActive(true);
        panel20.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button20);
    }
    public void ClosePanel21()
    {
        panelLineup.SetActive(true);
        panel21.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button21);
    }
    public void ClosePanel22()
    {
        panelLineup.SetActive(true);
        panel22.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button22);
    }
    #endregion


    #region Update lineup texts team 1

    public void UpdateLineUpText1()
    {
        if (Inventory.instance.pos1 == "standard") { positionText1.text = Inventory.instance.pos1; }
        if (Inventory.instance.pos1 == "Geisha") { positionText1.text = Inventory.instance.pos1; }
        if (Inventory.instance.pos1 == "Ninja") { positionText1.text = Inventory.instance.pos1; }
        if (Inventory.instance.pos1 == "Samurai Grunt") { positionText1.text = Inventory.instance.pos1; }
        if (Inventory.instance.pos1 == "Samurai Warrior") { positionText1.text = Inventory.instance.pos1; }
        if (Inventory.instance.pos1 == "Sensei") { positionText1.text = Inventory.instance.pos1; }
        if (Inventory.instance.pos1 == "Village Man") { positionText1.text = Inventory.instance.pos1; }
        if (Inventory.instance.pos1 == "Village Woman") { positionText1.text = Inventory.instance.pos1; } 
    }

    public void UpdateLineUpText2()
    {
        if (Inventory.instance.pos2 == "standard") { positionText2.text = Inventory.instance.pos2; }
        if (Inventory.instance.pos2 == "Geisha") { positionText2.text = Inventory.instance.pos2; }
        if (Inventory.instance.pos2 == "Ninja") { positionText2.text = Inventory.instance.pos2; }
        if (Inventory.instance.pos2 == "Samurai Grunt") { positionText2.text = Inventory.instance.pos2; }
        if (Inventory.instance.pos2 == "Samurai Warrior") { positionText2.text = Inventory.instance.pos2; }
        if (Inventory.instance.pos2 == "Sensei") { positionText2.text = Inventory.instance.pos2; }
        if (Inventory.instance.pos2 == "Village Man") { positionText2.text = Inventory.instance.pos2; }
        if (Inventory.instance.pos2 == "Village Woman") { positionText2.text = Inventory.instance.pos2; }      
    }

    public void UpdateLineUpText3()
    {
        if (Inventory.instance.pos3 == "standard") { positionText3.text = Inventory.instance.pos3; }
        if (Inventory.instance.pos3 == "Geisha") { positionText3.text = Inventory.instance.pos3; }
        if (Inventory.instance.pos3 == "Ninja") { positionText3.text = Inventory.instance.pos3; }
        if (Inventory.instance.pos3 == "Samurai Grunt") { positionText3.text = Inventory.instance.pos3; }
        if (Inventory.instance.pos3 == "Samurai Warrior") { positionText3.text = Inventory.instance.pos3; }
        if (Inventory.instance.pos3 == "Sensei") { positionText3.text = Inventory.instance.pos3; }
        if (Inventory.instance.pos3 == "Village Man") { positionText3.text = Inventory.instance.pos3; }
        if (Inventory.instance.pos3 == "Village Woman") { positionText3.text = Inventory.instance.pos3; }
    }

    public void UpdateLineUpText4()
    {
        if (Inventory.instance.pos4 == "standard") { positionText4.text = Inventory.instance.pos4; }
        if (Inventory.instance.pos4 == "Geisha") { positionText4.text = Inventory.instance.pos4; }
        if (Inventory.instance.pos4 == "Ninja") { positionText4.text = Inventory.instance.pos4; }
        if (Inventory.instance.pos4 == "Samurai Grunt") { positionText4.text = Inventory.instance.pos4; }
        if (Inventory.instance.pos4 == "Samurai Warrior") { positionText4.text = Inventory.instance.pos4; }
        if (Inventory.instance.pos4 == "Sensei") { positionText4.text = Inventory.instance.pos4; }
        if (Inventory.instance.pos4 == "Village Man") { positionText4.text = Inventory.instance.pos4; }
        if (Inventory.instance.pos4 == "Village Woman") { positionText4.text = Inventory.instance.pos4; }
    }
    public void UpdateLineUpText5()
    {
        if (Inventory.instance.pos5 == "standard") { positionText5.text = Inventory.instance.pos5; }
        if (Inventory.instance.pos5 == "Geisha") { positionText5.text = Inventory.instance.pos5; }
        if (Inventory.instance.pos5 == "Ninja") { positionText5.text = Inventory.instance.pos5; }
        if (Inventory.instance.pos5 == "Samurai Grunt") { positionText5.text = Inventory.instance.pos5; }
        if (Inventory.instance.pos5 == "Samurai Warrior") { positionText5.text = Inventory.instance.pos5; }
        if (Inventory.instance.pos5 == "Sensei") { positionText5.text = Inventory.instance.pos5; }
        if (Inventory.instance.pos5 == "Village Man") { positionText5.text = Inventory.instance.pos5; }
        if (Inventory.instance.pos5 == "Village Woman") { positionText5.text = Inventory.instance.pos5; }
    }
    public void UpdateLineUpText6()
    {
        if (Inventory.instance.pos6 == "standard") { positionText6.text = Inventory.instance.pos6; }
        if (Inventory.instance.pos6 == "Geisha") { positionText6.text = Inventory.instance.pos6; }
        if (Inventory.instance.pos6 == "Ninja") { positionText6.text = Inventory.instance.pos6; }
        if (Inventory.instance.pos6 == "Samurai Grunt") { positionText6.text = Inventory.instance.pos6; }
        if (Inventory.instance.pos6 == "Samurai Warrior") { positionText6.text = Inventory.instance.pos6; }
        if (Inventory.instance.pos6 == "Sensei") { positionText6.text = Inventory.instance.pos6; }
        if (Inventory.instance.pos6 == "Village Man") { positionText6.text = Inventory.instance.pos6; }
        if (Inventory.instance.pos6 == "Village Woman") { positionText6.text = Inventory.instance.pos6; }
    }
    public void UpdateLineUpText7()
    {
        if (Inventory.instance.pos7 == "standard") { positionText7.text = Inventory.instance.pos7; }
        if (Inventory.instance.pos7 == "Geisha") { positionText7.text = Inventory.instance.pos7; }
        if (Inventory.instance.pos7 == "Ninja") { positionText7.text = Inventory.instance.pos7; }
        if (Inventory.instance.pos7 == "Samurai Grunt") { positionText7.text = Inventory.instance.pos7; }
        if (Inventory.instance.pos7 == "Samurai Warrior") { positionText7.text = Inventory.instance.pos7; }
        if (Inventory.instance.pos7 == "Sensei") { positionText7.text = Inventory.instance.pos7; }
        if (Inventory.instance.pos7 == "Village Man") { positionText7.text = Inventory.instance.pos7; }
        if (Inventory.instance.pos7 == "Village Woman") { positionText7.text = Inventory.instance.pos7; }
    }
    public void UpdateLineUpText8()
    {
        if (Inventory.instance.pos8 == "standard") { positionText8.text = Inventory.instance.pos8; }
        if (Inventory.instance.pos8 == "Geisha") { positionText8.text = Inventory.instance.pos8; }
        if (Inventory.instance.pos8 == "Ninja") { positionText8.text = Inventory.instance.pos8; }
        if (Inventory.instance.pos8 == "Samurai Grunt") { positionText8.text = Inventory.instance.pos8; }
        if (Inventory.instance.pos8 == "Samurai Warrior") { positionText8.text = Inventory.instance.pos8; }
        if (Inventory.instance.pos8 == "Sensei") { positionText8.text = Inventory.instance.pos8; }
        if (Inventory.instance.pos8 == "Village Man") { positionText8.text = Inventory.instance.pos8; }
        if (Inventory.instance.pos8 == "Village Woman") { positionText8.text = Inventory.instance.pos8; }
    }
    public void UpdateLineUpText9()
    {
        if (Inventory.instance.pos9 == "standard") { positionText9.text = Inventory.instance.pos9; }
        if (Inventory.instance.pos9 == "Geisha") { positionText9.text = Inventory.instance.pos9; }
        if (Inventory.instance.pos9 == "Ninja") { positionText9.text = Inventory.instance.pos9; }
        if (Inventory.instance.pos9 == "Samurai Grunt") { positionText9.text = Inventory.instance.pos9; }
        if (Inventory.instance.pos9 == "Samurai Warrior") { positionText9.text = Inventory.instance.pos9; }
        if (Inventory.instance.pos9 == "Sensei") { positionText9.text = Inventory.instance.pos9; }
        if (Inventory.instance.pos9 == "Village Man") { positionText9.text = Inventory.instance.pos9; }
        if (Inventory.instance.pos9 == "Village Woman") { positionText9.text = Inventory.instance.pos9; }
    }
    public void UpdateLineUpText10()
    {
        if (Inventory.instance.pos10 == "standard") { positionText10.text = Inventory.instance.pos10; }
        if (Inventory.instance.pos10 == "Geisha") { positionText10.text = Inventory.instance.pos10; }
        if (Inventory.instance.pos10 == "Ninja") { positionText10.text = Inventory.instance.pos10; }
        if (Inventory.instance.pos10 == "Samurai Grunt") { positionText10.text = Inventory.instance.pos10; }
        if (Inventory.instance.pos10 == "Samurai Warrior") { positionText10.text = Inventory.instance.pos10; }
        if (Inventory.instance.pos10 == "Sensei") { positionText10.text = Inventory.instance.pos10; }
        if (Inventory.instance.pos10 == "Village Man") { positionText10.text = Inventory.instance.pos10; }
        if (Inventory.instance.pos10 == "Village Woman") { positionText10.text = Inventory.instance.pos10; }
    }
    public void UpdateLineUpText11()
    {
        if (Inventory.instance.pos11 == "standard") { positionText11.text = Inventory.instance.pos11; }
        if (Inventory.instance.pos11 == "Geisha") { positionText11.text = Inventory.instance.pos11; }
        if (Inventory.instance.pos11 == "Ninja") { positionText11.text = Inventory.instance.pos11; }
        if (Inventory.instance.pos11 == "Samurai Grunt") { positionText11.text = Inventory.instance.pos11; }
        if (Inventory.instance.pos11 == "Samurai Warrior") { positionText11.text = Inventory.instance.pos11; }
        if (Inventory.instance.pos11 == "Sensei") { positionText11.text = Inventory.instance.pos11; }
        if (Inventory.instance.pos11 == "Village Man") { positionText11.text = Inventory.instance.pos11; }
        if (Inventory.instance.pos11 == "Village Woman") { positionText11.text = Inventory.instance.pos11; }
    }
    #endregion

    #region Update lineup texts team 2

    public void UpdateLineUpText12()
    {
        if (Inventory.instance.pos12 == "standard") { positionText12.text = Inventory.instance.pos12; }
        if (Inventory.instance.pos12 == "Geisha") { positionText12.text = Inventory.instance.pos12; }
        if (Inventory.instance.pos12 == "Ninja") { positionText12.text = Inventory.instance.pos12; }
        if (Inventory.instance.pos12 == "Samurai Grunt") { positionText12.text = Inventory.instance.pos12; }
        if (Inventory.instance.pos12 == "Samurai Warrior") { positionText12.text = Inventory.instance.pos12; }
        if (Inventory.instance.pos12 == "Sensei") { positionText12.text = Inventory.instance.pos12; }
        if (Inventory.instance.pos12 == "Village Man") { positionText12.text = Inventory.instance.pos12; }
        if (Inventory.instance.pos12 == "Village Woman") { positionText12.text = Inventory.instance.pos12; }
    }

    public void UpdateLineUpText13()
    {
        if (Inventory.instance.pos13 == "standard") { positionText13.text = Inventory.instance.pos13; }
        if (Inventory.instance.pos13 == "Geisha") { positionText13.text = Inventory.instance.pos13; }
        if (Inventory.instance.pos13 == "Ninja") { positionText13.text = Inventory.instance.pos13; }
        if (Inventory.instance.pos13 == "Samurai Grunt") { positionText13.text = Inventory.instance.pos13; }
        if (Inventory.instance.pos13 == "Samurai Warrior") { positionText13.text = Inventory.instance.pos13; }
        if (Inventory.instance.pos13 == "Sensei") { positionText13.text = Inventory.instance.pos13; }
        if (Inventory.instance.pos13 == "Village Man") { positionText13.text = Inventory.instance.pos13; }
        if (Inventory.instance.pos13 == "Village Woman") { positionText13.text = Inventory.instance.pos13; }
    }

    public void UpdateLineUpText14()
    {
        if (Inventory.instance.pos14 == "standard") { positionText14.text = Inventory.instance.pos14; }
        if (Inventory.instance.pos14 == "Geisha") { positionText14.text = Inventory.instance.pos14; }
        if (Inventory.instance.pos14 == "Ninja") { positionText14.text = Inventory.instance.pos14; }
        if (Inventory.instance.pos14 == "Samurai Grunt") { positionText14.text = Inventory.instance.pos14; }
        if (Inventory.instance.pos14 == "Samurai Warrior") { positionText14.text = Inventory.instance.pos14; }
        if (Inventory.instance.pos14 == "Sensei") { positionText14.text = Inventory.instance.pos14; }
        if (Inventory.instance.pos14 == "Village Man") { positionText14.text = Inventory.instance.pos14; }
        if (Inventory.instance.pos14 == "Village Woman") { positionText14.text = Inventory.instance.pos14; }
    }

    public void UpdateLineUpText15()
    {
        if (Inventory.instance.pos15 == "standard") { positionText15.text = Inventory.instance.pos15; }
        if (Inventory.instance.pos15 == "Geisha") { positionText15.text = Inventory.instance.pos15; }
        if (Inventory.instance.pos15 == "Ninja") { positionText15.text = Inventory.instance.pos15; }
        if (Inventory.instance.pos15 == "Samurai Grunt") { positionText15.text = Inventory.instance.pos15; }
        if (Inventory.instance.pos15 == "Samurai Warrior") { positionText15.text = Inventory.instance.pos15; }
        if (Inventory.instance.pos15 == "Sensei") { positionText15.text = Inventory.instance.pos15; }
        if (Inventory.instance.pos15 == "Village Man") { positionText15.text = Inventory.instance.pos15; }
        if (Inventory.instance.pos15 == "Village Woman") { positionText15.text = Inventory.instance.pos15; }
    }
    public void UpdateLineUpText16()
    {
        if (Inventory.instance.pos16 == "standard") { positionText16.text = Inventory.instance.pos16; }
        if (Inventory.instance.pos16 == "Geisha") { positionText16.text = Inventory.instance.pos16; }
        if (Inventory.instance.pos16 == "Ninja") { positionText16.text = Inventory.instance.pos16; }
        if (Inventory.instance.pos16 == "Samurai Grunt") { positionText16.text = Inventory.instance.pos16; }
        if (Inventory.instance.pos16 == "Samurai Warrior") { positionText16.text = Inventory.instance.pos16; }
        if (Inventory.instance.pos16 == "Sensei") { positionText16.text = Inventory.instance.pos16; }
        if (Inventory.instance.pos16 == "Village Man") { positionText16.text = Inventory.instance.pos16; }
        if (Inventory.instance.pos16 == "Village Woman") { positionText16.text = Inventory.instance.pos16; }
    }
    public void UpdateLineUpText17()
    {
        if (Inventory.instance.pos17 == "standard") { positionText17.text = Inventory.instance.pos17; }
        if (Inventory.instance.pos17 == "Geisha") { positionText17.text = Inventory.instance.pos17; }
        if (Inventory.instance.pos17 == "Ninja") { positionText17.text = Inventory.instance.pos17; }
        if (Inventory.instance.pos17 == "Samurai Grunt") { positionText17.text = Inventory.instance.pos17; }
        if (Inventory.instance.pos17 == "Samurai Warrior") { positionText17.text = Inventory.instance.pos17; }
        if (Inventory.instance.pos17 == "Sensei") { positionText17.text = Inventory.instance.pos17; }
        if (Inventory.instance.pos17 == "Village Man") { positionText17.text = Inventory.instance.pos17; }
        if (Inventory.instance.pos17 == "Village Woman") { positionText17.text = Inventory.instance.pos17; }
    }
    public void UpdateLineUpText18()
    {
        if (Inventory.instance.pos18 == "standard") { positionText18.text = Inventory.instance.pos18; }
        if (Inventory.instance.pos18 == "Geisha") { positionText18.text = Inventory.instance.pos18; }
        if (Inventory.instance.pos18 == "Ninja") { positionText18.text = Inventory.instance.pos18; }
        if (Inventory.instance.pos18 == "Samurai Grunt") { positionText18.text = Inventory.instance.pos18; }
        if (Inventory.instance.pos18 == "Samurai Warrior") { positionText18.text = Inventory.instance.pos18; }
        if (Inventory.instance.pos18 == "Sensei") { positionText18.text = Inventory.instance.pos18; }
        if (Inventory.instance.pos18 == "Village Man") { positionText18.text = Inventory.instance.pos18; }
        if (Inventory.instance.pos18 == "Village Woman") { positionText18.text = Inventory.instance.pos18; }
    }
    public void UpdateLineUpText19()
    {
        if (Inventory.instance.pos19 == "standard") { positionText19.text = Inventory.instance.pos19; }
        if (Inventory.instance.pos19 == "Geisha") { positionText19.text = Inventory.instance.pos19; }
        if (Inventory.instance.pos19 == "Ninja") { positionText19.text = Inventory.instance.pos19; }
        if (Inventory.instance.pos19 == "Samurai Grunt") { positionText19.text = Inventory.instance.pos19; }
        if (Inventory.instance.pos19 == "Samurai Warrior") { positionText19.text = Inventory.instance.pos19; }
        if (Inventory.instance.pos19 == "Sensei") { positionText19.text = Inventory.instance.pos19; }
        if (Inventory.instance.pos19 == "Village Man") { positionText19.text = Inventory.instance.pos19; }
        if (Inventory.instance.pos19 == "Village Woman") { positionText19.text = Inventory.instance.pos19; }
    }
    public void UpdateLineUpText20()
    {
        if (Inventory.instance.pos20 == "standard") { positionText20.text = Inventory.instance.pos20; }
        if (Inventory.instance.pos20 == "Geisha") { positionText20.text = Inventory.instance.pos20; }
        if (Inventory.instance.pos20 == "Ninja") { positionText20.text = Inventory.instance.pos20; }
        if (Inventory.instance.pos20 == "Samurai Grunt") { positionText20.text = Inventory.instance.pos20; }
        if (Inventory.instance.pos20 == "Samurai Warrior") { positionText20.text = Inventory.instance.pos20; }
        if (Inventory.instance.pos20 == "Sensei") { positionText20.text = Inventory.instance.pos20; }
        if (Inventory.instance.pos20 == "Village Man") { positionText20.text = Inventory.instance.pos20; }
        if (Inventory.instance.pos20 == "Village Woman") { positionText20.text = Inventory.instance.pos20; }
    }
    public void UpdateLineUpText21()
    {
        if (Inventory.instance.pos21 == "standard") { positionText21.text = Inventory.instance.pos21; }
        if (Inventory.instance.pos21 == "Geisha") { positionText21.text = Inventory.instance.pos21; }
        if (Inventory.instance.pos21 == "Ninja") { positionText21.text = Inventory.instance.pos21; }
        if (Inventory.instance.pos21 == "Samurai Grunt") { positionText21.text = Inventory.instance.pos21; }
        if (Inventory.instance.pos21 == "Samurai Warrior") { positionText21.text = Inventory.instance.pos21; }
        if (Inventory.instance.pos21 == "Sensei") { positionText21.text = Inventory.instance.pos21; }
        if (Inventory.instance.pos21 == "Village Man") { positionText21.text = Inventory.instance.pos21; }
        if (Inventory.instance.pos21 == "Village Woman") { positionText21.text = Inventory.instance.pos21; }
    }
    public void UpdateLineUpText22()
    {
        if (Inventory.instance.pos22 == "standard") { positionText22.text = Inventory.instance.pos22; }
        if (Inventory.instance.pos22 == "Geisha") { positionText22.text = Inventory.instance.pos22; }
        if (Inventory.instance.pos22 == "Ninja") { positionText22.text = Inventory.instance.pos22; }
        if (Inventory.instance.pos22 == "Samurai Grunt") { positionText22.text = Inventory.instance.pos22; }
        if (Inventory.instance.pos22 == "Samurai Warrior") { positionText22.text = Inventory.instance.pos22; }
        if (Inventory.instance.pos22 == "Sensei") { positionText22.text = Inventory.instance.pos22; }
        if (Inventory.instance.pos22 == "Village Man") { positionText22.text = Inventory.instance.pos22; }
        if (Inventory.instance.pos22 == "Village Woman") { positionText22.text = Inventory.instance.pos22; }
    }
    #endregion

}
