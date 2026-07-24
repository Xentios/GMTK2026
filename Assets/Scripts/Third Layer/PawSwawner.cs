using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class PawSwawner : MonoBehaviour
{
    public List<Sprite> pawns;

    public SpriteRenderer spriteRenderer;
    public GameObject pawHolder;

    public Transform dragArea;

    public DragManager dragManager;

    public void PawnSpawn()
    {
        spriteRenderer.sprite = pawns[Random.Range(0, pawns.Count)];
        pawHolder.transform.position = new Vector3(Random.Range(-10, 5), -10, 0);

        var target = dragArea.position + Random.insideUnitSphere;
        target.z = 0;
        Vector3 dir = pawHolder.transform.position - target;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        pawHolder.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        pawHolder.transform.DOMove(target, 0.4f).OnComplete(CleanUp);

    }

    private void CleanUp()
    {
        if (dragManager.dragedItems.Count > 0)
        {
            var item = dragManager.dragedItems[Random.Range(0, dragManager.dragedItems.Count)];
            dragManager.dragedItems.Remove(item);
            item.FireTowardsRight();
            GameManager.instance?.SetThirdLayerValue(item.ItemType, -1 * item.value);

        }

        pawHolder.transform.DOBlendableMoveBy(Vector3.down * 10, 1f);
        //spriteRenderer.transform.position = Vector3.right * 30;
    }
}
