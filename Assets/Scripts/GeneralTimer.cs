using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GeneralTimer : MonoBehaviour
{

    public static GeneralTimer instance;

    public GameEvent gameOverEvent;
    public Stopwatch jamTimer;
    private TimeSpan totalJamTime = new TimeSpan(4, 0, 0, 0);

    public bool ShowDebug = true;

    private bool GAMEOVER = false;
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

    private void Update()
    {
        if (ShowDebug == false) return;

        Debug.Log(GetRemaningTime().ToString());
    }

    void OnDestroy()
    {
        if (instance == this) instance = null;
    }



    public TimeSpan GetRemaningTime()
    {
        if (GAMEOVER) return new TimeSpan();

        var result = totalJamTime - jamTimer.Elapsed;
        if (result.Ticks < 0) HandleGameOver();
        if (result.Ticks < 0) return new TimeSpan();
        return result;
    }


    public void RemoveTime(TimeSpan time)
    {
        if (GAMEOVER) return;


        totalJamTime = totalJamTime.Subtract(time);
        if (GetRemaningTime().Ticks <= 0) HandleGameOver();

    }

    private void HandleGameOver()
    {
        GAMEOVER = true;
        gameOverEvent.TriggerEvent();
    }
}
