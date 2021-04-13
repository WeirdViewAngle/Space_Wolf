using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public static class DifficultyActivator
{

    static DifficultyEnum difficulty;
    public static void Initialize()
    {
        EventManager.AddListener(EventName.GameStartedEvent, GameStartedEvent);
    }

    public static void GameStartedEvent(int DifficultyType)
    {
        difficulty = (DifficultyEnum)DifficultyType;
        SceneManager.LoadScene("Gameplay");
    }

    public static float PlatformLiveSpan
    {
        get 
        {
            switch (difficulty)
            {
                case DifficultyEnum.Easy:
                    return GameConstants.PlatformLifeSpanEz;
                case DifficultyEnum.Mid:
                    return GameConstants.PlatformLifeSpanMed;
                case DifficultyEnum.Hard:
                    return GameConstants.PlatformLifeSpanHard;
                default:
                    return GameConstants.PlatformLifeSpanEz;
            }
                
                
        }

    }

    public static int HeroHp
    {
        get
        {
            switch (difficulty)
            {
                case DifficultyEnum.Easy:
                    return GameConstants.HeroHpEz;
                case DifficultyEnum.Mid:
                    return GameConstants.HeroHpMed;
                case DifficultyEnum.Hard:
                    return GameConstants.HeroHpHard;
                default:
                    return GameConstants.HeroHpEz;
            }


        }

    }


    public static float ChanceOfPlatform
    {
        get
        {
            switch (difficulty)
            {
                case DifficultyEnum.Easy:
                    return GameConstants.ezChanceOfStandartPlatform;
                case DifficultyEnum.Mid:
                    return GameConstants.medChanceOfStandartPlatform;
                case DifficultyEnum.Hard:
                    return GameConstants.hardChanceOfStandartPlatform;
                default:
                    return GameConstants.ezChanceOfStandartPlatform;
            }
        }
    }

    public static float ChanceOfBoostPlatform
    {
        get
        {
            switch (difficulty)
            {
                case DifficultyEnum.Easy:
                    return GameConstants.ezChanceOfBoostPlatform;
                case DifficultyEnum.Mid:
                    return GameConstants.medChanceOfBoostPlatform;
                case DifficultyEnum.Hard:
                    return GameConstants.hardChanceOfBoostPlatform;
                default:
                    return GameConstants.ezChanceOfBoostPlatform;
            }
        }
    }

    public static float ChanceOfDamagePlatform
    {
        get
        {
            switch (difficulty)
            {
                case DifficultyEnum.Easy:
                    return GameConstants.ezChanceOfDamagePlatform;
                case DifficultyEnum.Mid:
                    return GameConstants.medChanceOfDamagePlatform;
                case DifficultyEnum.Hard:
                    return GameConstants.hardChanceOfDamagePlatform;
                default:
                    return GameConstants.ezChanceOfDamagePlatform;
            }
        }
    }

    public static int DamageByPlatformDmg
    {
        get
        {
            switch (difficulty)
            {
                case DifficultyEnum.Easy:
                    return GameConstants.DamageByPlatformEz;
                case DifficultyEnum.Mid:
                    return GameConstants.DamageByPlatformMed;
                case DifficultyEnum.Hard:
                    return GameConstants.DamageByPlatformHard;
                default:
                    return GameConstants.DamageByPlatformEz;
            }


        }

    }
}
