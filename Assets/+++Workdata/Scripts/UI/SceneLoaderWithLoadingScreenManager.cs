using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderWithLoadingScreenManager : MonoBehaviour
{
    public static  SceneLoaderWithLoadingScreenManager Instance;
    
    [SerializeField] private GameObject loadingScreenCanvas;
    [SerializeField] private Image progressBar;
    private float _target;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public async void loadScene(string sceneName)
    {
        _target = 0;
        progressBar.fillAmount = 0;
        
        var scene = SceneManager.LoadSceneAsync(sceneName);
        //Time.timeScale = 1f;
        scene.allowSceneActivation = false;
        
        loadingScreenCanvas.SetActive(true);
        
        do {
            await Task.Delay(100);  //ZUM TESTEN ____________________________________________________________________________________________________________________
            _target = scene.progress;
        } while(scene.progress < 0.9f);
        
        await Task.Delay(1000);   //ZUM TESTEN ____________________________________________________________________________________________________________________
        
        scene.allowSceneActivation = true;
        loadingScreenCanvas.SetActive(false);
    }
    
    
    
    public async void StartNewGame_LoadScene(string sceneName)
    {
        File.Delete(Application.persistentDataPath + "/saveData.json");
        PlayerPrefs.DeleteAll();
        
        
        _target = 0;
        progressBar.fillAmount = 0;
        
        var scene = SceneManager.LoadSceneAsync(sceneName);
        //Time.timeScale = 1f;
        scene.allowSceneActivation = false;
        
        loadingScreenCanvas.SetActive(true);
        
        do {
            await Task.Delay(100);  //ZUM TESTEN ____________________________________________________________________________________________________________________
            _target = scene.progress;
        } while(scene.progress < 0.9f);
        
        await Task.Delay(1000);   //ZUM TESTEN ____________________________________________________________________________________________________________________
        
        scene.allowSceneActivation = true;
        loadingScreenCanvas.SetActive(false);
    }


    private void Update()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, _target, 3 * Time.deltaTime);
    }
}