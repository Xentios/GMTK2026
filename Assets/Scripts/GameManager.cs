using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Volume burnOutWarn;
    public Volume demotivationWarn;

    public float warningLimit = 0.7f;
    public float barFillerSpeed = 1.0f;
    public float burnOutFiller;
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
        }
        else
        {
            burnOutWarn.weight = 0f;
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
