using UnityEngine;

public class MainMenu_UIManager : MonoBehaviour
{
    public GameObject mainMenuContainer;
    public GameObject loadGameContainer;
    public GameObject optionsContainer;
    public GameObject creditsContainer;
    public GameObject quitConfirmContainer;

    private GameObject _currentMenu;
    
    private void Awake()
    {
        _currentMenu = mainMenuContainer;
    }

    
    public void OpenMainMenu()
    {  
        _currentMenu.SetActive(false);
        mainMenuContainer.SetActive(true);
        _currentMenu = mainMenuContainer;
    }

    public void OpenLoadGame()
    {
        _currentMenu.SetActive(false);
        loadGameContainer.SetActive(true);
        _currentMenu = loadGameContainer;
    }
    public void OpenOptions()
    {
        _currentMenu.SetActive(false);
        optionsContainer.SetActive(true);
        _currentMenu = optionsContainer;
    }
    public void OpenCredits()
    {
        _currentMenu.SetActive(false);
        creditsContainer.SetActive(true);
        _currentMenu = creditsContainer;
    }
    public void OpenQuitConfirm()
    {
        _currentMenu.SetActive(false);
        quitConfirmContainer.SetActive(true);
        _currentMenu = quitConfirmContainer;
    }
}