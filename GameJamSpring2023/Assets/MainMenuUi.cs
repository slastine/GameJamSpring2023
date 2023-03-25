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

    Slider MVS => MasterVolSlider.GetComponent<Slider>();
    Slider SVS => SfxVolSlider.GetComponent<Slider>();
    Slider MuVS => MusicVolSlider.GetComponent<Slider>();

    public GameObject MasterVolSlider;
    public GameObject SfxVolSlider;
    public GameObject MusicVolSlider;

    public void StartGame() => SceneManager.LoadScene(1);

    public void UpdateMasterVol() => MasterVol = MVS.value;
    public void UpdateSfxVol() => SfxVol = SVS.value * MasterVol;
    public void UpdateMusicVol() => MusicVol = MuVS.value * MasterVol;
}
