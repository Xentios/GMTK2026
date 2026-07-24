using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;

public class FindAndFadeOut : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private float fadeDuration = 1f;

    private AudioSource musicSource;
    private Tween fadeTween;

    private void Awake()
    {

    }

    public void FadeOut()
    {
        musicSource = System.Array.Find(
          Object.FindObjectsByType<AudioSource>(FindObjectsSortMode.None),
          x => x.outputAudioMixerGroup == musicMixerGroup);
        if (musicSource == null)
            return;

        fadeTween?.Kill();

        fadeTween = musicSource
            .DOFade(0f, fadeDuration)
            .OnComplete(() => musicSource.Stop());
    }
}
