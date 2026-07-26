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
    public void PlaySyrupClick()
    {
        audioManager.PlaySFX("SyrupClick");
    }
    public void PlayKeyboardClick()
    {
        audioManager.PlaySFX("KeyboardClick");
    }
    public void PlayTabClick()
    {
        audioManager.PlaySFX("TabClick");
    }

    public void PlayPawEventSound()
    {
        audioManager.PlaySFX("PawEventSound");
    }
}
