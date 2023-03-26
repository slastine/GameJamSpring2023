using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UiManager : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetFloat("MasterVol", MasterVolSlider.value);
        PlayerPrefs.SetFloat("SfxVol", SfxVolSlider.value * MasterVol);
        PlayerPrefs.SetFloat("MusicVol", MusicVolSlider.value * MasterVol);
        PlayerPrefs.SetFloat("Speed", SpeedSlider.value);
    }

    public static float MasterVol = 1f;
    public static float SfxVol = 1f;
    public static float MusicVol = 1f;
    public static float playerSpeed = 15;

    [SerializeField] public Slider MasterVolSlider;
    [SerializeField] public Slider SfxVolSlider;
    [SerializeField] public Slider MusicVolSlider;
    [SerializeField] public Slider SpeedSlider;

    public void StartGame() => SceneManager.LoadScene(1);

    public void UpdateMasterVol() { PlayerPrefs.SetFloat("MasterVol", MasterVolSlider.value); AudioListener.volume = MasterVolSlider.value; }
    public void UpdateSfxVol() => PlayerPrefs.SetFloat("SfxVol", SfxVolSlider.value);
    public void UpdateMusicVol() => PlayerPrefs.SetFloat("MusicVol", MusicVolSlider.value);
    public void UpdateSpeed() => PlayerPrefs.SetFloat("Speed", SpeedSlider.value);
}
