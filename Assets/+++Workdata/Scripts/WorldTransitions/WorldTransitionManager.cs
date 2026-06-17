using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WorldTransitionManager : MonoBehaviour
{
    public static WorldTransitionManager worldTransitionManager;
    
    private bool gameStart;

    private void Awake()
    {
        if (!gameStart)
        {
            worldTransitionManager = this;
            
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            
            gameStart = true;
        }
    }

    public void UnloadScene(int sceneIndex)
    {
        StartCoroutine(Unload(sceneIndex));
    }

    IEnumerator Unload(int sceneIndex)
    {
        yield return null;
        
        SceneManager.UnloadSceneAsync(sceneIndex);
    }
    
    
    
}
