using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public void NavigateToGameScene()
    {
        Debug.Log("Navigating to the game scene...");
        Loader.Load(Loader.Scene.GameScene);
    }

    public void NavigateToMainMenu()
    {
        Debug.Log("Navigating to main menu");
        Loader.Load(Loader.Scene.MainMenu);
    }
}
