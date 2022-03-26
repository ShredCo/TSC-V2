using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShopManager : MonoBehaviour
{
    [Header("Characters")]
    public GameObject geishas;
    public GameObject ninjas;
    public GameObject samuraiGrunts;
    public GameObject samuraiWarriors;
    public GameObject senseis;
    public GameObject villageMans;
    public GameObject villageWomans;
    


    public void HideAllCharacters()
    {
        geishas.SetActive(false);
        ninjas.SetActive(false);
        samuraiGrunts.SetActive(false);
        samuraiWarriors.SetActive(false);
        senseis.SetActive(false);
        villageMans.SetActive(false);
        villageWomans.SetActive(false);
    }

    public void ShowGeishas()
    {
        HideAllCharacters();
        geishas.SetActive(true);
    }

    public void ShowNinjas()
    {
        HideAllCharacters();
        ninjas.SetActive(true);
    }

    public void ShowSamuraiGrunts()
    {
        HideAllCharacters();
        samuraiGrunts.SetActive(true);
    }

    public void ShowSamuraiWarriors()
    {
        HideAllCharacters();
        samuraiWarriors.SetActive(true);
    }
    public void ShowSenseis()
    {
        HideAllCharacters();
        senseis.SetActive(true);
    }
    public void ShowVillageMans()
    {
        HideAllCharacters();
        villageMans.SetActive(true);
    }
    public void ShowVillageWomans()
    {
        HideAllCharacters();
        villageWomans.SetActive(true);
    }
}
