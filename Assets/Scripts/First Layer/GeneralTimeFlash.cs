using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class GeneralTimeFlash : MonoBehaviour
{
    private Image buttonImage;

    public float WarningFlashLimit = 10000f;
    private Tween colorTween;
    void Awake()
    {
        buttonImage = GetComponent<Image>();
    }
    void Start()
    {

        ColorUtility.TryParseHtmlString("#9FD7A8", out Color newColor);
        if (newColor == null) newColor = Color.red;
        colorTween = buttonImage.DOColor(newColor, 0.5f).SetLoops(-1, LoopType.Yoyo);
        colorTween.Pause();
    }

    void Update()
    {
        if (GeneralTimer.instance == null) return;

        if (GeneralTimer.instance.GetRemaningTime().TotalSeconds < WarningFlashLimit)
        {
            colorTween.Play();
        }
        //else
        //{
        //    buttonImage.color = Color.white;
        //}
    }
}