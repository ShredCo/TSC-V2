using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnPowerpoints : MonoBehaviour
{
    public static SpawnPowerpoints instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public GameObject powerpointPrefab;

    private float xPos;

    private float zPos;

    public int powerpointCount;

    private void Start()
    {

        StartCoroutine(RandomSpawn());
     //if (powerpointCount < 3)
     //{
     //    xPos = Random.Range(-0.7f, 0.7f);
     //    zPos = Random.Range(-0.35f, 0.35f);
     //    Instantiate(powerpointPrefab, new Vector3(xPos, 0.01f, zPos), Quaternion.identity);
     //    powerpointCount += 1;
     //}
    }

    IEnumerator RandomSpawn()
    {
        while (powerpointCount < 100)
        {
            if (powerpointCount < 3)
            {
                xPos = Random.Range(-0.7f, 0.7f);
                zPos = Random.Range(-0.35f, 0.35f);
                Instantiate(powerpointPrefab, new Vector3(xPos, 0.01f, zPos), Quaternion.identity);
                powerpointCount += 1;
            }
            yield return new WaitForSeconds(10f);
        }
    }
}
