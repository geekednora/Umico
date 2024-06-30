using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// SceneLoader servers as a main core script for handling scene loading.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    private int currentSceneIndex = 0;
    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnEnable()
    {
        StartCoroutine(LoadSceneAsync(currentSceneIndex));
    }

    /// <summary>
    /// Loading next scene according to current scene index to the next one from BuildSettings.
    /// </summary>
    void LoadNextScene()
    {
        StartCoroutine(LoadSceneAsync(currentSceneIndex + 1));
    }
    
    /// <summary>
    /// Loads a scene by its name using asynchronous loading method.
    /// </summary>
    /// <param name="sceneName">Scene name how it's called in File Manager</param>
    /// <returns></returns>
    
    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            // Write additional logic here
            
            currentSceneIndex = SceneManager.GetSceneByName(sceneName).buildIndex;
            yield return null;
        }
    }
    
    /// <summary>
    /// Loads a scene by its index using asynchronous loading method.
    /// </summary>
    /// <param name="sceneIndex">Scene's build index according how it corresponds to BuildSettings.</param>
    /// <returns></returns>
    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        while (!asyncLoad.isDone)
        {
            // Write additional logic here
            
            currentSceneIndex = sceneIndex;
            yield return null;
        }
    }
}
