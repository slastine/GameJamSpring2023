using UnityEngine.Audio;
using System;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound theme;

    void Awake()
    {
        /*MainMenuUi.MusicVolumeChanged += (v) =>
            theme.source.volume = v * theme.volume;
        MainMenuUi.SfxVolumeChanged += (v) =>
        {
            foreach (var s in sounds) 
                s.source.volume = v * s.volume;
        };*/

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

        theme.source = gameObject.AddComponent<AudioSource>();
        theme.source.clip = theme.clip;

        theme.source.volume = theme.volume * PlayerPrefs.GetFloat("MusicVol");
        theme.source.pitch = theme.pitch;
        theme.source.loop = true;

        theme.source.Play();
        float v = PlayerPrefs.GetFloat("SfxVol");
        Debug.Log(v);
        foreach (var s in sounds)
            s.source.volume = v * s.volume;
        float m = PlayerPrefs.GetFloat("MusicVol");
        theme.source.volume = m * theme.volume;

        
    }

    void Start ()
    {
        
    }

    public void Play (String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = s.volume * PlayerPrefs.GetFloat("SfxVol");
        s.source.Play();
    }
}
