using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GetAssetValues : MonoBehaviour
{
    public ItemType itemType;
    public TextMeshProUGUI textMeshPro;
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

        oldValue = value;
        //fillBar.fillAmount = ((float) value / 100f);
        float fillvalue = (float) value / 100f;
        fillBar.DOFillAmount(fillvalue, fillDelay);
    }

}
