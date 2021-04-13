using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuEnum.MainMenu);
            AudioManager.Play(AudioNames.ButtonClick);
        }
    }

    public void OnButtonClickBackEvent()
    {
        MenuManager.GoToMenu(MenuEnum.MainMenu);
        AudioManager.Play(AudioNames.ButtonClick);
    }
}
