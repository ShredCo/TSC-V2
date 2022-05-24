
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UsernameManager : MonoBehaviour
{
   public Text displayedText;
   public string KeyboardInput;

   [SerializeField] private MainCharacterManager mainCharacterManager;
   [SerializeField] private MainCharacterCreator mainCharacterCreator;

   [Header("Panels")]
   [SerializeField] private GameObject panelUsername;
   [SerializeField] private GameObject panelSkinSettings;
   [SerializeField] private GameObject panelConfirm;
   // Elements
   [SerializeField] private GameObject keyboard;
   
   [Header("Buttons")]
   [SerializeField] private GameObject buttonDecline;
   [SerializeField] private GameObject buttonFirstKeyboard;
   [SerializeField] private GameObject buttonFirstSkinSettings;
   
   [Header("Cameras")]
   [SerializeField] private GameObject cameraUsername;
   [SerializeField] private GameObject cameraSkinSettings;
   
   [Header("Alphabet Texts")]
   [SerializeField] private Text textButtonA;
   [SerializeField] private Text textButtonB;
   [SerializeField] private Text textButtonC;
   [SerializeField] private Text textButtonD;
   [SerializeField] private Text textButtonE;
   [SerializeField] private Text textButtonF;
   [SerializeField] private Text textButtonG;
   [SerializeField] private Text textButtonH;
   [SerializeField] private Text textButtonI;
   [SerializeField] private Text textButtonJ;
   [SerializeField] private Text textButtonK;
   [SerializeField] private Text textButtonL;
   [SerializeField] private Text textButtonM;
   [SerializeField] private Text textButtonN;
   [SerializeField] private Text textButtonO;
   [SerializeField] private Text textButtonP;
   [SerializeField] private Text textButtonQ;
   [SerializeField] private Text textButtonR;
   [SerializeField] private Text textButtonS;
   [SerializeField] private Text textButtonT;
   [SerializeField] private Text textButtonU;
   [SerializeField] private Text textButtonV;
   [SerializeField] private Text textButtonW;
   [SerializeField] private Text textButtonX;
   [SerializeField] private Text textButtonY;
   [SerializeField] private Text textButtonZ;
   [SerializeField] private Text textButtonAE;
   [SerializeField] private Text textButtonOE;
   [SerializeField] private Text textButtonUE;

   // Number and other Buttons
   [SerializeField] private Text textButton1;
   [SerializeField] private Text textButton2;
   [SerializeField] private Text textButton3;
   [SerializeField] private Text textButton4;
   [SerializeField] private Text textButton5;
   [SerializeField] private Text textButton6;
   [SerializeField] private Text textButton7;
   [SerializeField] private Text textButton8;
   [SerializeField] private Text textButton9;
   [SerializeField] private Text textButton0;
   
   [SerializeField] private Text textButtonBindestrich;
   [SerializeField] private Text textButtonDollar;
   
   [SerializeField] private bool shiftButtonActive = false;

   private void Update()
   {
      displayedText.text = KeyboardInput;

      if (shiftButtonActive == true)
      {
         textButtonA.text = "A";
         textButtonB.text = "B";
         textButtonC.text = "C";
         textButtonD.text = "D";
         textButtonE.text = "E";
         textButtonF.text = "F";
         textButtonG.text = "G";
         textButtonH.text = "H";
         textButtonI.text = "I";
         textButtonJ.text = "J";
         textButtonK.text = "K";
         textButtonL.text = "L";
         textButtonM.text = "M";
         textButtonN.text = "N";
         textButtonO.text = "O";
         textButtonP.text = "P";
         textButtonQ.text = "Q";
         textButtonR.text = "R";
         textButtonS.text = "S";
         textButtonT.text = "T";
         textButtonU.text = "U";
         textButtonV.text = "V";
         textButtonW.text = "W";
         textButtonX.text = "X";
         textButtonY.text = "Y";
         textButtonZ.text = "Z";
         textButtonAE.text = "Ä";
         textButtonOE.text = "Ö";
         textButtonUE.text = "Ü";
         
         textButton1.text = "+";
         textButton2.text = "@";
         textButton3.text = "*";
         textButton4.text = "ç";
         textButton5.text = "%";
         textButton6.text = "&";
         textButton7.text = "/";
         textButton8.text = "(";
         textButton9.text = ")";
         textButton0.text = "=";
         
         textButtonBindestrich.text = "_";
         textButtonDollar.text = "£";
      }
      else if (shiftButtonActive == false)
      {
         textButtonA.text = "a";
         textButtonB.text = "b";
         textButtonC.text = "c";
         textButtonD.text = "d";
         textButtonE.text = "e";
         textButtonF.text = "f";
         textButtonG.text = "g";
         textButtonH.text = "h";
         textButtonI.text = "i";
         textButtonJ.text = "j";
         textButtonK.text = "k";
         textButtonL.text = "l";
         textButtonM.text = "m";
         textButtonN.text = "n";
         textButtonO.text = "o";
         textButtonP.text = "p";
         textButtonQ.text = "q";
         textButtonR.text = "r";
         textButtonS.text = "s";
         textButtonT.text = "t";
         textButtonU.text = "u";
         textButtonV.text = "v";
         textButtonW.text = "w";
         textButtonX.text = "x";
         textButtonY.text = "y";
         textButtonZ.text = "z";
         textButtonAE.text = "ä";
         textButtonOE.text = "ö";
         textButtonUE.text = "ü";
         
         textButton1.text = "1";
         textButton2.text = "2";
         textButton3.text = "3";
         textButton4.text = "4";
         textButton5.text = "5";
         textButton6.text = "6";
         textButton7.text = "7";
         textButton8.text = "8";
         textButton9.text = "9";
         textButton0.text = "0";
         
         textButtonBindestrich.text = "-";
         textButtonDollar.text = "$";
      }
   }

   #region other Keys
   // Special Buttons
   public void ButtonShift()
   {
      if (shiftButtonActive)
      {
         shiftButtonActive = false;
      }
      else
      {
         shiftButtonActive = true;
      }
   }
   public void ButtonEnter()
   {
      // open confirm window first
      keyboard.SetActive(false);
      panelConfirm.SetActive(true);
      EventSystem.current.SetSelectedGameObject(buttonDecline);
   }
   
   public void ButtonDelete()
   {
      KeyboardInput = "";
   }
   public void ButtonSpace()
   {
      KeyboardInput += " ";
   }
   public void ButtonBindestrich()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "-";
      else
      {
         KeyboardInput += "_";
         shiftButtonActive = false;
      }
   }
   #endregion
   
   #region Alphabet
   // Alphabet
   public void ButtonA()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "a";
      else
      {
         KeyboardInput += "A";
         shiftButtonActive = false;
      }
         
   }
   public void ButtonB()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "b";
      else
      {
         KeyboardInput += "B";
         shiftButtonActive = false;
      }
   }
   public void ButtonC()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "c";
      else
      {
         KeyboardInput += "C";
         shiftButtonActive = false;
      }
   }
   public void ButtonD()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "d";
      else
      {
         KeyboardInput += "D";
         shiftButtonActive = false;
      }
   }
   public void ButtonE()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "e";
      else
      {
         KeyboardInput += "E";
         shiftButtonActive = false;
      }
   }
   public void ButtonF()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "f";
      else
      {
         KeyboardInput += "F";
         shiftButtonActive = false;
      }
   }
   public void ButtonG()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "g";
      else
      {
         KeyboardInput += "G";
         shiftButtonActive = false;
      }
   }
   public void ButtonH()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "h";
      else
      {
         KeyboardInput += "H";
         shiftButtonActive = false;
      }
   }
   public void ButtonI()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "i";
      else
      {
         KeyboardInput += "I";
         shiftButtonActive = false;
      }
   }
   public void ButtonJ()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "j";
      else
      {
         KeyboardInput += "J";
         shiftButtonActive = false;
      }
   }
   public void ButtonK()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "k";
      else
      {
         KeyboardInput += "K";
         shiftButtonActive = false;
      }
   }
   public void ButtonL()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "l";
      else
      {
         KeyboardInput += "L";
         shiftButtonActive = false;
      }
   }
   public void ButtonM()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "m";
      else
      {
         KeyboardInput += "M";
         shiftButtonActive = false;
      }
   }
   public void ButtonN()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "n";
      else
      {
         KeyboardInput += "N";
         shiftButtonActive = false;
      }
   }
   public void ButtonO()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "o";
      else
      {
         KeyboardInput += "O";
         shiftButtonActive = false;
      }
   }
   public void ButtonP()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "p";
      else
      {
         KeyboardInput += "P";
         shiftButtonActive = false;
      }
   }
   public void ButtonQ()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "q";
      else
      {
         KeyboardInput += "Q";
         shiftButtonActive = false;
      }
   }
   public void ButtonR()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "r";
      else
      {
         KeyboardInput += "R";
         shiftButtonActive = false;
      }
   }
   public void ButtonS()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "s";
      else
      {
         KeyboardInput += "S";
         shiftButtonActive = false;
      }
   }
   public void ButtonT()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "t";
      else
      {
         KeyboardInput += "T";
         shiftButtonActive = false;
      }
   }
   public void ButtonU()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "u";
      else
      {
         KeyboardInput += "U";
         shiftButtonActive = false;
      }
   }
   public void ButtonV()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "v";
      else
      {
         KeyboardInput += "V";
         shiftButtonActive = false;
      }
   }
   public void ButtonW()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "w";
      else
      {
         KeyboardInput += "W";
         shiftButtonActive = false;
      }
   }
   public void ButtonX()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "x";
      else
      {
         KeyboardInput += "X";
         shiftButtonActive = false;
      }
   }
   public void ButtonY()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "y";
      else
      {
         KeyboardInput += "Y";
         shiftButtonActive = false;
      }
   }
   public void ButtonZ()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "z";
      else
      {
         KeyboardInput += "Z";
         shiftButtonActive = false;
      }
   }
   // special letters
   public void ButtonUE()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "ü";
      else
      {
         KeyboardInput += "Ü";
         shiftButtonActive = false;
      }
   }
   public void ButtonOE()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "ö";
      else
      {
         KeyboardInput += "Ö";
         shiftButtonActive = false;
      }
   }
   public void ButtonAE()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "ä";
      else
      {
         KeyboardInput += "Ä";
         shiftButtonActive = false;
      }
   }
   public void ButtonDollar()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "$";
      else
      {
         KeyboardInput += "£";
         shiftButtonActive = false;
      }
   }
   #endregion
   
   #region Numbers
   
   // Numbers
   public void Button1()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "1";
      else
      {
         KeyboardInput += "+";
         shiftButtonActive = false;
      }
   }
   public void Button2()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "2";
      else
      {
         KeyboardInput += "@";
         shiftButtonActive = false;
      }
   }
   public void Button3()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "3";
      else
      {
         KeyboardInput += "*";
         shiftButtonActive = false;
      }
   }
   public void Button4()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "4";
      else
      {
         KeyboardInput += "ç";
         shiftButtonActive = false;
      }
   }
   public void Button5()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "5";
      else
      {
         KeyboardInput += "%";
         shiftButtonActive = false;
      }
   }
   public void Button6()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "6";
      else
      {
         KeyboardInput += "&";
         shiftButtonActive = false;
      }
   }
   public void Button7()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "7";
      else
      {
         KeyboardInput += "/";
         shiftButtonActive = false;
      }
   }
   public void Button8()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "8";
      else
      {
         KeyboardInput += "(";
         shiftButtonActive = false;
      }
   }
   public void Button9()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "9";
      else
      {
         KeyboardInput += ")";
         shiftButtonActive = false;
      }
   }
   public void Button0()
   {
      if (shiftButtonActive == false)
         KeyboardInput += "0";
      else
      {
         KeyboardInput += "=";
         shiftButtonActive = false;
      }
   }
   #endregion
   
   // Confirm Methods
   public void ConfirmName()
   {
      // gives the player the new name
      mainCharacterManager.PlayerName = KeyboardInput;
      mainCharacterCreator.ChoosedPlayerName.text = KeyboardInput;
      // switch panels
      panelUsername.SetActive(false);
      panelSkinSettings.SetActive(true);
      EventSystem.current.SetSelectedGameObject(buttonFirstSkinSettings);
      // change cameras
      cameraUsername.SetActive(false);
      cameraSkinSettings.SetActive(true);
   }
   public void DeclineName()
   {
      keyboard.SetActive(true);
      panelConfirm.SetActive(false);
      EventSystem.current.SetSelectedGameObject(buttonFirstKeyboard);
   }
}
