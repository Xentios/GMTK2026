using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    public void PlayMusic()
    {
        audioManager.PlayMusic("Music");
    }
    public void StopMusic()
    {
        audioManager.StopMusic("Music");
    }
    public void PlayButtonClick()
    {
        audioManager.PlaySFX("ButtonClick");
    }

    public void PlayOnClick()
    {
        audioManager.PlaySFX("OnClick");
    }

    public void PlayCatClick ()
    {
        audioManager.PlaySFX("CatClick");
    }
    public void PlayCatEventClick()
    {
        audioManager.PlaySFX("CatEventClick");
    }
}
