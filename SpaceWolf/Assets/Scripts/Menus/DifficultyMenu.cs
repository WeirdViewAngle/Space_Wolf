using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine;

public class DifficultyMenu : UnitedFederationOfInvokers
{
    private void Start()
    {
        dictOfInvokers.Add(EventName.GameStartedEvent, new GameStartedEvent());
        EventManager.AddInvoker(EventName.GameStartedEvent, this);
    }
    

    public void EasyButtonClick()
    {
        dictOfInvokers[EventName.GameStartedEvent].Invoke((int)DifficultyEnum.Easy);
        AudioManager.Play(AudioNames.ButtonClick);
    }

    public void MidButtonClick()
    {
        dictOfInvokers[EventName.GameStartedEvent].Invoke((int)DifficultyEnum.Mid);
        AudioManager.Play(AudioNames.ButtonClick);
    }

    public void HardButtonClick()
    {
        dictOfInvokers[EventName.GameStartedEvent].Invoke((int)DifficultyEnum.Hard);
        AudioManager.Play(AudioNames.ButtonClick);
    }

    public void BackButtonClick()
    {
        MenuManager.GoToMenu(MenuEnum.MainMenu);
        AudioManager.Play(AudioNames.ButtonClick);
    }
}
