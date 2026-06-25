using UnityEngine;

public class MainMenu_UIManager : MonoBehaviour
{
    public GameObject mainMenuContainer;
    public GameObject optionsContainer;
    public GameObject creditsContainer;

    private GameObject _currentMenu;
    
    private void Awake()
    {
        _currentMenu = mainMenuContainer;
    }

    public void OpenOptions()
    {
        _currentMenu.SetActive(false);
        optionsContainer.SetActive(true);
        _currentMenu = optionsContainer;
    }

    public void OpenMainMenu()
    {  
        _currentMenu.SetActive(false);
        mainMenuContainer.SetActive(true);
        _currentMenu = mainMenuContainer;
    }
    
    public void OpenCredits()
    {
        _currentMenu.SetActive(false);
        creditsContainer.SetActive(true);
        _currentMenu = creditsContainer;
    }
}