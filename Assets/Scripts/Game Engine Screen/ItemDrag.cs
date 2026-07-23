using UnityEngine;

[RequireComponent(typeof(Item))]
public class ItemDrag : MonoBehaviour
{
    private Item item;

    public bool IsDragging { get; private set; }

    private void Awake()
    {
        item = GetComponent<Item>();
    }

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
}