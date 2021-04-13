using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float totalSeconds = 0;
    float secondsElapsed = 0;

    bool started = false;
    bool running = false;


    

    public float Duration
    {
       set
        {
            if (!running)
            {
                totalSeconds = value;
            }
        }
    }
    
    public bool Finished
    {
        get { return started && !running; }
    }

    public bool Running
    {
        get { return running; }
    }
    public void Run()
    {
        if (totalSeconds > 0)
        {
            started = true;
            running = true;
            secondsElapsed = 0;
        }
       
    }

    private void Update()
    {
        if (running)
        {
            secondsElapsed += Time.deltaTime;
            if (secondsElapsed >= totalSeconds)
            {
                running = false;

            }
        }

    }

    public void Stop()
    {
            running = false;
            started = false;
    } 

    
}

