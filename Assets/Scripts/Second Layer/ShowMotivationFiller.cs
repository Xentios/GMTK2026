using UnityEngine;
using UnityEngine.UI;
public class ShowMotivationFiller : MonoBehaviour
{
    private Image MotivationFillImage;
    void Awake()
    {
        MotivationFillImage = GetComponent<Image>();
    }

    void Update()
    {
        if (GameManager.instance == null) return;


        MotivationFillImage.fillAmount = GameManager.instance.DemotivationFiller;
    }
}
