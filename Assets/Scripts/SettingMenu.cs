using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolution;
    

    public void Start()
    {
        resolution = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        foreach (Resolution res in resolution)
        {
            options.Add($"{res.width} X {res.height}");
        }
        resolutionDropdown.AddOptions(options);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScren(bool isFullScren)
    {
        Screen.fullScreen = isFullScren;
    }
}
