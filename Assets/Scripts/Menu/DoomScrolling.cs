using UnityEngine;

public class DoomScrolling : MonoBehaviour
{
    [Range(2f, 10000f)]
    public int timeScale = 2;



    private void Update()
    {
        if (GeneralTimer.instance == null) return;

        int milliseconds = (int) (Time.deltaTime * 1000f);
        GeneralTimer.instance.RemoveTime(new System.TimeSpan(0, 0, minutes: 0, milliseconds * timeScale));
    }
}
