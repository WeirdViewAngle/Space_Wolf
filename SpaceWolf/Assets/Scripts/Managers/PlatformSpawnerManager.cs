using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerManager : MonoBehaviour
{
    #region  Init
    static PlatformSpawnerManager _instance;
    public static PlatformSpawnerManager instance
    {
        
        get
        {
            if(_instance == null)
            {
                Debug.LogError("PlatformSpawnManager is NULL");
            }

            return _instance;
        }
        
    }
    
    void Awake()
    {
         _instance = this;
    }

    public int maxPlatformRowCount = 60;
    public int maxPlatformsInRow = 4;
    public int minPlatformsInRow = 2;
    int PlatformsInRow;
    public float distanceBetweenPlatformsSides;
    public float distanceBetweenPlatformsUp;
    public float timeForSpawnTimer;


    //Spawn loc
    Vector3 positionForSpawn;
    Vector2 minSpawnSpace = new Vector2();
    Vector2 maxSpawnSpace = new Vector2();
    Vector3 posForSpawnSpace;

    // Coll free support
    const int maxSpawnTryes = 15;
    float platformCollHalfHeight;
    float platformCollHalfWidth;

    #endregion

    //Objects
    [SerializeField]
    GameObject platform;      
    Timer spawnTimer;
    
    #region  ListPlatforms

    static List<GameObject> platforms;
    

    public static List<GameObject> Platforms
    {
        get
        {
            return platforms;
        }
        set
        {
            platforms = value;
        }
    }

    #endregion

    private void Start()
    {
        //Clear event
        EventManager.AddListener(EventName.GameOverEvent, ClearAllPlatformsInScene);
        EventManager.AddListener(EventName.ReturnToMainMenuEvent, ClearAllPlatformsInScene);

        // LIST
        platforms = new List<GameObject>();
        platforms.Add(GameObject.FindWithTag("FirstPlatform"));
        platforms.Add(GameObject.FindWithTag("SecondPlatform"));
        platforms.Add(GameObject.FindWithTag("ThirdPlatform"));

        positionForSpawn = new Vector3(
                GameObject.FindWithTag("FirstPlatform").transform.position.x,
                GameObject.FindWithTag("FirstPlatform").transform.position.y + 2,
                GameObject.FindWithTag("FirstPlatform").transform.position.z);
            posForSpawnSpace = positionForSpawn;
        
        BoxCollider2D boxColl = GameObject.FindWithTag("FirstPlatform").GetComponent<BoxCollider2D>();
        platformCollHalfHeight = boxColl.size.y / 2;
        platformCollHalfWidth = boxColl.size.x / 2;

        SpawnPlatforms();
        spawnTimer = GetComponent<Timer>();
        spawnTimer.Duration = timeForSpawnTimer;
        spawnTimer.Run();         
    }

    private void Update()
    {
        if(spawnTimer.Finished)
        {
            SpawnPlatforms();
            spawnTimer.Duration = timeForSpawnTimer;
            spawnTimer.Run();
        }
    }


    public void ClearAllPlatformsInScene(int unused)
    {
        foreach(GameObject platform in platforms)
        {
            if(platform.tag == "Platforms")
                PlatformPool.ReturnPlatform(platform,PlatformEnum.StandartPlatform);
            else if(platform.tag == "BoostPlatform")
                PlatformPool.ReturnPlatform(platform,PlatformEnum.BoostPlatform);
            else if(platform.tag == "DamagePlatform")
                PlatformPool.ReturnPlatform(platform,PlatformEnum.DamagePlatform);
        }
        if(platforms.Count > 0)
        {
            platforms.Clear();
        }
    }
    
    public void SpawnPlatforms() 
    { 
        for(int i = 0; i < maxPlatformRowCount; i++)
        {
            positionForSpawn.y += Random.Range(1f, 1.4f);
            PlatformsInRow = Random.Range(maxPlatformsInRow,minPlatformsInRow);
            posForSpawnSpace = positionForSpawn;
            //SetSpawnSpaceMaxMin(positionForSpawn);
            int platformSpawned = 0;

            for (int j = 0; j < PlatformsInRow; j++)
            {
                positionForSpawn.x = Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
                SetSpawnSpaceMaxMin(positionForSpawn);

                int tryNum = 0;
                while (tryNum < maxSpawnTryes && Physics2D.OverlapArea(minSpawnSpace, maxSpawnSpace) != null)
                {
                    positionForSpawn.x = Random.Range(ScreenUtils.ScreenLeft,ScreenUtils.ScreenRight);
                    tryNum++;

                    
                }

                if (Physics2D.OverlapArea(minSpawnSpace, maxSpawnSpace) == null)
                {
                    float randomValue = Random.value;
                    platformSpawned++;
                    if(randomValue < DifficultyActivator.ChanceOfDamagePlatform)
                    {
                        PlatformPlacer(PlatformEnum.DamagePlatform);
                    }
                    else if(randomValue < (DifficultyActivator.ChanceOfDamagePlatform + DifficultyActivator.ChanceOfBoostPlatform) && 
                            randomValue > DifficultyActivator.ChanceOfDamagePlatform)
                    {
                        PlatformPlacer(PlatformEnum.BoostPlatform);
                    }
                    else
                    {
                        PlatformPlacer(PlatformEnum.StandartPlatform);
                    }
                    
                }
                if(platformSpawned == 1)
                {
                    SpawnSeparatePlatform();
                }
            }
        }

    }
    
    void SpawnSeparatePlatform()
    {
        GameObject separatePlatform = PlatformPool.GetPlatformForScene(PlatformEnum.StandartPlatform);
        platforms.Add(separatePlatform);
        separatePlatform.transform.position = new Vector3(Random.Range(ScreenUtils.ScreenLeft,ScreenUtils.ScreenRight),
                                                        platforms[platforms.Count - 1].gameObject.transform.position.y,
                                                        platforms[platforms.Count - 1].gameObject.transform.position.z);
    }


    public void PlatformPlacer(PlatformEnum platformName)
    {
        //positionForSpawn = platforms[platforms.Count - 1].gameObject.transform.position;
        //positionForSpawn.y += 2f;

        if (platforms[platforms.Count - 1].tag == ("DamagePlatform") ||
            platforms[platforms.Count - 2].tag == ("DamagePlatform") ||
            platforms[platforms.Count - 3].tag == ("DamagePlatform"))
        {
            if(platformName == PlatformEnum.DamagePlatform)
            {
                platformName = PlatformEnum.StandartPlatform;
            }
        }

        GameObject platformNow = PlatformPool.GetPlatformForScene(platformName);
        if (platformNow != null)
        {
            platformNow.SetActive(true);
            platformNow.transform.position = positionForSpawn;
            platforms.Add(platformNow);
        }
    }

    void SetSpawnSpaceMaxMin(Vector3 position)
    {
        minSpawnSpace.x = position.x - (platformCollHalfWidth + distanceBetweenPlatformsSides);
        minSpawnSpace.y = position.y - (platformCollHalfHeight + distanceBetweenPlatformsUp);
        maxSpawnSpace.x = position.x + (platformCollHalfWidth + distanceBetweenPlatformsSides);
        maxSpawnSpace.y = position.y + (platformCollHalfHeight + distanceBetweenPlatformsUp);
    }
}

