using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ButtonPlayOnClickEvent()
    {
        AudioManager.Play(AudioNames.ButtonClick);
        SceneManager.LoadScene("DifficultyMenu");
    }

    public void ButtonQuitOnClickEvent()
    {
        AudioManager.Play(AudioNames.ButtonClick);
        Application.Quit();
    }

    public void ButtonHelpOnClickEvent()
    {
        AudioManager.Play(AudioNames.ButtonClick);
        MenuManager.GoToMenu(MenuEnum.HelpMenu);
    }
}
