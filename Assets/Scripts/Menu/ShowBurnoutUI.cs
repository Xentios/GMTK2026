using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ShowBurnoutUI : MonoBehaviour
{
    public Image burnOutFillImageHolder;
    private Image burnOutFillImage;

    public float WarningFlashLimit = 0.3f;
    private Tween colorTween;
    void Awake()
    {
        burnOutFillImage = GetComponent<Image>();
    }
    void Start()
    {
        colorTween = burnOutFillImageHolder.DOColor(Color.red, 0.5f).SetLoops(-1, LoopType.Yoyo);
        colorTween.Pause();
    }

    void Update()
    {
        if (GameManager.instance == null) return;


        burnOutFillImage.fillAmount = GameManager.instance.burnOutFiller;


        if (burnOutFillImage.fillAmount < WarningFlashLimit)
        {

            colorTween.Play();
            colorTween.timeScale = WarningFlashLimit / Mathf.Max(0.1f, burnOutFillImage.fillAmount);
        }
        else
        {
            colorTween.timeScale = 1f;
            colorTween.Pause();
            burnOutFillImageHolder.color = Color.white;
        }
    }
}
