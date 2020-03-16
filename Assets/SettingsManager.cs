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
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
    }

    public void onVolumeChange()
    {
        gameSettings.masterVolume = masterVolumeSlider.value;
    }

    public void SaveSettings()
    {
        //string jsonData = jsonUtility.ToJson(gameSettings, true);
        //File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }

    public void LoadSettings()
    {

    }
}
