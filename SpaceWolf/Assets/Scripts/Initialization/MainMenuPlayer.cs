using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlayer : MonoBehaviour
{
    [SerializeField]
    AudioSource audioMainTheme;

    bool playing = false;
    public void Start()
    {
        //AudioManager.Play(AudioNames.MainMenuTheme);
        audioMainTheme.Play();
    }

    private void Update()
    {
        if(Time.time > 35 && !playing)
        {
            audioMainTheme.Play();
            playing = true;
        }
    }
}
