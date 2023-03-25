using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuUi : MonoBehaviour
{
    public static float MasterVol = 1f;
    public static float SfxVol = 1f;
    public static float MusicVol = 1f;

    [SerializeField] public Slider MasterVolSlider;
    [SerializeField] public Slider SfxVolSlider;
    [SerializeField] public Slider MusicVolSlider;

    public void StartGame() => SceneManager.LoadScene(1);

    public void UpdateMasterVol() => MasterVol = MasterVolSlider.value;
    public void UpdateSfxVol() => SfxVol = SfxVolSlider.value * MasterVol;
    public void UpdateMusicVol() => AudioListener.volume = MusicVolSlider.value * MasterVol;
}
