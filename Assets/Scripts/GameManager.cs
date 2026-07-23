using System;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Volume burnOutWarn;
    [Obsolete]
    public Volume demotivationWarn;

    public Vector2 randomRangeForDisturbanceLayer2;
    public float coolDownTimerForLayer2 = 10f;
    public Vector2 randomRangeForDisturbanceLayer3;
    public float coolDownTimerForLayer3 = 5f;

    public float warningLimit = 0.7f;
    public float barFillerSpeed = 1.0f;
    public float burnOutFiller;


    public bool Leve2LayerDisturbanceCalled;
    public bool Leve3LayerDisturbanceCalled;
    public GameEvent makeCatWalk;

    [Obsolete]
    public float DemotivationFiller;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(transform.root.gameObject);
    }

    private void Update()
    {
        burnOutFiller += Time.deltaTime * barFillerSpeed;
        DemotivationFiller += Time.deltaTime * barFillerSpeed;

        if (burnOutFiller > warningLimit)
        {
            burnOutWarn.weight = (burnOutFiller - warningLimit) / (1f - warningLimit);
            TryToCallDisturbance();
        }
        else
        {
            burnOutWarn.weight = 0f;
        }

        coolDownTimerForLayer2 -= Time.deltaTime;
        coolDownTimerForLayer3 -= Time.deltaTime;

        if (coolDownTimerForLayer2 < 0f) Leve2LayerDisturbanceCalled = false;
        if (coolDownTimerForLayer3 < 0f) Leve3LayerDisturbanceCalled = false;
    }

    private void TryToCallDisturbance()
    {
        if (Leve2LayerDisturbanceCalled == true) return;

        if (Random.value > randomRangeForDisturbanceLayer2.x && Random.value < randomRangeForDisturbanceLayer2.y)
        {
            Leve2LayerDisturbanceCalled = true;
            makeCatWalk.TriggerEvent();
            coolDownTimerForLayer2 = 10f;
        }

    }

    public void RemoveBurnOut(float time)
    {
        burnOutFiller -= time;
        burnOutFiller = Mathf.Min(0, burnOutFiller);

    }

    public void RemoveDeMotivation(float time)
    {
        DemotivationFiller -= time;
        DemotivationFiller = Mathf.Min(0, burnOutFiller);

    }

}
