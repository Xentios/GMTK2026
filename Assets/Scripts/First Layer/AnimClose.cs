using UnityEngine;

public class AnimClose : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.instance == null) return;

        if (GameManager.instance.DidWeVisitLayer2 == true) gameObject.SetActive(false);
    }

    void OnEnable()
    {



    }
}
