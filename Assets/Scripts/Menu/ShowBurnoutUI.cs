using UnityEngine;
using UnityEngine.UI;

public class ShowBurnoutUI : MonoBehaviour
{
    private Image burnOutFillImage;
    void Awake()
    {
        burnOutFillImage = GetComponent<Image>();
    }

    void Update()
    {
        if (GameManager.instance == null) return;


        burnOutFillImage.fillAmount = GameManager.instance.burnOutFiller;
    }
}
