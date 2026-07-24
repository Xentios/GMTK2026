using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragManager : MonoBehaviour
{
    private Camera cam;
    private ItemDrag currentItem;

    public BoxCollider2D dragArea;

    public List<Item> dragedItems;

    private Vector3 offset;
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
                    offset = currentItem.transform.position - (Vector3) mouseWorld;
                }
            }
        }

        if (currentItem != null && Mouse.current.leftButton.isPressed) //hold
        {
            currentItem.transform.position = new Vector3(
                mouseWorld.x,
                mouseWorld.y,
                currentItem.transform.position.z) + offset;
        }

        if (currentItem != null &&
             Mouse.current.leftButton.wasReleasedThisFrame) //release
        {
            currentItem.EndDrag();
            if (dragArea.bounds.Contains(currentItem.transform.position))
            {
                GameManager.instance?.SetThirdLayerValue(currentItem.GetMyItem().ItemType, currentItem.GetMyItem().value);
                dragedItems.Add(currentItem.GetMyItem());
                currentItem.GetMyItem().ScaleDownAfterSuccessDrag();
                Destroy(currentItem);
            }
            currentItem = null;
        }
    }
}