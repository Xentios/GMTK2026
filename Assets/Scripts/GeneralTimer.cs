using System;
using System.Diagnostics;
using UnityEngine;

public class GeneralTimer : MonoBehaviour
{

    public static GeneralTimer instance;

    public Stopwatch jamTimer;
    private TimeSpan totalJamTime = new TimeSpan(4, 0, 0, 0);
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        jamTimer = new Stopwatch();
        jamTimer.Start();

        DontDestroyOnLoad(transform.root.gameObject);
    }

    //private void Update()
    //{

    //    Debug.Log(GetRemaningTime().ToString());
    //}

    void OnDestroy()
    {
        if (instance == this) instance = null;
    }



    public TimeSpan GetRemaningTime()
    {
        var result = totalJamTime - jamTimer.Elapsed;
        if (result.Ticks < 0) return new TimeSpan();
        return result;
    }


    public void RemoveTime(TimeSpan time)
    {
        totalJamTime.Subtract(time);
    }
}
