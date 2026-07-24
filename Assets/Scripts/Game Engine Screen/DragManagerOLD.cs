using UnityEngine;
using UnityEngine.InputSystem;

public class DragManagerOLD : MonoBehaviour
{
    private Camera cam;
    private ItemDrag currentItem;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector2 mouseWorld = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());


        if (Mouse.current.leftButton.wasPressedThisFrame) //click
        {
            Collider2D hit = Physics2D.OverlapPoint(mouseWorld);

            if (hit != null)
            {
                ItemDrag drag = hit.GetComponent<ItemDrag>();

                if (drag != null)
                {
                    currentItem = drag;
                    currentItem.BeginDrag();
                }
            }
        }

        if (currentItem != null && Mouse.current.leftButton.isPressed) //hold
        {
            currentItem.transform.position = new Vector3(
                mouseWorld.x,
                mouseWorld.y,
                currentItem.transform.position.z);
        }

        if (currentItem != null &&
             Mouse.current.leftButton.wasReleasedThisFrame) //release
        {
            currentItem.EndDrag();
            currentItem = null;
        }
    }
}