using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMoreClocks : MonoBehaviour
{
    public float timeLimitToAddNewClock;
    private float timer;

    public List<GameObject> aditionalClocks;
    private int index = 0;
    void OnEnable()
    {
        timer = timeLimitToAddNewClock;
    }
    void OnDisable()
    {
        index = 0;
        timer = timeLimitToAddNewClock;
        foreach (GameObject go in aditionalClocks)
        {
            go.transform.localRotation = Quaternion.identity;
            go.SetActive(false);
        }
    }



    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && index < aditionalClocks.Count)
        {
            aditionalClocks[index].SetActive(true);
            index++;
            timer = timeLimitToAddNewClock;
            if (index == aditionalClocks.Count)
            {
                foreach (GameObject go in aditionalClocks)
                {
                    StartCoroutine(RotateAnObject(go));
                }
            }
        }
    }

    IEnumerator RotateAnObject(GameObject go)
    {
        float randomVal = Random.Range(1, 5f);
        while (true)
        {
            go.transform.localRotation *= Quaternion.Euler(0, 0, randomVal);
            yield return null;
        }

    }
}
