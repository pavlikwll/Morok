using UnityEngine;
using UnityEngine.InputSystem;

public class InGame_UIManager : MonoBehaviour
{
    public GameObject inventoryContainer;
    
    private InputSystem_Actions _inputActions;
    private InputAction _inventoryAction;

    private static bool inventoryOpen;
    
    private void Awake()
    {
        inventoryContainer.SetActive(false);
        
        _inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _inventoryAction = _inputActions.UI.Inventory;
        _inputActions.Enable();

        _inventoryAction.performed += Inventory;
    }
    private void OnDisable()
    {
        _inputActions.Disable();
    }

    public void Inventory(InputAction.CallbackContext ctx)
    {
        inventoryOpen = !inventoryOpen;

        if (inventoryOpen)
        {
            OpenInventory();
        }
        else
        {
            CloseInventory();
        }
    }

    private void OpenInventory()
    {
        //GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        inventoryContainer.SetActive(true);
        //Time.timeScale = 0f;
    }
    public void CloseInventory()
    {
        //GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        inventoryContainer.SetActive(false);
        //Time.timeScale = 1f;
        
        inventoryOpen = false;
    }
}