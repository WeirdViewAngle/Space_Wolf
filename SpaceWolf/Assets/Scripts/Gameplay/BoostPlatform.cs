using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BoostPlatform : Platform
{
    Timer lifeTimer;

    bool tagedDelete = false;
    private void Start()
    {
        lifeTimer = GetComponent<Timer>();

        EventManager.AddListener(EventName.GameOverEvent,GameOverClear);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            lifeTimer.Duration = DifficultyActivator.PlatformLiveSpan;
            lifeTimer.Run();
        }
    }

    void GameOverClear(int unused)
    {
        PlatformPool.ReturnPlatform(gameObject, PlatformEnum.BoostPlatform);
    }

    private void Update()
    {
        if (lifeTimer.Finished)
        {
            PlatformPool.ReturnPlatform(gameObject, PlatformEnum.BoostPlatform);
        }


        if (gameObject.transform.position.y < (Camera.main.transform.position.y - 2.5f) && !tagedDelete)
        {
            lifeTimer.Duration = 20;
            lifeTimer.Run();
            tagedDelete = true;
        }
        
    }
    

}

