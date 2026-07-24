using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClickMouse : MonoBehaviour
{
    public InputActionReference mouseClick;
    public InputActionReference mousePosition;

    public Collider2D mouseCollider;
    public Collider2D keyboardCollider;

    public SpriteRenderer mouseSprite;

    public SwitchPanel SwitchPanel;

    void OnEnable()
    {
        mouseClick.action.performed += switchView;
        mousePosition.action.performed += checkMousePos;
    }

    void OnDisable()
    {
        mouseClick.action.performed -= switchView;
        mousePosition.action.performed -= checkMousePos;
    }


    private void switchView(InputAction.CallbackContext context)
    {


        var mousePos = Mouse.current.position.ReadValue();
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;
        if (mouseCollider.bounds.Contains(worldPos) == false && keyboardCollider.bounds.Contains(worldPos) == false) return;

        SwitchPanel.TogglePanels();
    }

    private void checkMousePos(InputAction.CallbackContext context)
    {
        var mousePos = context.ReadValue<Vector2>();
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;
        if (mouseCollider.bounds.Contains(worldPos) == true)
        {
            mouseSprite.color = Color.lightGreen;
        }
        else
        {
            mouseSprite.color = Color.white;
        }
    }


}
