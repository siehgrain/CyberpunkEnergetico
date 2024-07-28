using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Sound
{
    public AudioClip[] clips;
    public string name;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    [HideInInspector]
    public AudioSource source;
    public bool loop;
    public bool playOnAwake;
    public AudioMixer audioMixer;
    public AudioMixerGroup AudioMixerGroup;
}
