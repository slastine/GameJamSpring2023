using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUi : MonoBehaviour
{
    public static float MasterVol = 1f;
    public static float SfxVol = 1f;
    public static float MusicVol = 1f;

    public Slider MasterVolSlider;
    public Slider SfxVolSlider;
    public Slider MusicVolSlider;
    public Slider SpeedSlider;

    public static event Action<float> MasterVolumeChanged;
    public static event Action<float> SfxVolumeChanged;
    public static event Action<float> MusicVolumeChanged;
    public static event Action<float> SpeedChanged;

    public void StartGame() => SceneManager.LoadScene(2);

    private void Awake()
    {
        MasterVol = MasterVolSlider.value;
        SfxVol = SfxVolSlider.value;
        MusicVol = MusicVolSlider.value;

        PlayerPrefs.SetFloat("MasterVol", MasterVolSlider.value);
        PlayerPrefs.SetFloat("SfxVol", SfxVolSlider.value * MasterVol);
        PlayerPrefs.SetFloat("MusicVol", MusicVolSlider.value * MasterVol);
        PlayerPrefs.SetFloat("Speed", SpeedSlider.value);
        PlayerPrefs.SetInt("Color", 0);
    }

    public void UpdateMasterVol() 
    {
        MasterVol = MasterVolSlider.value;
        SfxVol = SfxVolSlider.value * MasterVol;
        MusicVol = MusicVolSlider.value * MasterVol;

        PlayerPrefs.SetFloat("MasterVol", MasterVolSlider.value);
        PlayerPrefs.SetFloat("SfxVol", SfxVolSlider.value * MasterVol);
        PlayerPrefs.SetFloat("MusicVol", MusicVolSlider.value * MasterVol);

        MasterVolumeChanged?.Invoke(MasterVol);
        SfxVolumeChanged?.Invoke(SfxVol);
        MusicVolumeChanged?.Invoke(MusicVol);
    }

    public void UpdateSfxVol()
    {
        SfxVol = SfxVolSlider.value * MasterVol;
        PlayerPrefs.SetFloat("SfxVol", SfxVolSlider.value * MasterVol);
        SfxVolumeChanged?.Invoke(SfxVol);
    }

    public void UpdateMusicVol() 
    {
        MusicVol = MusicVolSlider.value * MasterVol;
        PlayerPrefs.SetFloat("MusicVol", MusicVolSlider.value * MasterVol);
        MusicVolumeChanged?.Invoke(MusicVol);
    }

    public void UpdateSpeed()
    {
        PlayerPrefs.SetFloat("Speed", SpeedSlider.value);
        GameObject.Find("Audio Shenanigans").GetComponent<audioManager>().theme.source.pitch = 1 + (SpeedSlider.value / SpeedSlider.maxValue - .5f) * 2;
    }

    public void UpdateColor(int c)
    {
        PlayerPrefs.SetInt("Color", c);
    }
}