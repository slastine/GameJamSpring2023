using UnityEngine.Audio;
using System;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound theme;

    // Start is called before the first frame update
    void Awake()
    {
        MainMenuUi.MusicVolumeChanged += (v) =>
            theme.source.volume = v * theme.volume;
        MainMenuUi.SfxVolumeChanged += (v) =>
        {
            foreach (var s in sounds) 
                s.source.volume = v * s.volume;
        };

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    void Start ()
    {
        theme.source = gameObject.AddComponent<AudioSource>();
        theme.source.clip = theme.clip;

        theme.source.volume = theme.volume * MainMenuUi.MusicVol;
        theme.source.pitch = theme.pitch;
        theme.source.loop = true;

        theme.source.Play();
    }

    public void Play (String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = s.volume * MainMenuUi.SfxVol;
        s.source.Play();
    }
}
