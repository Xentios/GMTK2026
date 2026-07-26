using TMPro;
using UnityEngine;

public class DigitalClockController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clockText;
    private int hour;
    private int minute;

    [SerializeField]
    public float clockAnimationSpeedReset;

    private float clockAnimationSpeed = 1f;

    private void Start()
    {
        //clockAnimationSpeed = clockAnimationSpeedReset;
        hour = 8;
        minute = Random.Range(0, 60);
    }

    private void Update()
    {
        clockAnimationSpeed -= Time.deltaTime;
        if (clockAnimationSpeed > 0) return;

        minute += 1;
        if (minute > 59)
        {
            hour += 1;
            hour %= 24;
        }
        minute %= 60;
        clockText.text = $"{hour:00}:{minute:00}";
        clockAnimationSpeed = clockAnimationSpeedReset;
    }

}
