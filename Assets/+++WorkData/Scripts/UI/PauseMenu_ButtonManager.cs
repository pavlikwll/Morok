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
}