using System.Collections;
using TMPEffects.Components;
using TMPro;
using UnityEngine;

public class ShowTotalSeconds : MonoBehaviour
{
    public TextMeshProUGUI secondsTextField;
    public double threshHold;


    public float secondsFlashDuration = 1f;
    public TMPAnimator secondsTMPAnimator;

    private void Update()
    {
        if (GeneralTimer.instance == null) return;

        var totalSeconds = GeneralTimer.instance.GetRemaningTime().TotalSeconds;
        secondsTextField.text = totalSeconds.ToString("F5");

        if (totalSeconds < threshHold)
        {
            //secondsTMPAnimator.enabled = true;
        }
    }

    public void ActivateTimeDown()
    {
        //secondsTextField.DOBlendableColor(Color.red, secondsFlashDuration).SetLoops(2, LoopType.Yoyo);
        StartCoroutine(PlayAnimator(secondsFlashDuration));
    }

    IEnumerator PlayAnimator(float time)
    {
        secondsTMPAnimator.enabled = true;
        yield return new WaitForSeconds(time);
        secondsTMPAnimator.enabled = false;

    }
}
