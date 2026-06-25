using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu_UIManager : MonoBehaviour
{
    public GameObject pauseMenuContainer;
    
    private InputSystem_Actions _inputActions;
    private InputAction _pauseAction;

    private static bool isPaused;
    
    private void Awake()
    {
        pauseMenuContainer.SetActive(false);
        
        _inputActions = new InputSystem_Actions();
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

    public void OpenPauseMenu(InputAction.CallbackContext ctx)
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
        
        isPaused = false;
    }
}