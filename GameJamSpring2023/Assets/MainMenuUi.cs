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

    public void StartGame() => SceneManager.LoadScene(1);

    public void UpdateMasterVol() => MasterVol = MasterVolSlider.value;
    public void UpdateSfxVol() => SfxVol = SfxVolSlider.value * MasterVol;
    public void UpdateMusicVol() => MusicVol = MusicVolSlider.value * MasterVol;
}
