using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject Setting;
    public void NavigateToGameScene()
    {
        Debug.Log("Navigating to the game scene...");
        Loader.Load(Loader.Scene.GameScene);
        Time.timeScale = 1;
    }

    public void NavigateToMainMenu()
    {
        Debug.Log("Navigating to main menu");
        Loader.Load(Loader.Scene.MainMenu);
    }

    public void BackToGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Setting.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
