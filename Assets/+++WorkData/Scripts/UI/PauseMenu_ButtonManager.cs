using UnityEngine;

public class PauseMenu_ButtonManager : MonoBehaviour
{
    public PauseMenu_UIManager pauseMenuUIManager;
    public SceneLoaderManager sceneLoaderManager;

    public void Button_Resume()
    {
        pauseMenuUIManager.ResumeGame();
    }
    
    public void Button_LoadSceneByName(string sceneName)
    {
        sceneLoaderManager.loadScene(sceneName);
    }
    
    public void Button_Quit()
    {
        Application.Quit();
    }
    
    public void Button_OpenPauseMenu()
    {
        pauseMenuUIManager.OpenPauseMenu();
    }

    public void Button_OpenOptions()
    {
        pauseMenuUIManager.OpenOptionsMenu();
    }

    public void Button_OpenRadio()
    {
        pauseMenuUIManager.OpenRadio();
    }

    public void Button_OpenInventory()
    {
        pauseMenuUIManager.OpenInventory();
    }

    public void Button_OpenQuestlog()
    {
        pauseMenuUIManager.OpenQuestlog();
    }
}