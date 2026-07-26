using DG.Tweening;
using UnityEngine;

public class SumitPopUpAnimation : MonoBehaviour
{
    private Vector3 startUpScale = Vector3.one;

    public float duration = 1f;
    private void Start()
    {
        //startUpScale = transform.localScale;
    }

    void OnEnable()
    {
        transform.DOScale(startUpScale, duration);
    }

    void OnDisable()
    {
        transform.DOKill();
        transform.localScale = Vector3.zero;
    }
}
