using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class ShowMotivationFiller : MonoBehaviour
{
    private Image MotivationFillImage;
    public float WarningFlashLimit = 0.3f;

    private Tween colorTween;
    void Awake()
    {
        MotivationFillImage = GetComponent<Image>();
    }

    void Start()
    {
        colorTween = MotivationFillImage.DOColor(Color.red, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }


    void Update()
    {
        if (GameManager.instance == null) return;


        MotivationFillImage.fillAmount = GameManager.instance.DemotivationFiller;

        if (MotivationFillImage.fillAmount < WarningFlashLimit)
        {

            colorTween.Play();
            colorTween.timeScale = WarningFlashLimit / Mathf.Max(0.1f, MotivationFillImage.fillAmount);
        }
        else
        {
            colorTween.timeScale = 1f;
            colorTween.Pause();
        }


    }

}
