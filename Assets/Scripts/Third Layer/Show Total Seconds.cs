using DG.Tweening;
using TMPEffects.Components;
using TMPro;
using UnityEngine;

public class ShowTotalSeconds : MonoBehaviour
{
    public TextMeshProUGUI secondsTextField;
    public double threshHold;


    public float duration = 1f;
    public TMPAnimator TMPAnimator;

    private void Update()
    {
        if (GeneralTimer.instance == null) return;

        var totalSeconds = GeneralTimer.instance.GetRemaningTime().TotalSeconds;
        secondsTextField.text = totalSeconds.ToString("F5");

        if (totalSeconds < threshHold)
        {
            TMPAnimator.enabled = true;
        }
    }

    public void ActivateTimeDown()
    {
        secondsTextField.DOBlendableColor(Color.red, duration).SetLoops(2, LoopType.Yoyo);
    }
}
