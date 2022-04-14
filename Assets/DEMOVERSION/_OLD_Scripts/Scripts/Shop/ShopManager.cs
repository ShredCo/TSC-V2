using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    [Header("MainShopUI CurrencyText")]
    public Text shopUI_moneyText;
    public Text shopUI_gemsText;
    [Header("CharacterShop CurrencyText")]
    public Text characterShop_moneyText;
    public Text characterShop_gemsText;
    [Header("BallsShop CurrencyText")]
    public Text ballsShop_moneyText;
    public Text ballsShop_gemsText;
    [Header("PoleShop CurrencyText")]
    public Text polesShop_moneyText;
    public Text polesShop_gemsText;
    [Header("MoneyShop CurrencyText")]
    public Text moneyShop_moneyText;
    public Text moneyShop_gemsText;
    [Header("GemsUI CurrencyText")]
    public Text gemsUI_moneyText;
    public Text gemsUI_gemsText;

    [Header("Panels")]
    public GameObject mainCanvas;
    public GameObject shopPanel;
    public GameObject characterShop3D;
    public GameObject ballShopPanel;
    public GameObject poleShopPanel;
    public GameObject moneyShopPanel;
    public GameObject notEnoughGemsPanel;

    [Header("Buttons")]
    public GameObject openCharacterShopButton;
    public GameObject openBallShopButton;
    public GameObject openPoleShopButton;
    public GameObject openMoneyShopButton;
    public GameObject goBackFromCharacterShopButton;
    public GameObject goBackFromBallShopButton;
    public GameObject goBackFromPoleShopButton;
    public GameObject goBackFromMoneyShopButton;
    public GameObject goBackFromNotEnoughGemsButton;

    [Header("Buyed Characters")]
    public Button unlockedGeisha;
    public Button unlockedNinja;
    public Button unlockedGrunt;
    public Button unlockedWarrior;
    public Button unlockedSensei;
    public Button unlockedVillageMan;
    public Button unlockedVillageWoman;

    [Header("Cameras")]
    public GameObject mainCamera;
    public GameObject characterShopCamera;


    // Start is called before the first frame update
    void Start()
    {
        //Inventory.instance.changeGems(0);
        UpdateBankBalanceTexts();

        if(Inventory.instance.geisha == true)
        {
            unlockedGeisha.enabled = false;
        }
        if (Inventory.instance.ninja == true)
        {
            unlockedNinja.enabled = false;
        }
        if (Inventory.instance.samuraiGrunt == true)
        {
            unlockedGrunt.enabled = false;
        }
        if (Inventory.instance.samuraiWarrior == true)
        {
            unlockedWarrior.enabled = false;
        }
        if (Inventory.instance.sensei == true)
        {
            unlockedSensei.enabled = false;
        }
        if (Inventory.instance.villageMan == true)
        {
            unlockedVillageMan.enabled = false;
        }
        if (Inventory.instance.villageWoman == true)
        {
            unlockedVillageWoman.enabled = false;
        }
    }

    #region Buy Gems Methods
    public void Buy100Gems(int price)
    {
        // checks the bank balance
        if(Inventory.instance.money >= price)
        {
            Debug.Log("Item was buyed");
            // stores the item in the inventory
            Inventory.instance.changeGems(100);
            // Saves the Inventory
            Inventory.instance.SaveInventory();
            // updates the bankbalance
            Inventory.instance.money = Inventory.instance.money - price;
            UpdateBankBalanceTexts();
        }
    }

    public void Buy550Gems(int price)
    {
        // checks the bank balance
        if (Inventory.instance.money >= price)
        {
            Debug.Log("Item was buyed");
            // stores the item in the inventory
            Inventory.instance.changeGems(550);
            // Saves the Inventory
            Inventory.instance.SaveInventory();
            // updates the bankbalance
            Inventory.instance.money = Inventory.instance.money - price;
            UpdateBankBalanceTexts();
        }
    }

    public void Buy1250Gems(int price)
    {
        // checks the bank balance
        if (Inventory.instance.money >= price)
        {
            Debug.Log("Item was buyed");
            // stores the item in the inventory
            Inventory.instance.changeGems(1250);
            // Saves the Inventory
            Inventory.instance.SaveInventory();
            // updates the bankbalance
            Inventory.instance.money = Inventory.instance.money - price;
            UpdateBankBalanceTexts();
        }
    }

    public void Buy2500Gems(int price)
    {
        // checks the bank balance
        if (Inventory.instance.money >= price)
        {
            Debug.Log("Item was buyed");
            // stores the item in the inventory
            Inventory.instance.changeGems(2500);
            // Saves the Inventory
            Inventory.instance.SaveInventory();
            // updates the bankbalance
            Inventory.instance.money = Inventory.instance.money - price;
            UpdateBankBalanceTexts();
        }
    }

    public void Buy6000Gems(int price)
    {
        // checks the bank balance
        if (Inventory.instance.money >= price)
        {
            Debug.Log("Item was buyed");
            // stores the item in the inventory
            Inventory.instance.changeGems(6000);
            // Saves the Inventory
            Inventory.instance.SaveInventory();
            // updates the bankbalance
            Inventory.instance.money = Inventory.instance.money - price;
            UpdateBankBalanceTexts();
        }
    }
    #endregion

    #region Buy Money Methods
    public void Buy1kMoney(int price)
    {
        // checks the bank balance
        if (Inventory.instance.gems >= price)
        {
            // stores the item in the inventory
            Inventory.instance.changeMoney(1000);
            // Saves the Inventory
            Inventory.instance.SaveInventory();
            // updates the bankbalance
            Inventory.instance.gems = Inventory.instance.gems - price;
            UpdateBankBalanceTexts();
        }
       
    }

    public void Buy5_5kMoney(int price)
    {
        // checks the bank balance
        if (Inventory.instance.gems >= price)
        {
            // stores the item in the inventory
            Inventory.instance.changeMoney(5500);
            // Saves the Inventory
            Inventory.instance.SaveInventory();
            // updates the bankbalance
            Inventory.instance.gems = Inventory.instance.gems - price;
            UpdateBankBalanceTexts();
        }
    }

    public void Buy12_5kMoney(int price)
    {
        // checks the bank balance
        if (Inventory.instance.gems >= price)
        {
            // stores the item in the inventory
            Inventory.instance.changeMoney(12500);
            // Saves the Inventory
            Inventory.instance.SaveInventory();
            // updates the bankbalance
            Inventory.instance.gems = Inventory.instance.gems - price;
            UpdateBankBalanceTexts();
        }
    }

    public void Buy30kMoney(int price)
    {
        // checks the bank balance
        if (Inventory.instance.gems >= price)
        {
            // stores the item in the inventory
            Inventory.instance.changeMoney(30000);
            // Saves the Inventory
            Inventory.instance.SaveInventory();
            // updates the bankbalance
            Inventory.instance.gems = Inventory.instance.gems - price;
            UpdateBankBalanceTexts();
        }
    }

    public void Buy80kMoney(int price)
    {
        // checks the bank balance
        if (Inventory.instance.gems >= price)
        {
            // stores the item in the inventory
            Inventory.instance.changeMoney(80000);
            // Saves the Inventory
            Inventory.instance.SaveInventory();
            // updates the bankbalance
            Inventory.instance.gems = Inventory.instance.gems - price;
            UpdateBankBalanceTexts();
        }
    }
    #endregion

    #region Buy Characters Methods
    public void BuyCharGeisha(int price)
    {
        // checks the bank balance
        if (Inventory.instance.gems >= price && Inventory.instance.geisha == false)
        {
            Debug.Log("Geisha was buyed");
            // stores the item in the inventory
            Inventory.instance.UnlockGeisha();
            // Saves the Inventory
            if (Inventory.instance.geisha == true) { PlayerPrefs.SetInt("geisha", 1); }
            PlayerPrefs.Save();
            // updates the bankbalance
            Inventory.instance.gems = Inventory.instance.gems - price;
            UpdateBankBalanceTexts();

            EventSystem.current.SetSelectedGameObject(goBackFromCharacterShopButton);
            unlockedGeisha.enabled = false;
        }
    }
    public void BuyCharNinja(int price)
    {
        // checks the bank balance
        if (Inventory.instance.gems >= price && Inventory.instance.ninja == false)
        {
            Debug.Log("Ninja was buyed");
            // stores the item in the inventory
            Inventory.instance.UnlockNinja();
            // Saves the Inventory
            if (Inventory.instance.ninja == true) { PlayerPrefs.SetInt("ninja", 2); }
            PlayerPrefs.Save();
            // updates the bankbalance
            Inventory.instance.gems = Inventory.instance.gems - price;
            UpdateBankBalanceTexts();

            EventSystem.current.SetSelectedGameObject(goBackFromCharacterShopButton);
            unlockedNinja.enabled = false;
        }
    }
    public void BuyCharSamuraiGrunt(int price)
    {
        // checks the bank balance
        if (Inventory.instance.gems >= price && Inventory.instance.samuraiGrunt == false)
        {
            Debug.Log("Samurai Grunt was buyed");
            // stores the item in the inventory
            Inventory.instance.UnlockSamuraiGrunt();
            // Saves the Inventory
            if (Inventory.instance.samuraiGrunt == true) { PlayerPrefs.SetInt("samuraiGrunt", 3); }
            PlayerPrefs.Save();
            // updates the bankbalance
            Inventory.instance.gems = Inventory.instance.gems - price;
            UpdateBankBalanceTexts();

            EventSystem.current.SetSelectedGameObject(goBackFromCharacterShopButton);
            unlockedGrunt.enabled = false;
        }
    }
    public void BuyCharSamurraiWarrior(int price)
    {
        // checks the bank balance
        if (Inventory.instance.gems >= price && Inventory.instance.samuraiWarrior == false)
        {
            Debug.Log("Samurai Warrior was buyed");
            // stores the item in the inventory
            Inventory.instance.UnlockSamuraiWarrior();
            // Saves the Inventory
            if (Inventory.instance.samuraiWarrior == true) { PlayerPrefs.SetInt("samuraiWarrior", 4); }
            PlayerPrefs.Save();
            // updates the bankbalance
            Inventory.instance.gems = Inventory.instance.gems - price;
            UpdateBankBalanceTexts();

            EventSystem.current.SetSelectedGameObject(goBackFromCharacterShopButton);
            unlockedWarrior.enabled = false;
        }
    }
    public void BuyCharSensei(int price)
    {
        // checks the bank balance
        if (Inventory.instance.gems >= price && Inventory.instance.sensei == false)
        {
            Debug.Log("Sensei was buyed");
            // stores the item in the inventory
            Inventory.instance.UnlockSensei();
            // Saves the Inventory
            if (Inventory.instance.sensei == true) { PlayerPrefs.SetInt("sensei", 5); }
            PlayerPrefs.Save();
            // updates the bankbalance
            Inventory.instance.gems = Inventory.instance.gems - price;
            UpdateBankBalanceTexts();

            EventSystem.current.SetSelectedGameObject(goBackFromCharacterShopButton);
            unlockedSensei.enabled = false;
        }
    }
    public void BuyCharVillageMan(int price)
    {
        // checks the bank balance
        if (Inventory.instance.gems >= price && Inventory.instance.villageMan == false)
        {
            Debug.Log("Village Man was buyed");
            // stores the item in the inventory
            Inventory.instance.UnlockVillageMan();
            // Saves the Inventory
            if (Inventory.instance.villageMan == true) { PlayerPrefs.SetInt("villageMan", 6); }
            PlayerPrefs.Save();
            // updates the bankbalance
            Inventory.instance.gems = Inventory.instance.gems - price;
            UpdateBankBalanceTexts();

            EventSystem.current.SetSelectedGameObject(goBackFromCharacterShopButton);
            unlockedVillageMan.enabled = false;
        }
    }
    public void BuyCharVillageWoman(int price)
    {
        // checks the bank balance
        if (Inventory.instance.gems >= price && Inventory.instance.villageWoman == false)
        {
            Debug.Log("Village Woman was buyed");
            // stores the item in the inventory
            Inventory.instance.UnlockVillageWoman();
            // Saves the Inventory
            if (Inventory.instance.villageWoman == true) { PlayerPrefs.SetInt("villageWoman", 7); }
            PlayerPrefs.Save();
            // updates the bankbalance
            Inventory.instance.gems = Inventory.instance.gems - price;
            UpdateBankBalanceTexts();

            EventSystem.current.SetSelectedGameObject(goBackFromCharacterShopButton);
            unlockedVillageWoman.enabled = false;
        }
    }
    #endregion
    

    public void UpdateBankBalanceTexts()
    {

        // Shop UI
        shopUI_moneyText.text = Inventory.instance.money.ToString();
        shopUI_gemsText.text = Inventory.instance.gems.ToString();
        // Gems UI
        gemsUI_moneyText.text = Inventory.instance.money.ToString();
        gemsUI_gemsText.text = Inventory.instance.gems.ToString();
        // Balls Shop
        ballsShop_moneyText.text = Inventory.instance.money.ToString();
        ballsShop_gemsText.text = Inventory.instance.gems.ToString();
        // Poles Shop
        polesShop_moneyText.text = Inventory.instance.money.ToString();
        polesShop_gemsText.text = Inventory.instance.gems.ToString();
        // Money Shop
        moneyShop_moneyText.text = Inventory.instance.money.ToString();
        moneyShop_gemsText.text = Inventory.instance.gems.ToString();
        // Character Shop
        characterShop_moneyText.text = Inventory.instance.money.ToString();
        characterShop_gemsText.text = Inventory.instance.gems.ToString();
    }
}
