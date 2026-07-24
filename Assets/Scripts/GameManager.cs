using System;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Volume burnOutWarn;


    public Vector2 randomRangeForDisturbanceLayer2;
    public float coolDownTimerForLayer2 = 10f;
    public Vector2 randomRangeForDisturbanceLayer3;
    public float coolDownTimerForLayer3 = 5f;

    public float warningLimit = 0.3f;
    public float barFillerSpeed = 1.0f;
    public float burnOutFiller = 1f;


    public bool AnimationOnProgress;

    public bool Leve2LayerDisturbanceCalled;
    public bool Leve3LayerDisturbanceCalled;
    public GameEvent makeCatWalk;
    public GameEvent catPawEvent;

    [Obsolete]
    public float DemotivationFiller = 1f;

    private int CodeValue;
    private int AudioValue;
    private int ArtValue;

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
    {//işlem tersi
        burnOutFiller -= Time.deltaTime * barFillerSpeed;
        burnOutFiller = Mathf.Max(burnOutFiller, 0f);

        DemotivationFiller -= Time.deltaTime * barFillerSpeed;
        DemotivationFiller = Mathf.Max(DemotivationFiller, 0f);

        if (burnOutFiller < warningLimit)
        {
            burnOutWarn.weight = 1f - (burnOutFiller / warningLimit);
            TryToCallDisturbance();
        }
        else
        {
            burnOutWarn.weight = 0f;
        }

        coolDownTimerForLayer2 -= Time.deltaTime;
        coolDownTimerForLayer3 -= Time.deltaTime;

        if (coolDownTimerForLayer2 < 0f)
            Leve2LayerDisturbanceCalled = false;

        if (coolDownTimerForLayer3 < 0f)
            Leve3LayerDisturbanceCalled = false;
    }

    private void TryToCallDisturbance()
    {
        if (Leve2LayerDisturbanceCalled == false)
        {
            if (Random.value > randomRangeForDisturbanceLayer2.x && Random.value < randomRangeForDisturbanceLayer2.y)
            {
                Leve2LayerDisturbanceCalled = true;
                makeCatWalk.TriggerEvent();
                coolDownTimerForLayer2 = 10f;
            }
        }

        if (Leve3LayerDisturbanceCalled == false)
        {
            if (Random.value > randomRangeForDisturbanceLayer3.x && Random.value < randomRangeForDisturbanceLayer3.y)
            {
                Leve3LayerDisturbanceCalled = true;
                catPawEvent.TriggerEvent();
                coolDownTimerForLayer3 = 5f;
            }
        }



    }

    public void RemoveBurnOut(float time)
    {
        if (burnOutFiller < 1)
        {
            burnOutFiller += time;
            burnOutFiller = Mathf.Max(0f, burnOutFiller);
        }

    }

    public void RemoveDeMotivation(float time)
    {//Min değil Max olacak
        DemotivationFiller -= time;
        //DemotivationFiller = Mathf.Min(0, burnOutFiller);
        DemotivationFiller = Mathf.Max(0f, DemotivationFiller);
    }

    public int GetThirdLayerValue(ItemType type)
    {
        int value = 0;
        switch (type)
        {
            case ItemType.Code:
            value = CodeValue;
            break;
            case ItemType.Art:
            value = ArtValue;
            break;
            case ItemType.Audio:
            value = AudioValue;
            break;

        }

        return value;
    }

    public void SetThirdLayerValue(ItemType type, int newValue)
    {
        //int value = 0;
        switch (type)
        {
            case ItemType.Code:
            CodeValue += newValue;
            CodeValue = Math.Max(0, CodeValue);
            CodeValue = Math.Min(100, CodeValue);
            break;
            case ItemType.Art:
            ArtValue += newValue;
            ArtValue = Math.Max(0, ArtValue);
            ArtValue = Math.Min(100, ArtValue);
            break;
            case ItemType.Audio:
            AudioValue += newValue;
            AudioValue = Math.Max(0, AudioValue);
            AudioValue = Math.Min(100, AudioValue);
            break;

        }

    }


}
