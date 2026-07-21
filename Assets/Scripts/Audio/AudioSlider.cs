using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{


    [SerializeField]
    private AudioMixer Mixer;
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private AudioMixMode MixMode;

    [SerializeField]
    private string ExposedParameterName;

    [SerializeField]
    private AudioSource Example_effect;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    private void Start()
    {

        var recordedValue = PlayerPrefs.GetFloat(ExposedParameterName, 1);
        Mixer.SetFloat(ExposedParameterName, Mathf.Log10(recordedValue) * 20);
    }
    private void OnEnable()
    {
        var recordedValue = PlayerPrefs.GetFloat(ExposedParameterName, 1);
        Mixer.SetFloat(ExposedParameterName, Mathf.Log10(recordedValue) * 20);
        slider.value = recordedValue;
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(ExposedParameterName, slider.value);
        PlayerPrefs.Save();
    }

    public void OnChangeSlider(float Value)
    {

        switch (MixMode)
        {

            case AudioMixMode.LinearMixerVolume:
            Mixer.SetFloat(ExposedParameterName, (-80 + Value * 80));
            break;
            case AudioMixMode.LogrithmicMixerVolume:
            Mixer.SetFloat(ExposedParameterName, Mathf.Log10(Value) * 20);
            break;
        }


        PlayerPrefs.SetFloat(ExposedParameterName, Value);
        PlayerPrefs.Save();

        if (Example_effect != null && Example_effect.isPlaying == false)
        {
            Example_effect.Play();
        }
    }


    public enum AudioMixMode
    {
        LinearMixerVolume,
        LogrithmicMixerVolume
    }
}
