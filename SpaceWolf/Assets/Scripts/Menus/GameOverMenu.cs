using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    // track score from hud

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void OnButtonQuitClick()
    {
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuEnum.MainMenu);
        Time.timeScale = 1;
    }
}
