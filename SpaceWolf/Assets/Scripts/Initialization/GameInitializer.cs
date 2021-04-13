using UnityEngine;


public class GameInitializer : MonoBehaviour
{
    private void Start()
    {
        EventManager.Initialize();
        ScreenUtils.Initialize();
        DifficultyActivator.Initialize();
    }

}

