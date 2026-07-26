using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TeamMemberSpawner : MonoBehaviour
{
    public GameObject teamMemberPrefab;

    public List<AudioClip> voiceLines;

    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private float firstDelay = 10f;
    [SerializeField] private float spawnIntervalModifier = 1f;

    [SerializeField] private float audioPlayDelay = 1.5f;

    public BoxCollider2D spawnCollider;

    private int lastIndex = -1;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(firstDelay);

        while (true)
        {
            spawnIntervalModifier = 1f;

            if (GameManager.instance != null && GameManager.instance.DemotivationFiller < 0.1f)
            {
                spawnIntervalModifier = 0.2f;
            }

            yield return new WaitForSeconds(spawnInterval * spawnIntervalModifier);
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        var pos = GetRandomPointInsideCollider(spawnCollider);
        var result = Instantiate(teamMemberPrefab, pos, Quaternion.identity);
        var randomVoiceIndex = RandomExcept(0, voiceLines.Count, lastIndex);
        lastIndex = randomVoiceIndex;
        result.GetComponent<AudioSource>().clip = voiceLines[randomVoiceIndex];
        result.GetComponent<AudioSource>().PlayDelayed(audioPlayDelay);
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



    private int RandomExcept(int minInclusive, int maxExclusive, int excluded)
    {
        if (excluded < minInclusive || excluded >= maxExclusive)
            return Random.Range(minInclusive, maxExclusive);

        int value = Random.Range(minInclusive, maxExclusive - 1);

        return value >= excluded ? value + 1 : value;
    }

}
