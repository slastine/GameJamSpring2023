using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UiManager : MonoBehaviour
{
    public static float MasterVol = 1f;
    public static float SfxVol = 1f;
    public static float MusicVol = 1f;

    [SerializeField] public Slider MasterVolSlider;
    [SerializeField] public Slider SfxVolSlider;
    [SerializeField] public Slider MusicVolSlider;

    public void StartGame() => SceneManager.LoadScene(1);

    public void UpdateMasterVol() => AudioListener.volume = MasterVolSlider.value;
    public void UpdateSfxVol() => SfxVol = SfxVolSlider.value * MasterVol;
    public void UpdateMusicVol() => MusicVol = MusicVolSlider.value * MasterVol;
}
