using TMPro;
using UnityEngine;

public class ShowTimeRemanined : MonoBehaviour
{
    public TextMeshProUGUI days;
    public TextMeshProUGUI hours;
    public TextMeshProUGUI minutes;
    public TextMeshProUGUI seconds;


    private void Awake()
    {
        days = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        hours = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        minutes = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        seconds = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        ChangeALlValues();
    }


    private void ChangeValue(int value, TextMeshProUGUI textField)
    {
        if (value < 0) value = 0;

        textField.text = value.ToString();
    }

    private void ChangeALlValues()
    {
        ChangeValue(GeneralTimer.instance.GetRemaningTime().Days, days);
        ChangeValue(GeneralTimer.instance.GetRemaningTime().Hours, hours);
        ChangeValue(GeneralTimer.instance.GetRemaningTime().Minutes, minutes);
        ChangeValue(GeneralTimer.instance.GetRemaningTime().Seconds, seconds);
    }


}
