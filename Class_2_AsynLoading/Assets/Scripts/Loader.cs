using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        GameScene,
        LoadingScene,
    }

    private static Action onLoaderCallback;
    public static void Load(Scene scene)
    {
        onLoaderCallback = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };

       SceneManager.LoadScene(Loader.Scene.LoadingScene.ToString());
    }

    //Load the target scene
    public static void LoaderCallBack()
    {
        if(onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}