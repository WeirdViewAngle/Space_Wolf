using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : UnitedFederationOfInvokers
{
    #region  Initialization
    static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("GameManager is NULL");
            }

            return _instance;
        }

    }
//Timers
    Timer musicTimer;
    private void Awake() 
    {
        musicTimer = GetComponent<Timer>();
        _instance = this;        
        PlatformPool.Initialize();
    }

    void OnEnable()         
    {
        EventManager.AddListener(EventName.GameOverEvent, GameOverEventHandler);

        musicTimer = GetComponent<Timer>();

        lastCameraPos = mainCamera.transform.position.y;

        playing = true;

    }
    #endregion
    
    [SerializeField]
    GameObject target, mainCamera, healthHeart;

    #region  Initvars
    public Text score;
    
    int posTrack, health, scoreInt;
    bool playing = false;
    float  lastCameraPos;
    
    static List<GameObject> healthHeartsList;
    Vector3 positonForHealth;
    #endregion

    private void Start()
    {      
        //health setUp
        healthHeartsList = new List<GameObject>();
        positonForHealth = new Vector3(Camera.main.transform.position.x - (ScreenUtils.ScreenRight - 0.5f),
                                       Camera.main.transform.position.y - (ScreenUtils.ScreenBottom + 0.5f),
                                       5);

        health = DifficultyActivator.HeroHp;
        for (int i = 0; i < health; i++)
        {
            GameObject Heart = Instantiate(healthHeart, positonForHealth, Quaternion.identity);
            healthHeartsList.Add(Heart);
            positonForHealth.x += 0.9f;
        }
        

        dictOfInvokers.Add(EventName.GameOverEvent, new GameOverEvent());
        EventManager.AddInvoker(EventName.GameOverEvent, this);
        //Events add
        EventManager.AddListener(EventName.DamageTakenEvent, TakeDamage);
        EventManager.AddListener(EventName.GameStartedEvent, PlaceHearts);

    }

    private void Update()
    {
        //Pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameObject.FindWithTag("PauseMenu") == null && GameObject.FindWithTag("GameOverMenu") == null)
            {
                MenuManager.GoToMenu(MenuEnum.PauseMenu);
                AudioManager.Play(AudioNames.ButtonClick);
                GameObject.Find("FinalScore").GetComponent<Text>().text = "Level: " + scoreInt;
            }
        }
        //music start
        if(Time.time > 4 && !playing)
        {
            AudioManager.Play(AudioNames.GameplayTheme);
            playing = true;
            musicTimer.Duration = 64;
            musicTimer.Run();
        }
        //Music Timer
        if  (musicTimer.Finished)
        {
            playing = false;
        }

        if(mainCamera.transform.position.y >= lastCameraPos)
        {
            lastCameraPos = mainCamera.transform.position.y;
        }
        
        //converting position to score
        if((int)target.transform.position.y > posTrack)
        {
            posTrack = (int)target.transform.position.y;
            score.text ="Level: " +  posTrack.ToString();
            scoreInt = posTrack;
        }    
       
       //Invoke GameOver
        if(target.transform.position.y < (Camera.main.transform.position.y - 5f) && GameObject.FindWithTag("GameOverMenu") == null)
        {
            dictOfInvokers[EventName.GameOverEvent].Invoke(scoreInt);
        }

        if(healthHeartsList.Count <= 0 && GameObject.FindWithTag("GameOverMenu") == null)
        {
            dictOfInvokers[EventName.GameOverEvent].Invoke(scoreInt);
            playing = false;
        }
    }


    void TakeDamage(int damage)
    {
        for(int i = 0; i < damage; i++)
        {
            Destroy(healthHeartsList[healthHeartsList.Count - 1]);
            healthHeartsList.RemoveAt(healthHeartsList.Count - 1);
        }
    }
    void LateUpdate()
    {   if((lastCameraPos -7) <= target.transform.position.y) 
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x,
                                                        target.transform.position.y + 2.5f,
                                                        mainCamera.transform.position.z);
        }
    }


    public void PlaceHearts(int unused)
    {
        if(healthHeartsList.Count == 0)
        {
            health = DifficultyActivator.HeroHp;
            for (int i = 0; i < health; i++)
            {
                GameObject Heart = Instantiate(healthHeart, positonForHealth, Quaternion.identity);
                healthHeartsList.Add(Heart);
                positonForHealth.x += 0.9f;
            }
        }
    }
    void GameOverEventHandler(int unused) 
    {
        PlatformSpawnerManager.instance.ClearAllPlatformsInScene(0);
        playing = false;
        MenuManager.GoToMenu(MenuEnum.GameOverMenu);
        AudioManager.Play(AudioNames.GameOverSound);
        GameObject.Find("FinalScore").GetComponent<Text>().text = score.text;
    }
}
