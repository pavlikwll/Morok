using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu_UIManager : MonoBehaviour
{
    public GameObject pauseMenuContainer;
    
    private InputSystem_Actions _inputActions;
    private InputAction _pauseAction;

    public static bool isPaused;
    
    private GameObject _currentMenu;

    public GameObject optionsContainer;
    public GameObject radioContainer;
    public GameObject inventoryContainer;
    public GameObject questlogContainer;

    #region UniyEvents
     private void Awake()
        {
            pauseMenuContainer.SetActive(false);
            
            _inputActions = new InputSystem_Actions();

            _currentMenu = pauseMenuContainer;
        }
    
        private void OnEnable()
        {
            _pauseAction = _inputActions.UI.PauseGame;
            _inputActions.Enable();
    
            _pauseAction.performed += OpenPauseMenu;
        }
        private void OnDisable()
        {
            _inputActions.Disable();
        }
    #endregion
    
    #region OpenClosePauseMenu
     public void OpenPauseMenu(InputAction.CallbackContext ctx)
        {
            if (InventorySystem.inventoryOpen == false && QuestlogSystem.questlogOpen == false)
            {
                isPaused = !isPaused;
                
                if (isPaused)
                {
                    PauseGame();
                }
                else
                { 
                    ResumeGame();
                }
            }
        }
        private void PauseGame()
        {
            GameObject.Find("Player").GetComponent<PlayerInput>().enabled = false;
            //GameObject.Find("Manager").GetComponent<UIInput>().enabled = false;
            pauseMenuContainer.SetActive(true);
            Time.timeScale = 0f;
    
            isPaused = true;
        }
        public void ResumeGame()
        {
            GameObject.Find("Player").GetComponent<PlayerInput>().enabled = true;
            //GameObject.Find("Manager").GetComponent<UIInput>().enabled = true;
            pauseMenuContainer.SetActive(false);
            Time.timeScale = 1f;
            
            isPaused = false;
        }
    #endregion
    
    #region PauseMenuFunctions

    public void OpenPauseMenu()
    {
        _currentMenu.SetActive(false);
        pauseMenuContainer.SetActive(true);
        _currentMenu = pauseMenuContainer;
    }

    public void OpenOptionsMenu()
    {
        _currentMenu.SetActive(false);
        optionsContainer.SetActive(true);
        _currentMenu = optionsContainer;
    }

    public void OpenRadio()
    {
        _currentMenu.SetActive(false);
        radioContainer.SetActive(true);
        _currentMenu = radioContainer;
    }

    public void OpenInventory()
    {
        _currentMenu.SetActive(false);
        inventoryContainer.SetActive(true);
        _currentMenu = inventoryContainer;
    }

    public void OpenQuestlog()
    {
        _currentMenu.SetActive(false);
        questlogContainer.SetActive(true);
        _currentMenu = questlogContainer;
    }

    #endregion
}