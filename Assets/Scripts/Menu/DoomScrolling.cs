using UnityEngine;

public class DoomScrolling : MonoBehaviour
{
    [Range(2f, 10000f)]
    public int timeScale = 2;

    public float MotivationTimeSpeed = 1f;


    private void Update()
    {
        if (GeneralTimer.instance == null) return;

        int milliseconds = (int) (Time.deltaTime * 1000f);
        GameManager.instance?.RemoveDeMotivation(Time.deltaTime * MotivationTimeSpeed);
        GeneralTimer.instance.RemoveTime(new System.TimeSpan(0, 0, minutes: 0, milliseconds * timeScale));
    }
}
