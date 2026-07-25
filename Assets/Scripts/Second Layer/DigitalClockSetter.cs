using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class DigitalClockSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clockText;

    private float currentTime;
    private int multiplerForTime;
    DoomScrolling dS = new DoomScrolling();

    private void Start()
    {
        currentTime = 8 * 60 * 60;
    }

    private void Update()
    {

        multiplerForTime = dS.timeScale + 25;
        currentTime += Time.deltaTime * multiplerForTime;

        int hours = Mathf.FloorToInt(currentTime / 3600) % 24;
        int minutes = Mathf.FloorToInt((currentTime % 60) / 60);


        clockText.text = $"{hours:00}:{minutes:00}";
    }

}
