using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum SceneEnum
    {
        Loading,
        MainMenu,
        Level1,
    }

    private static Action onLoaderCallback;

    public static void Load(SceneEnum scene)
    {
        // Set the loader callback action to load the target scene.
        onLoaderCallback = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };

        // Load the loading scene.
        SceneManager.LoadScene(SceneEnum.Loading.ToString());
    }

    public static void OnLoaderCallback()
    {
        // Triggered after first update in LoaderCallback that refreshes the screen.
        // Execute the loader callback action which will load the target scene.
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
   
}
