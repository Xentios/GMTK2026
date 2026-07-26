using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;
    public static AudioManager instance;

    public AudioMixerGroup SFXMixerGroup;

    public List<AudioClip> modemSounds;
    public AudioSource generalAudioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.outputAudioMixerGroup = SFXMixerGroup;
            Debug.Log(s.name);
        }


    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            return;
        }
        if (s.source.isPlaying)
            return;

        s.source.Play();
    }

    public void StopMusic(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            return;
        }

        s.source.Stop();
    }

    public void PlaySFX(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            return;
        }

        if (s.source.isPlaying)
            return;

        s.source.PlayOneShot(s.clip, s.volume);
    }

    public void StopSFX(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            return;
        }

        s.source.Stop();
    }

    public void PlayModemSounds()
    {
        var clip = modemSounds[Random.Range(0, modemSounds.Count)];
        generalAudioSource.PlayOneShot(clip);
    }
}
