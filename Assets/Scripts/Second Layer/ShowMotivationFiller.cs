using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class ShowMotivationFiller : MonoBehaviour
{
    [SerializeField]
    private Image MotivationFillImageLeft;
    [SerializeField]
    private Image MotivationFillImageRight;
    private Image MotivationFillImageBackGround;
    public float WarningFlashLimit = 0.3f;

    private Tween colorTween;
    void Awake()
    {
        MotivationFillImageBackGround = GetComponent<Image>();
    }

    void Start()
    {
        ColorUtility.TryParseHtmlString("#EF8A86", out Color color);
        if (color == null) color = Color.red;
        colorTween = MotivationFillImageBackGround.DOColor(color, 0.5f).SetLoops(-1, LoopType.Yoyo);

    }


    void Update()
    {
        if (GameManager.instance == null) return;


        MotivationFillImageLeft.fillAmount = GameManager.instance.DemotivationFiller;
        MotivationFillImageRight.fillAmount = GameManager.instance.DemotivationFiller;

        if (MotivationFillImageLeft.fillAmount < WarningFlashLimit)
        {

            colorTween.Play();
            colorTween.timeScale = WarningFlashLimit / Mathf.Max(0.1f, MotivationFillImageLeft.fillAmount);
        }
        else
        {
            colorTween.timeScale = 1f;
            colorTween.Pause();
        }


    }

}
