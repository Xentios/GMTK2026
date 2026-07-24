using TMPro;
using UnityEngine;

public class ShowTotalSeconds : MonoBehaviour
{
    public TextMeshProUGUI secondsTextField;
    public double threshHold;
    //public TMPEffects.TMPAnimations. Component;

    private void Update()
    {
        if (GeneralTimer.instance == null) return;

        var totalSeconds = GeneralTimer.instance.GetRemaningTime().TotalSeconds;
        secondsTextField.text = totalSeconds.ToString("F5");

        if (totalSeconds < threshHold)
        {
            //Component.
        }
    }
}
