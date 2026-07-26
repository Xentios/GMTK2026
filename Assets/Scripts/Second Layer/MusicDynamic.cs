using UnityEngine;

public class MusicDynamic : MonoBehaviour
{
    public float WarningFlashLimit = 0.3f;
    private AudioSource musicSource;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (GameManager.instance == null) return;




        if (GameManager.instance.DemotivationFiller < WarningFlashLimit)
        {

            musicSource.pitch = GameManager.instance.DemotivationFiller / WarningFlashLimit;

        }
        else
        {
            musicSource.pitch = 1f;
        }


    }
}
