using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu_UIManager : MonoBehaviour
{
    public GameObject pauseMenuContainer;
    public GameObject optionsContainer;
    public GameObject mapContainer;
    public GameObject quitConfirmContainer;
    
    private InputSystem_Actions _inputActions;
    private InputAction _pauseAction;

    public static bool isPaused;

    #region UniyEvents
     private void Awake()
        {
            pauseMenuContainer.SetActive(false);
            isPaused = false;
            
            _inputActions = new InputSystem_Actions();
        }
    
        private void OnEnable()
        {
            _pauseAction = _inputActions.UI.PauseGame;
            EnableInput();
    
            _pauseAction.performed += OpenPauseMenu;
        }
        private void OnDisable()
        {
            DisableInput();
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
            pauseMenuContainer.SetActive(true);
            //Time.timeScale = 0f;
    
            isPaused = true;
        }
        public void ResumeGame()
        {
            GameObject.Find("Player").GetComponent<PlayerInput>().enabled = true;
            pauseMenuContainer.SetActive(false);
            //Time.timeScale = 1f;

            CloseOptionsMenu();
            CloseMap();
            
            isPaused = false;
        }
    #endregion
    
    #region Options
    
    public void OpenOptionsMenu()
    {
        optionsContainer.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        optionsContainer.SetActive(false);
    }
    
    #endregion
    
    #region Map
    
    public void OpenMap()
    {
        mapContainer.SetActive(true);
    }

    public void CloseMap()
    {
        mapContainer.SetActive(false);
    }
    
    #endregion
    
    
    #region QuitConfirm
    
    public void OpenQuitConfirm()
    {
        quitConfirmContainer.SetActive(true);
    }

    public void CloseQuitConfirm()
    {
        quitConfirmContainer.SetActive(false);
    }
    
    #endregion
    
    
    
    
    public void EnableInput()
    {
        _inputActions.Enable();
    }

    public void DisableInput()
    {
        _inputActions.Disable();
    }
}