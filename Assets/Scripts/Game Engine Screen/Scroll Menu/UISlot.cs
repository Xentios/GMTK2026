using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UISlot : MonoBehaviour
{
    private Image image;
    public ItemInfo CurrentItem {  get; private set; }
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetItem(ItemInfo item)
    {
        CurrentItem = item;
        image.sprite = item.sprite;
    }
}
