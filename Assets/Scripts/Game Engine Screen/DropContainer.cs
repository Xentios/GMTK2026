using System.Collections;
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

    public static float _speed;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            float currentInterval;

            if (_speed < 5)
                currentInterval = spawnInterval / (1f + (_speed * 0.15f));
            else
                currentInterval = spawnInterval / (1f + (_speed * 0.25f));


            currentInterval = Mathf.Max(currentInterval, 0.5f);

            yield return new WaitForSeconds(currentInterval * 1f);

            SpawnItem();
        }
    }


    private void SpawnItem()
    {
        ItemInfo randomItem = items[Random.Range(0, items.Length)];

        Item newItem = Instantiate(
            itemPrefab,
            spawnPoint.position,
            Quaternion.identity
        );

        newItem.Initialize(randomItem);

        Debug.Log("Speed: " + _speed);
        Debug.Log("Spawn Interval: " + (spawnInterval / (1f + (_speed * 0.3f))));
    }
}