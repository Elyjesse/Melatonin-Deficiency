using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class SettingsScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    public TMP_Dropdown reDropdown;

    Resolution[] resolutions;
    private void Start()
    {
        resolutions = Screen.resolutions;

        reDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentReIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentReIndex = i;
            }
        }

        reDropdown.AddOptions(options);
        reDropdown.value = currentReIndex;
        reDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume",volume);
    }

    public void SetFullscreen(bool isFullscr)
    {
        Screen.fullScreen = isFullscr;
    }
}
