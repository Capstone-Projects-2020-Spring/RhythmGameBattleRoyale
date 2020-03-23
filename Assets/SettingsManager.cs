using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Slider masterVolumeSlider;
    public Button applyButton;

    public Resolution[] resolutions;
    public GameSettings gameSettings;

    void OnEnable()
    {
        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate{ OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate{ OnResolutionChange(); });
        masterVolumeSlider.onValueChanged.AddListener(delegate{ onVolumeChange(); });
        applyButton.onClick.AddListener(delegate{ SaveSettings(); });

        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
    }

    public void OnFullscreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
        Debug.Log("Fulscreen toggled!");
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        Debug.Log("Resolution modified!");
    }

    public void onVolumeChange()
    {
        gameSettings.masterVolume = masterVolumeSlider.value;
        Debug.Log("Volume set to: " + gameSettings.masterVolume);
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
        Debug.Log("Settings saved to gamesettings.json");
    }

    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(Application.persistentDataPath + "/gamesettings.json");
        masterVolumeSlider.value = gameSettings.masterVolume;
        resolutionDropdown.value = gameSettings.resolutionIndex;
        fullscreenToggle.isOn = gameSettings.fullscreen;
    }
}
