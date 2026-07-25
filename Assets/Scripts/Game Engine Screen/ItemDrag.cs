using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Item))]
public class ItemDrag : MonoBehaviour
{
    private Item item;
    //TODO yeah this is just a dirty way to do it.
    public InputActionReference mousePosition;
    private PolygonCollider2D collider;
    private Vector3 defaultScale;
    public float defaultScaleModifier = 1.1f;

    public bool IsDragging { get; private set; }

    private void Awake()
    {
        item = GetComponent<Item>();
        defaultScale = item.gameObject.transform.localScale;

    }
    //void OnEnable()
    //{
    //    //  mouseClick.action.performed += ClickMouse;
    //    mousePosition.action.performed += checkMousePos;
    //}

    //void OnDisable()
    //{
    //    //mouseClick.action.performed -= ClickMouse;
    //    mousePosition.action.performed -= checkMousePos;
    //}

    private void Start()
    {
        collider = item.gameObject.GetComponent<PolygonCollider2D>();
    }
    private void Update()
    {
        if (collider == null) return;

        var mousePos = mousePosition.action.ReadValue<Vector2>();
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;
        if (collider.bounds.Contains(worldPos) == true)
        {
            transform.localScale = defaultScale * defaultScaleModifier;
        }
        else
        {
            transform.localScale = defaultScale;
        }
    }

    //private void checkMousePos(InputAction.CallbackContext context)
    //{

    //}

    public void BeginDrag()
    {
        IsDragging = true;
        item.StartDrag();
    }

    public void EndDrag()
    {
        IsDragging = false;
        item.EndDrag();
    }

    public Item GetMyItem() { return item; }
}