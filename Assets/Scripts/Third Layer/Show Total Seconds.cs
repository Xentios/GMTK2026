using TMPro;
using UnityEngine;

public class ShowTotalSeconds : MonoBehaviour
{
    public TextMeshProUGUI secondsTextField;




    private void Update()
    {
        if (GeneralTimer.instance == null) return;

        var totalSeconds = GeneralTimer.instance.GetRemaningTime().TotalSeconds;
        secondsTextField.text = totalSeconds.ToString("F5");
    }
}
