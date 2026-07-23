using UnityEngine;

[System.Serializable]
public class ItemInfo
{
    public ItemType type;
    public Sprite[] sprites;
}

public class DropContainer : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private Item itemPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval = 2f;

    [Header("Items")]
    [SerializeField] private ItemInfo[] items;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnItem), 0f, spawnInterval);
    }

    private void SpawnItem()
    {
        ItemInfo randomItem = items[Random.Range(0, items.Length)];

        Item newItem = Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);

        newItem.Initialize(randomItem);
    }
}