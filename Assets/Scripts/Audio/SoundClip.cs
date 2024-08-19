using System;
using UnityEngine;

[Serializable]
public class SoundClip
{
    [Header("Sound Information")] 
    public Sounds name;
    public AudioType audioType;
    public AudioClip[] clips;

    [Header("Sound Properties")] 
    public bool loop;
    [Range(0f, 1f)] public float volume;
    [Range(.1f, 3f)] public float pitch;
    [Tooltip("A value of 0 plays the sound fully in 2D space, a value of 1 plays the sound fully in 3D space")]
    [Range(0f, 1f)]
    public float dimensionality;

    public AudioClip NextClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
}