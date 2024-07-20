using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider slider;
    [SerializeField] private string parameterName;

    private void Awake()
    {
        float savedVolume = PlayerPrefs.GetFloat(parameterName, slider.value); ;
        slider.value = savedVolume;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat(parameterName, Mathf.Log10(volume) * 20);
        slider.value = volume;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat(parameterName, slider.value);
        PlayerPrefs.Save(); 
    }
}
