using System;
using UnityEngine;

public class GameOver_UIManager : MonoBehaviour
{
    public GameObject gameOverScreenContainer;
    public SceneLoaderManager sceneLoaderManager;

    private void Awake()
    {
        gameOverScreenContainer.SetActive(false);
    }

    public void UIGameOver()
    {
        gameOverScreenContainer.SetActive(true);
    }
    
    public void Button_LoadSceneByName(string sceneName)
    {
        sceneLoaderManager.loadScene(sceneName);
    }
}