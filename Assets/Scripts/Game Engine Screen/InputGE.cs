using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputGE : MonoBehaviour
{
    public InputActionReference trackingAction;
    public InputActionReference clickingAction;

    public Camera cam;

    private Vector2 currentTouchPos;
    private Transform selectedObject;
    private Vector3 offset;
    private Plane dragPlane;

    private void OnEnable()
    {
        trackingAction.action.Enable();
        clickingAction.action.Enable();

        trackingAction.action.performed += OnTouchPosition;
        clickingAction.action.performed += OnTouchPress;
        clickingAction.action.canceled += OnTouchRelease;
    }

    private void OnDisable()
    {
        trackingAction.action.performed -= OnTouchPosition;
        clickingAction.action.performed -= OnTouchPress;
        clickingAction.action.canceled -= OnTouchRelease;
    }

    private void OnTouchPress(InputAction.CallbackContext context)
    {
        Ray ray = cam.ScreenPointToRay(currentTouchPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            selectedObject = hit.transform;
            dragPlane = new Plane(cam.transform.forward, hit.point);
            offset = selectedObject.position - hit.point;
        }
    }

    private void OnTouchPosition(InputAction.CallbackContext context)
    {
        currentTouchPos = context.ReadValue<Vector2>();

        if (selectedObject != null)
        {
            Ray ray = cam.ScreenPointToRay(currentTouchPos);
            if (dragPlane.Raycast(ray, out float distance))
            {
                selectedObject.position = ray.GetPoint(distance) + offset;
            }
        }
    }

    private void OnTouchRelease(InputAction.CallbackContext context)
    {
        selectedObject = null;
    }


}
