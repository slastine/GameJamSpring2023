using System;
using System.Collections;
using System.Collections.Generic;
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

    public static event Action<float> MasterVolumeChanged;
    public static event Action<float> SfxVolumeChanged;
    public static event Action<float> MusicVolumeChanged;

    public void StartGame() => SceneManager.LoadScene(1);

    public void UpdateMasterVol() 
    {
        MasterVol = MasterVolSlider.value;
        SfxVol = SfxVolSlider.value * MasterVol;
        MusicVol = MusicVolSlider.value * MasterVol;

        MasterVolumeChanged?.Invoke(MasterVol);
        SfxVolumeChanged?.Invoke(SfxVol);
        MusicVolumeChanged?.Invoke(MusicVol);
    }
    public void UpdateSfxVol()
    {
        SfxVol = SfxVolSlider.value * MasterVol;
        SfxVolumeChanged?.Invoke(SfxVol);
    }
    public void UpdateMusicVol() 
    {
        MusicVol = MusicVolSlider.value * MasterVol;
        MusicVolumeChanged?.Invoke(MusicVol);
    }
}