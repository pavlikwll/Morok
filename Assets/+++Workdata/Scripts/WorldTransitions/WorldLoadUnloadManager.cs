using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldLoadUnloadManager : MonoBehaviour
{
    private bool loaded;
    
    public void Load(int sceneIndex)
    {
        if (!loaded)
        {
            SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
            
            loaded = true;
        }
    }
    
    public void Unload(int sceneIndex)
    {
        if (loaded)
        {
            loaded = false;
            
            WorldTransitionManager.worldTransitionManager.UnloadScene(sceneIndex);
        }
    }
}
