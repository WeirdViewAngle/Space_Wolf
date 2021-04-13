using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class Platform : UnitedFederationOfInvokers
{
    Timer timer;
    bool tagedForDelete;
    
    private void OnEnable()
    {
        timer = GetComponent<Timer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character") && !tagedForDelete)
        {
            timer.Duration = DifficultyActivator.PlatformLiveSpan;
            timer.Run();
            tagedForDelete = true;
        }
    }

    private void Update()
    {
        if (timer.Finished)
        {
            timer.Stop();
            PlatformPool.ReturnPlatform(gameObject, PlatformEnum.StandartPlatform);
        }

        if(gameObject.transform.position.y < (Camera.main.transform.position.y - 2.5f) && !tagedForDelete)
        {
            timer.Duration = DifficultyActivator.PlatformLiveSpan + 5;
            timer.Run();
            tagedForDelete = true; 
        }
    }
}
