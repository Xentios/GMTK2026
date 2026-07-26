using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GetAssetValues : MonoBehaviour
{
    public ItemType itemType;
    public TextMeshProUGUI textMeshPro;
    public GameObject Icon;
    public GameObject Bar;
    public Image fillBar;

    public float fillDelay = 1f;

    private int oldValue = 0;

    private void Awake()
    {
        if (GameManager.instance == null) return;

        oldValue = GameManager.instance.GetThirdLayerValue(itemType);

    }

    private void Start()
    {
        fillBar.fillAmount = ((float) oldValue / 100f);
        textMeshPro.text = oldValue + "/100";
    }

    private void Update()
    {
        if (GameManager.instance == null) return;


    }

    public void OnValueChanged()
    {
        if (GameManager.instance == null) return;

        var value = GameManager.instance.GetThirdLayerValue(itemType);
        if (oldValue == value) return;

        Icon.transform.localScale = Vector3.one;
        Bar.transform.localScale = Vector3.one;
        if (oldValue > value)
        {
            Icon.transform.DOScale(Vector3.one * 0.8f, fillDelay / 3f).SetLoops(2, LoopType.Yoyo);
            Bar.transform.DOScale(Vector3.one * 0.8f, fillDelay / 3f).SetLoops(2, LoopType.Yoyo);
        }
        else
        {
            Bar.transform.DOScale(Vector3.one * 1.4f, fillDelay / 3f).SetLoops(2, LoopType.Yoyo);
        }

        oldValue = value;
        //fillBar.fillAmount = ((float) value / 100f);
        textMeshPro.text = oldValue + "/100";
        float fillvalue = (float) value / 100f;
        fillBar.DOFillAmount(fillvalue, fillDelay);


    }

}
