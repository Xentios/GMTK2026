using NUnit.Framework;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class RandomMenu : MonoBehaviour
{
    [SerializeField] private UISlot slotPrefab;
    [SerializeField] private Transform content;

    [SerializeField] private ItemInfo[] items;

    [SerializeField] private float changeInterval = 5f;

    private void Start()
    {
        ChangeItems();
        StartCoroutine(ChangeRoutine());
    }

    IEnumerator ChangeRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeInterval);

            ChangeItems();
        }
    }

    void ChangeItems()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < 6; i++)
        {
            int random = Random.Range(0, items.Length);

            UISlot slot = Instantiate(slotPrefab, content);

            slot.SetItem(items[random]);
        }
    }
}
