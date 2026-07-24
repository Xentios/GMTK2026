using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClickMouse : MonoBehaviour
{
    public InputActionReference mouseClick;

    public Collider2D mouseCollider;
    public Collider2D keyboardCollider;

    public SwitchPanel SwitchPanel;

    void OnEnable()
    {
        mouseClick.action.performed += switchView;
    }

    void OnDisable()
    {
        mouseClick.action.performed -= switchView;
    }


    private void switchView(InputAction.CallbackContext context)
    {


        var mousePos = Mouse.current.position.ReadValue();
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;
        if (mouseCollider.bounds.Contains(worldPos) == false && keyboardCollider.bounds.Contains(worldPos) == false) return;

        SwitchPanel.TogglePanels();
    }
}
