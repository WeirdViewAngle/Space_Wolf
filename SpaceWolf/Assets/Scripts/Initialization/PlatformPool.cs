using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlatformPool
{
    static Dictionary<PlatformEnum, List<GameObject>> platformsDictionary;

    static GameObject prefabPlatform;
    static GameObject prefabPlatformBoost;
    static GameObject prefabPlatformDamage;

    public static void Initialize()
    {
        if (platformsDictionary == null)
        {
            platformsDictionary = new Dictionary<PlatformEnum, List<GameObject>>();

            //Load Prefabs
            prefabPlatform = Resources.Load<GameObject>("Platform");
            prefabPlatformBoost = Resources.Load<GameObject>("Platform Boost");
            prefabPlatformDamage = Resources.Load<GameObject>("Platform Damage");

            //Create Lists
            platformsDictionary.Add(PlatformEnum.StandartPlatform, new List<GameObject>());
            platformsDictionary.Add(PlatformEnum.DamagePlatform, new List<GameObject>());
            platformsDictionary.Add(PlatformEnum.BoostPlatform, new List<GameObject>());

            //Add First Objects
            for (int i = 0; i < 50; i++)
            {
                platformsDictionary[PlatformEnum.StandartPlatform].Add(AddNewPlatform(PlatformEnum.StandartPlatform));
                platformsDictionary[PlatformEnum.DamagePlatform].Add(AddNewPlatform(PlatformEnum.DamagePlatform));
                platformsDictionary[PlatformEnum.BoostPlatform].Add(AddNewPlatform(PlatformEnum.BoostPlatform));
            }
        }
    }

    #region PlatformSpawn
    public static GameObject AddNewPlatform(PlatformEnum platformName)
    {
        if (platformName == PlatformEnum.StandartPlatform)
        {
            GameObject platform = GameObject.Instantiate(prefabPlatform, Camera.main.transform.position, Quaternion.identity);
            platform.GetComponent<Platform>();
            platform.SetActive(false);
            GameObject.DontDestroyOnLoad(platform);
            return (platform);
        }
        else if(platformName == PlatformEnum.DamagePlatform)
        {
            GameObject damagePlatform = GameObject.Instantiate(prefabPlatformDamage, Camera.main.transform.position, Quaternion.identity);
            damagePlatform.SetActive(false);
            damagePlatform.GetComponent<DamagePlatform>();
            GameObject.DontDestroyOnLoad(damagePlatform);
            return damagePlatform;
        }
        else
        {
            GameObject platformBoost = GameObject.Instantiate(prefabPlatformBoost, Camera.main.transform.position, Quaternion.identity);
            platformBoost.SetActive(false);
            platformBoost.GetComponent<BoostPlatform>();
            GameObject.DontDestroyOnLoad(platformBoost);
            return platformBoost;
        }
        
    }

    public static GameObject GetPlatformForScene(PlatformEnum platformName)
    {
        if (platformsDictionary[platformName].Count == 0)
        {
            for (int i = 0; i < 10; i++)
            {
                platformsDictionary[PlatformEnum.StandartPlatform].Add(AddNewPlatform(PlatformEnum.StandartPlatform));
                platformsDictionary[PlatformEnum.DamagePlatform].Add(AddNewPlatform(PlatformEnum.DamagePlatform));
                platformsDictionary[PlatformEnum.BoostPlatform].Add(AddNewPlatform(PlatformEnum.BoostPlatform));
            }
        }
        if (platformsDictionary[platformName].Count > 0)
        {
            GameObject platform =
                platformsDictionary[platformName][platformsDictionary[platformName].Count - 1];

            platformsDictionary[platformName].
                RemoveAt(platformsDictionary[platformName].Count - 1);
            return platform;
        }
        
        return null;
    }

    public static void ReturnPlatform(GameObject platform, PlatformEnum platformName)
    {
        platform.SetActive(false);
        platformsDictionary[platformName].Add(platform);
    }
    #endregion

   
}
