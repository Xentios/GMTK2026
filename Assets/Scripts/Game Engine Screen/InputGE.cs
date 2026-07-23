using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputGE : MonoBehaviour
{
    [SerializeField]
    private InputAction mouseClick;
    [SerializeField]
    private float mouseDragPhysicsSpeed = 10;
    [SerializeField]
    private float mouseDragSpeed = .1f;


    private Camera mainCamera;
    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        mouseClick.Enable();
        mouseClick.performed += MousePressed;
    }

    private void OnDisable()
    {
        mouseClick.performed -= MousePressed;
        mouseClick.Disable();
    }

    private void MousePressed(InputAction.CallbackContext context)
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && (hit.collider.gameObject.CompareTag("Items"))
                || hit.collider.gameObject.layer == LayerMask.NameToLayer("Draggable")
                || hit.collider.gameObject.GetComponent<IDrag>() != null
                )
            {
                StartCoroutine(DragUpdate(hit.collider.gameObject));
            }
        }

        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        if (hit2D.collider != null && (hit2D.collider.gameObject.CompareTag("Items"))
                || hit2D.collider.gameObject.layer == LayerMask.NameToLayer("Draggable")
                || hit2D.collider.gameObject.GetComponent<IDrag>() != null
                )
        {
            StartCoroutine(DragUpdate(hit2D.collider.gameObject));
        }
    }

    private IEnumerator DragUpdate(GameObject clickedObject)
    {
        clickedObject.TryGetComponent<Rigidbody2D>(out var rb);
        clickedObject.TryGetComponent<IDrag>(out var IDragComponent);
        IDragComponent.onStartDrag();
        var liste = clickedObject.GetComponents<IDrag>();

        float initialDistance = Vector3.Distance(clickedObject.transform.position, mainCamera.transform.position);
        while (mouseClick.ReadValue<float>() != 0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (rb != null)
            {
                Vector3 direction = ray.GetPoint(initialDistance) - clickedObject.transform.position;
                rb.linearVelocity = direction * mouseDragPhysicsSpeed;
                yield return waitForFixedUpdate;
            }
            else //Rigidbody olmayan bir objeye dokunmak için
            {
                clickedObject.transform.position = Vector3.SmoothDamp(clickedObject.transform.position, ray.GetPoint(initialDistance),
                    ref velocity, mouseDragSpeed);
                yield return null;
            }
        }
        IDragComponent.onEndDrag();
    }


}










































//public class InputGE : MonoBehaviour
//{
//    public InputActionReference trackingAction;
//    public InputActionReference clickingAction;

//    public Camera cam;

//    private Vector2 currentTouchPos;
//    private Transform selectedObject;
//    private Vector3 offset;
//    private Plane dragPlane;

//    private void OnEnable()
//    {
//        trackingAction.action.Enable();
//        clickingAction.action.Enable();

//        trackingAction.action.performed += OnTouchPosition;
//        clickingAction.action.performed += OnTouchPress;
//        clickingAction.action.canceled += OnTouchRelease;
//    }

//    private void OnDisable()
//    {
//        trackingAction.action.performed -= OnTouchPosition;
//        clickingAction.action.performed -= OnTouchPress;
//        clickingAction.action.canceled -= OnTouchRelease;
//    }

//    private void OnTouchPress(InputAction.CallbackContext context)
//    {
//        Ray ray = cam.ScreenPointToRay(currentTouchPos);
//        if (Physics.Raycast(ray, out RaycastHit hit))
//        {
//            selectedObject = hit.transform;
//            dragPlane = new Plane(cam.transform.forward, hit.point);
//            offset = selectedObject.position - hit.point;
//        }
//    }

//    private void OnTouchPosition(InputAction.CallbackContext context)
//    {
//        currentTouchPos = context.ReadValue<Vector2>();

//        if (selectedObject != null)
//        {
//            Ray ray = cam.ScreenPointToRay(currentTouchPos);
//            if (dragPlane.Raycast(ray, out float distance))
//            {
//                selectedObject.position = ray.GetPoint(distance) + offset;
//            }
//        }
//    }

//    private void OnTouchRelease(InputAction.CallbackContext context)
//    {
//        selectedObject = null;
//    }


//}
