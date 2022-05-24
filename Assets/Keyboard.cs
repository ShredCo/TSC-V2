using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
   public string PlayerNameInput;
   [SerializeField] private bool shiftButtonActive = false;
   
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
      
   }
   
   #region Alphabet
   // Alphabet
   public void ButtonA()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "a";
      else
      {
         PlayerNameInput += "A";
         shiftButtonActive = false;
      }
         
   }
   public void ButtonB()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "b";
      else
      {
         PlayerNameInput += "B";
         shiftButtonActive = false;
      }
   }
   public void ButtonC()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "c";
      else
      {
         PlayerNameInput += "C";
         shiftButtonActive = false;
      }
   }
   public void ButtonD()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "d";
      else
      {
         PlayerNameInput += "D";
         shiftButtonActive = false;
      }
   }
   public void ButtonE()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "e";
      else
      {
         PlayerNameInput += "E";
         shiftButtonActive = false;
      }
   }
   public void ButtonF()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "f";
      else
      {
         PlayerNameInput += "F";
         shiftButtonActive = false;
      }
   }
   public void ButtonG()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "g";
      else
      {
         PlayerNameInput += "G";
         shiftButtonActive = false;
      }
   }
   public void ButtonH()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "h";
      else
      {
         PlayerNameInput += "H";
         shiftButtonActive = false;
      }
   }
   public void ButtonI()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "i";
      else
      {
         PlayerNameInput += "I";
         shiftButtonActive = false;
      }
   }
   public void ButtonJ()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "j";
      else
      {
         PlayerNameInput += "J";
         shiftButtonActive = false;
      }
   }
   public void ButtonK()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "k";
      else
      {
         PlayerNameInput += "K";
         shiftButtonActive = false;
      }
   }
   public void ButtonL()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "l";
      else
      {
         PlayerNameInput += "L";
         shiftButtonActive = false;
      }
   }
   public void ButtonM()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "m";
      else
      {
         PlayerNameInput += "M";
         shiftButtonActive = false;
      }
   }
   public void ButtonN()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "n";
      else
      {
         PlayerNameInput += "N";
         shiftButtonActive = false;
      }
   }
   public void ButtonO()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "o";
      else
      {
         PlayerNameInput += "O";
         shiftButtonActive = false;
      }
   }
   public void ButtonP()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "p";
      else
      {
         PlayerNameInput += "P";
         shiftButtonActive = false;
      }
   }
   public void ButtonQ()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "q";
      else
      {
         PlayerNameInput += "Q";
         shiftButtonActive = false;
      }
   }
   public void ButtonR()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "r";
      else
      {
         PlayerNameInput += "R";
         shiftButtonActive = false;
      }
   }
   public void ButtonS()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "s";
      else
      {
         PlayerNameInput += "S";
         shiftButtonActive = false;
      }
   }
   public void ButtonT()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "t";
      else
      {
         PlayerNameInput += "T";
         shiftButtonActive = false;
      }
   }
   public void ButtonU()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "u";
      else
      {
         PlayerNameInput += "U";
         shiftButtonActive = false;
      }
   }
   public void ButtonV()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "v";
      else
      {
         PlayerNameInput += "V";
         shiftButtonActive = false;
      }
   }
   public void ButtonW()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "w";
      else
      {
         PlayerNameInput += "W";
         shiftButtonActive = false;
      }
   }
   public void ButtonX()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "x";
      else
      {
         PlayerNameInput += "X";
         shiftButtonActive = false;
      }
   }
   public void ButtonY()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "y";
      else
      {
         PlayerNameInput += "Y";
         shiftButtonActive = false;
      }
   }
   public void ButtonZ()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "z";
      else
      {
         PlayerNameInput += "Z";
         shiftButtonActive = false;
      }
   }
   // special letters
   public void ButtonUE()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "ü";
      else
      {
         PlayerNameInput += "Ü";
         shiftButtonActive = false;
      }
   }
   public void ButtonOE()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "ö";
      else
      {
         PlayerNameInput += "Ö";
         shiftButtonActive = false;
      }
   }
   public void ButtonAE()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "ä";
      else
      {
         PlayerNameInput += "Ä";
         shiftButtonActive = false;
      }
   }
   public void ButtonDollar()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "$";
      else
      {
         PlayerNameInput += "£";
         shiftButtonActive = false;
      }
   }
   #endregion
   
   #region Numbers and special buttons
   public void ButtonSpace()
   {
      PlayerNameInput += " ";
   }
   public void ButtonBindestrich()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "-";
      else
      {
         PlayerNameInput += "_";
         shiftButtonActive = false;
      }
   }
   public void Button1()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "1";
      else
      {
         PlayerNameInput += "+";
         shiftButtonActive = false;
      }
   }
   public void Button2()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "2";
      else
      {
         //PlayerNameInput += "";
         shiftButtonActive = false;
      }
   }
   public void Button3()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "3";
      else
      {
         PlayerNameInput += "*";
         shiftButtonActive = false;
      }
   }
   public void Button4()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "4";
      else
      {
         PlayerNameInput += "ç";
         shiftButtonActive = false;
      }
   }
   public void Button5()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "5";
      else
      {
         PlayerNameInput += "%";
         shiftButtonActive = false;
      }
   }
   public void Button6()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "6";
      else
      {
         PlayerNameInput += "&";
         shiftButtonActive = false;
      }
   }
   public void Button7()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "7";
      else
      {
         PlayerNameInput += "/";
         shiftButtonActive = false;
      }
   }
   public void Button8()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "8";
      else
      {
         PlayerNameInput += "(";
         shiftButtonActive = false;
      }
   }
   public void Button9()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "9";
      else
      {
         PlayerNameInput += ")";
         shiftButtonActive = false;
      }
   }
   public void Button0()
   {
      if (shiftButtonActive == false)
         PlayerNameInput += "0";
      else
      {
         PlayerNameInput += "=";
         shiftButtonActive = false;
      }
   }
   #endregion
}
