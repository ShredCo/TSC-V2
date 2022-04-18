using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class SpawnPowerfields : MonoBehaviour
{
   public static SpawnPowerfields instance;

   private void Awake()
   {
       if (instance == null)
           instance = this;
   }

   public GameObject powerfieldPrefabRed;
   public GameObject powerfieldPrefabBlue;

   private float xPos;
   private float zPos;

   public int powerfieldsCountRed;
   public int powerfieldsCountBlue;

   private void Start()
   {
       StartCoroutine(RandomSpawnPowerfieldsRed());
       StartCoroutine(RandomSpawnPowerfieldsBlue());

   }

   IEnumerator RandomSpawnPowerfieldsRed()
   {
       while (powerfieldsCountRed < 100)
       {
           yield return new WaitForSeconds(10f);
           if (powerfieldsCountRed < 3)
           {
               xPos = Random.Range(-0.7f, 0.7f);
               zPos = Random.Range(-0.35f, 0.35f);
               Instantiate(powerfieldPrefabRed, new Vector3(xPos, 0.01f, zPos), Quaternion.identity);
               powerfieldsCountRed += 1;
           }
           
       }
   }
   IEnumerator RandomSpawnPowerfieldsBlue()
   {
       while (powerfieldsCountBlue < 100)
       {
           yield return new WaitForSeconds(10f);
           if (powerfieldsCountBlue < 3)
           {
               xPos = Random.Range(-0.7f, 0.7f);
               zPos = Random.Range(-0.35f, 0.35f);
               Instantiate(powerfieldPrefabBlue, new Vector3(xPos, 0.01f, zPos), Quaternion.identity);
               powerfieldsCountBlue += 1;
           }
       }
   }
}
