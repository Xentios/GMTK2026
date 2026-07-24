using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class PawSwawner : MonoBehaviour
{
    public List<Sprite> pawns;

    public SpriteRenderer spriteRenderer;

    public Transform dragArea;

    public void PawnSpawn()
    {
        spriteRenderer.sprite = pawns[Random.Range(0, pawns.Count)];
        spriteRenderer.transform.position = new Vector3(Random.Range(-10, 10), -10, 0);
        spriteRenderer.transform.DOMove(dragArea.position, 0.4f).OnComplete(CleanUp);
    }

    private void CleanUp()
    {
        spriteRenderer.transform.DOBlendableMoveBy(Vector3.down * 10, 1f);
        //spriteRenderer.transform.position = Vector3.right * 30;
    }
}
