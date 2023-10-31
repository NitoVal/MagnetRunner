using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class SettingMenu : MonoBehaviour
{
    // Components' reference needed for the script to execute
    [Header("Components needed")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    // Declaration of an array of resolutions
    private Resolution[] resolution;


    
    // Start is called once, before any of the Update method is called for the first time
    public void Start()
    {
        ConfigResolutionDropdownOptions();
    }

    public void ConfigResolutionDropdownOptions()
    {
        // Local variables
        int currentResolutionIndex = 0;

        // Assign all available screen resolutions to the resolution array
        resolution = Screen.resolutions;

        // Because dropdown method AddOption() takes string as argument, create a list of string that will hold resolution as string value
        List<string> options = new List<string>();

        // For each element in the resolution array
        for (int i = 0; i < resolution.Length; i++)
        {
            // Convert the resolution in string format, then add it to the string list
            options.Add($"{resolution[i].width} X {resolution[i].height}");

            // If a resolution in the list matches the current resolution, save its index
            if (resolution[i].width == Screen.currentResolution.width && resolution[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Clear any existing relolution in the resolutionDropdown to make sure it is empty before adding new resolutions
        resolutionDropdown.ClearOptions();

        // Add all the string in the list in resolutionDropdown
        resolutionDropdown.AddOptions(options);

        // Set the initial resolution to the index found earlier
        resolutionDropdown.value = currentResolutionIndex;

        // Refresh the shown value to match the current resulution
        resolutionDropdown.RefreshShownValue();
    }


    // Sets the volume
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    // Sets the quality
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Toggle full screen 
    public void SetFullScren(bool isFullScren)
    {
        Screen.fullScreen = isFullScren;
    }

    // Sets resolution
    public void SetResolution(int resIndex)
    {
        Resolution res = resolution[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
