using UnityEngine;
using UnityEngine.InputSystem;

public class KeyBinder : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputActions;
    [SerializeField]
    private InputActionReference Move;
    [SerializeField]
    private InputActionReference Look;
    [SerializeField]
    private InputActionReference Jump;
    [SerializeField]
    private InputActionReference Crouch;
    [SerializeField]
    private InputActionReference Sprint;
    [SerializeField]
    private InputActionReference Shoot;
    [SerializeField]
    private InputActionReference LaunchButton;

    private bool isShooting;
    private bool sprintHeld;
    private bool isLaunched;

    private void Awake()
    {

    }

    private void OnEnable()
    {
        Shoot.action.Enable();
        Shoot.action.started += fireButtonPressed;
        Shoot.action.canceled += fireButtonReleased;
        LaunchButton.action.started += grenadeLauncherPressed;
        LaunchButton.action.canceled += grenadeLauncherReleased;
        Sprint.action.started += sprintPressed;
        Sprint.action.canceled += sprintReleased;
    }
    private void OnDisable()
    {
        Shoot.action.started -= fireButtonPressed;
        Shoot.action.canceled -= fireButtonReleased;
        LaunchButton.action.started -= grenadeLauncherPressed;
        LaunchButton.action.canceled -= grenadeLauncherReleased;
        Sprint.action.started -= sprintPressed;
        Sprint.action.canceled -= sprintReleased;
        Shoot.action.Disable();
    }

    private void fireButtonReleased(InputAction.CallbackContext context)
    {
        isShooting = false;
    }

    private void fireButtonPressed(InputAction.CallbackContext context)
    {
        isShooting = true;
    }


    private void grenadeLauncherPressed(InputAction.CallbackContext context)
    {
        isLaunched = true;
    }

    private void grenadeLauncherReleased(InputAction.CallbackContext context)
    {
        isLaunched = false;
    }



    private void sprintPressed(InputAction.CallbackContext context)
    {
        sprintHeld = false;
    }

    private void sprintReleased(InputAction.CallbackContext context)
    {
        sprintHeld = false;
    }


    public Vector2 GetMovement()
    {
        return Move.action.ReadValue<Vector2>();
    }
    public Vector2 GetLook()
    {
        return Look.action.ReadValue<Vector2>();
    }
    public bool IsJumping()
    {
        return Jump.action.triggered;
    }
    public bool IsCrouching()
    {
        return Crouch.action.triggered;
    }
    public bool IsSprinting()
    {
        return sprintHeld;
    }

    public bool IsShooting()
    {
        return isShooting;
    }

    public bool IsGrenadeLaunched()
    {
        return isLaunched;
    }


}
