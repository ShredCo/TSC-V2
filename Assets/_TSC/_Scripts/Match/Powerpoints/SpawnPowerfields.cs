using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPowerfields : MonoBehaviour
{
    
    #region Singleton
    public static SpawnPowerfields instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion
    
    // Powerfields
    [SerializeField] GameObject powerfieldPrefabRed;
    [SerializeField] GameObject powerfieldPrefabBlue;
    public int PowerfieldsCountRed;
    public int PowerfieldsCountBlue;

    private float xPos;
    private float zPos;
    private bool spawnPowerpointsEnable = true;
    
    private void Start()
    {
        StartCoroutine(RandomSpawnPowerfieldsRed());
        StartCoroutine(RandomSpawnPowerfieldsBlue());
    }

    #region Methods -> SpawnPowerfields
    IEnumerator RandomSpawnPowerfieldsRed()
    {
        
        while (spawnPowerpointsEnable)
        {
            if (PowerfieldsCountRed < 3)
            {
                yield return new WaitForSeconds(10f);
                xPos = Random.Range(-0.7f, 0.7f);
                zPos = Random.Range(-0.35f, 0.35f);
                Instantiate(powerfieldPrefabRed, new Vector3(xPos, 0.01f, zPos), Quaternion.identity);
                PowerfieldsCountRed += 1;
            }
            if (PowerfieldsCountRed == 3)
            {
                yield return new WaitForSeconds(5);
            }
        }
    }
    IEnumerator RandomSpawnPowerfieldsBlue()
    {
        while (spawnPowerpointsEnable)
        {
            if (PowerfieldsCountBlue < 3)
            {
                yield return new WaitForSeconds(10f);
                xPos = Random.Range(-0.7f, 0.7f);
                zPos = Random.Range(-0.35f, 0.35f);
                Instantiate(powerfieldPrefabBlue, new Vector3(xPos, 0.01f, zPos), Quaternion.identity);
                PowerfieldsCountBlue += 1;
            }
            if (PowerfieldsCountBlue == 3)
            {
                yield return new WaitForSeconds(5);
            }
        }
    }
    #endregion
}
