using System;
using UnityEngine;

public class MainMenu_ButtonManager : MonoBehaviour
{
    public MainMenu_UIManager mainMenuUIManager;
    public SceneLoaderManager sceneLoaderManager;
    public SceneLoaderWithLoadingScreenManager sceneLoaderWithLoadingScreenManager;

    private void Awake()
    {
        sceneLoaderWithLoadingScreenManager = GameObject.Find("LoadingScreenManager").GetComponent<SceneLoaderWithLoadingScreenManager>();
    }

    public void Button_OpenMainMenu()
    {
        mainMenuUIManager.OpenMainMenu();
    }

    public void Button_OpenCredits()
    {
        mainMenuUIManager.OpenCredits();
    }

    public void Button_QuitConfirm()
    {
        mainMenuUIManager.OpenQuitConfirm();
    }

    public void Button_LoadSceneByName(string sceneName)
    {
        sceneLoaderWithLoadingScreenManager.loadScene(sceneName);
    }

    public void Button_NewGame(string sceneName)
    {
        sceneLoaderWithLoadingScreenManager.StartNewGame_LoadScene(sceneName);
    }

    public void Button_QuitGame()
    {
        Application.Quit();
    }
}