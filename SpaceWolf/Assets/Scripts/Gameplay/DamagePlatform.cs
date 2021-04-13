using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DamagePlatform : Platform
{

    Timer timerForDelete;

    bool tagedForDel = false;

    private void Start()
    {
        dictOfInvokers.Add(EventName.DamageTakenEvent, new DamageTakenEvent());
        EventManager.AddInvoker(EventName.DamageTakenEvent, this);
        
        //Timer for obj delete
        timerForDelete = GetComponent<Timer>();
        timerForDelete.Duration = 20;

        //Add GameOver Event
        EventManager.AddListener(EventName.GameOverEvent,GameOverClear);
    }


    void GameOverClear(int unused)
    {
        PlatformPool.ReturnPlatform(gameObject, PlatformEnum.DamagePlatform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            //Return platform to the pool and play sound
            PlatformPool.ReturnPlatform(gameObject, PlatformEnum.DamagePlatform);
            AudioManager.Play(AudioNames.DamageTake);

            //Invoke damage set by difficulty
            dictOfInvokers[EventName.DamageTakenEvent].Invoke(DifficultyActivator.DamageByPlatformDmg);
        }
    }

    private void Update()
    {
        if (gameObject.transform.position.y < (Camera.main.transform.position.y - 2.5f) && !tagedForDel)
        {
            timerForDelete.Run();
            tagedForDel = true;
        }

        if (timerForDelete.Finished)
        {
            PlatformPool.ReturnPlatform(gameObject, PlatformEnum.DamagePlatform);
        }
    }


    
}

