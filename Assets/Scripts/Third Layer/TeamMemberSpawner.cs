using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TeamMemberSpawner : MonoBehaviour
{
    public GameObject teamMemberPrefab;

    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float firstDelay = 10f;

    public BoxCollider2D spawnCollider;

    private void Start()
    {
        StartCoroutine(SpawnLoop());

    }

    IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(firstDelay);

        while (true)
        {


            yield return new WaitForSeconds(spawnInterval * 1f);

            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        var pos = GetRandomPointInsideCollider(spawnCollider);
        var result = Instantiate(teamMemberPrefab, pos, Quaternion.identity);
    }


    public Vector2 GetRandomPointInsideCollider(BoxCollider2D boxCollider)
    {
        Vector3 extents = boxCollider.size / 2f;
        Vector3 point = new Vector3(
            Random.Range(-extents.x, extents.x),
            Random.Range(-extents.y, extents.y),
            Random.Range(-extents.z, extents.z)
        );

        return boxCollider.transform.TransformPoint(point);
    }

}
