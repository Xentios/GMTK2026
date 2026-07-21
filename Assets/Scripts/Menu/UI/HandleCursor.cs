using UnityEngine;
using UnityEngine.InputSystem;


public class HandleCursor : MonoBehaviour
{
    //TODO add an actual check if game is running

    const string TabMap = "Tab";
    public InputActionAsset input;
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        //input.FindActionMap("Player").Disable();

        var map = input.FindActionMap("Player");

        foreach (var action in map)
        {
            Debug.Log(action.name);
            if (action.name == TabMap) continue;
            action.Disable();
        }
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        var map = input.FindActionMap("Player");
        foreach (var action in map.actions)
        {
            action.Enable();
        }
        AudioListener.pause = false;
    }
}
