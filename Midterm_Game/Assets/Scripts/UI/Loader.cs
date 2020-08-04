using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private class LoadingMonobehavior : MonoBehaviour { }

    public enum Scene
    {
        GameScene,
        LoadingScene,
        MainMenu,
    }

    private static Action onLoaderCallback;
    private static AsyncOperation loadingAsyncOperation;
    public static void Load(Scene scene)
    {
        onLoaderCallback = () =>
        {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonobehavior>().StartCoroutine(LoadSceneAsync(scene));
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

    private static IEnumerator LoadSceneAsync(Scene scene)
    {
        yield return null;//Waiting for a frame
        loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

        while(!loadingAsyncOperation.isDone)
        {
            yield return null;
        }
    }

    public static float GetLoadingProgess()
    {
        if (loadingAsyncOperation != null)
        {
            return loadingAsyncOperation.progress;
        }

        return 0.0f;
    }
}