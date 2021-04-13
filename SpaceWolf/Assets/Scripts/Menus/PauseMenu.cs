using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu: UnitedFederationOfInvokers
{
    public static Text finalScore;

    public void Start()
    {
        Time.timeScale = 0;
        dictOfInvokers.Add(EventName.ReturnToMainMenuEvent, new ReturnToMainMenuEvent());
        EventManager.AddInvoker(EventName.ReturnToMainMenuEvent, this);
    }

    public void ClickOnResumeButton()
    {
        //Add sound
        Destroy(GameObject.FindWithTag("PauseMenu"));
        Time.timeScale = 1;
        AudioManager.Play(AudioNames.ButtonClick);
    }

    public void ClickOnQuitButton()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuEnum.MainMenu);
        AudioManager.Play(AudioNames.ButtonClick);
        dictOfInvokers[EventName.ReturnToMainMenuEvent].Invoke(0);
    }
}
