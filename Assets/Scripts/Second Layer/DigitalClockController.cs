using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class DigitalClockController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clockText;
    private int hour;
    private int minute;

    private void Start()
    {
        
    }

    private void Update()
    {
        hour += 1;
        hour %= 24;
        minute += 1;
        minute %= 60;
        clockText.text = $"{hour:00}:{minute:00}";
    }

}
