using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class GameConstants
{
    /// <summary>
    /// Hero Action Support
    /// </summary>
    static float jumpForce = 0.1f;
    static float moveForce = 3.8f;

    /// <summary>
    /// Diffculty Support
    /// </summary>
    static float platformLifeSpanEz = 7f;
    static float platformLifeSpanMed = 4f;
    static float platformLifeSpanHard = 2.5f;

    static int heroHpEz = 5;
    static int heroHpMed = 4;
    static int heroHpHard = 2;

    static int damageByPlatformEz = 1;
    static int damageByPlatformMed = 2;
    static int damageByPlatformHard = 2;


    /// <summary>
    /// Pool Spawn Support
    /// </summary>

    static float EzChanceOfStandartPlatform = 0.8f;
    static float EzChanceOfDamagePlatform = 0.05f;
    static float EzChanceOfBoostPlatform = 0.15f;

    static float MedChanceOfStandartPlatform = 0.65f;
    static float MedChanceOfDamagePlatform = 0.15f;    
    static float MedChanceOfBoostPlatform = 0.2f;

    static float HardChanceOfStandartPlatform = 0.60f;
    static float HardChanceOfDamagePlatform = 0.25f;
    static float HardChanceOfBoostPlatform = 0.15f;

    #region GameInfoReferenses
    /// <summary>
    /// Access to info
    /// </summary>
    public static float JumpForce
    {
        get { return jumpForce; }
    }

    public static float MoveForce
    {
        get { return moveForce; }
    }

    public static float PlatformLifeSpanEz
    {
        get { return platformLifeSpanEz; }
    }

    public static float PlatformLifeSpanMed
    {
        get { return platformLifeSpanMed; }
    }

    public static float PlatformLifeSpanHard
    {
        get { return platformLifeSpanHard; }
    }

    public static int HeroHpEz
    {
        get { return heroHpEz; }
    }

    public static int HeroHpMed
    {
        get { return heroHpMed; }
    }

    public static int HeroHpHard
    {
        get { return heroHpHard; }
    }

    public static int DamageByPlatformEz
    {
        get { return damageByPlatformEz; }
    }

    public static int DamageByPlatformMed
    {
        get { return damageByPlatformMed; }
    }

    public static int DamageByPlatformHard
    {
        get { return damageByPlatformHard; }
    }

    

    //Ez
    public static float ezChanceOfStandartPlatform
    {
        get { return EzChanceOfStandartPlatform; }
    }


    public static float ezChanceOfDamagePlatform
    {
        get { return EzChanceOfDamagePlatform; }
    }

    public static float ezChanceOfBoostPlatform
    {
        get { return EzChanceOfBoostPlatform; }
    }

    //Mid
    public static float medChanceOfStandartPlatform
    {
        get { return MedChanceOfStandartPlatform; }
    }

    public static float medChanceOfDamagePlatform
    {
        get { return MedChanceOfDamagePlatform; }
    }

    public static float medChanceOfBoostPlatform
    {
        get { return MedChanceOfBoostPlatform; }
    }


    //Hard
    public static float hardChanceOfStandartPlatform
    {
        get { return HardChanceOfStandartPlatform; }
    }

    public static float hardChanceOfDamagePlatform
    {
        get { return HardChanceOfDamagePlatform; }
    }

    public static float hardChanceOfBoostPlatform
    {
        get { return HardChanceOfBoostPlatform; }
    }
    #endregion
}


