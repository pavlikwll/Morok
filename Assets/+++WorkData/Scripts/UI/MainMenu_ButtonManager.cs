using UnityEngine;

public class MainMenu_ButtonManager : MonoBehaviour
{
    public MainMenu_UIManager mainMenuUIManager;
    public SceneLoaderManager sceneLoaderManager;
     
    public void Button_OpenMainMenu()
    {
        mainMenuUIManager.OpenMainMenu();
    }

    public void Button_OpenLoadGame()
    {
        mainMenuUIManager.OpenLoadGame();
    }

    public void Button_OpenOptions()
    {
        mainMenuUIManager.OpenOptions();
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
        sceneLoaderManager.loadScene(sceneName);
    }

    public void Button_QuitGame()
    {
        Application.Quit();
    }
}