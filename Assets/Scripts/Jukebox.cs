using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class Jukebox : MonoBehaviour
{
    public Sound[] sounds;
    public static Jukebox instance;
    private AudioSource musicSource;
    public AudioMixer mixer;
    // Start is called before the first frame update
    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume= s.volume;
            s.source.pitch= s.pitch;
            s.source.loop= s.loop;
            s.source.playOnAwake = s.playOnAwake;
            // Obt�m o grupo "Master" do AudioMixer
            AudioMixerGroup[] mixerGroups = s.audioMixer.FindMatchingGroups("Master");
            if (mixerGroups.Length > 0)
            {
                s.source.outputAudioMixerGroup = s.AudioMixerGroup;
            }
        }
        
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null) 
        {
            Debug.Log(s.name +"sound not found");
            return;
        }
        if (s.source.isPlaying)
        {
            return;
        }
        s.source.Play();
    }
    public void PlayOneShoot(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log(s.name + "sound not found");
            return;
        }
        s.source.PlayOneShot(s.clip);
    }
    private void Start()
    {
        musicSource = GetComponent<AudioSource>();
        SetVolume("SfxVolume");
        SetVolume("MusicVolume");
    }
    public void SetMusicVolume(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log(name + " sound not found");
            return;
        }
        volume = Mathf.Clamp(volume, 0f, 1.0f); // Garante que o volume esteja entre 0.0001 e 1.0
        s.source.volume = volume;
        PlayerPrefs.SetFloat(name + "Volume", volume); // Salva o volume específico da música
    }
    public void StopMusicByName(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log(s.name + "sound not found");
            return;
        }
        s.source.Stop();
    }
    void SetVolume(string parameterName)
    {
        float savedVolume = PlayerPrefs.GetFloat(parameterName, 1.0f);
        mixer.SetFloat(parameterName, Mathf.Log10(savedVolume) * 20);
    }

}
