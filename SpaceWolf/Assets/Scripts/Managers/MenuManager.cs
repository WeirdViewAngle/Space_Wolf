using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine;


public static class MenuManager
{
    public static void GoToMenu(MenuEnum menuName)
    {
        switch(menuName)
        {

            case MenuEnum.HelpMenu:
                SceneManager.LoadScene("HelpInfo");
                break;

            case MenuEnum.MainMenu:
                SceneManager.LoadScene("_Scenes/MainMenu");
                break;

            case MenuEnum.PauseMenu:
                GameObject.Instantiate(Resources.Load("PauseMenu"));
                break;

            case MenuEnum.GameOverMenu:
                GameObject.Instantiate(Resources.Load("GameOverMenu"));
                break;
        }

    }
}

