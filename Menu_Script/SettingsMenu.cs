using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;

    public void SetVolume(float Volume)
    {
        mainMixer.SetFloat("Volume", Volume);  
    }
    public void SetFullscreen(bool isFellscreen)
    {
        Screen.fullScreen = isFellscreen;
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}   
