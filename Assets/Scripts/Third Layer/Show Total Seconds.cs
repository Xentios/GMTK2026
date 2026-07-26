using System.Collections;
using TMPEffects.Components;
using TMPro;
using UnityEngine;

public class ShowTotalSeconds : MonoBehaviour
{
    public TextMeshProUGUI secondsTextField;
    public double threshHold = 10000;


    public float secondsFlashDuration = 1.2f;
    public TMPAnimator secondsTMPAnimator;
    public TMPAnimator secondsTextTMPAnimator;

    private void Update()
    {
        if (GeneralTimer.instance == null) return;

        var totalSeconds = GeneralTimer.instance.GetRemaningTime().TotalSeconds;
        secondsTextField.text = totalSeconds.ToString("F3");

        if (totalSeconds < threshHold)
        {
            secondsTextTMPAnimator.enabled = true;
        }
    }

    public void ActivateTimeDown()
    {
        //secondsTextField.DOBlendableColor(Color.red, secondsFlashDuration).SetLoops(2, LoopType.Yoyo);
        StartCoroutine(PlayAnimator(secondsFlashDuration));
    }

    IEnumerator PlayAnimator(float time)
    {
        if (secondsTMPAnimator.enabled == enabled) yield break;

        secondsTMPAnimator.enabled = true;

        yield return new WaitForSeconds(time);
        secondsTMPAnimator.enabled = false;

    }
}
