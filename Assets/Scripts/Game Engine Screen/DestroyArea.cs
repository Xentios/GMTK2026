using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();

        if (item != null)
        {
            Destroy(item.gameObject);
            Debug.Log("silindi");
        }
    }
}