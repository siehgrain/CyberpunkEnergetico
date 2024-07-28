using System;
using UnityEngine.Audio;
using UnityEngine;

public class Jukebox : MonoBehaviour
{
    public Sound[] sounds;
    public static Jukebox instance;
    private AudioSource musicSource;
    public AudioMixer mixer;

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
            s.source.clip = GetRandomClip(s);
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;

            AudioMixerGroup[] mixerGroups = mixer.FindMatchingGroups("Master");
            if (mixerGroups.Length > 0)
            {
                s.source.outputAudioMixerGroup = s.AudioMixerGroup;
            }
        }
    }

    private AudioClip GetRandomClip(Sound s)
    {
        if (s.clips.Length == 0)
        {
            Debug.LogWarning("No audio clips found for sound: " + s.name);
            return null;
        }
        int index = UnityEngine.Random.Range(0, s.clips.Length);
        return s.clips[index];
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log(name + " sound not found");
            return;
        }
        if (s.source.isPlaying)
        {
            return;
        }
        s.source.clip = GetRandomClip(s);
        s.source.Play();
    }

    public void PlayOneShoot(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log(name + " sound not found");
            return;
        }
        s.source.PlayOneShot(GetRandomClip(s));
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
        volume = Mathf.Clamp(volume, 0f, 1.0f);
        s.source.volume = volume;
        PlayerPrefs.SetFloat(name + "Volume", volume);
    }

    public void StopMusicByName(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log(name + " sound not found");
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
