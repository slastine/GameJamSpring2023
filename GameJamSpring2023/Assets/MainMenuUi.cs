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

    public void UpdateMasterVol() => MasterVolumeChanged?.Invoke(MasterVol = MasterVolSlider.value);
    public void UpdateSfxVol() => SfxVolumeChanged?.Invoke(SfxVol = SfxVolSlider.value * MasterVol);
    public void UpdateMusicVol() => MusicVolumeChanged?.Invoke(MusicVol = MusicVolSlider.value * MasterVol);
}