using System;
using UnityEngine;
using Random = UnityEngine.Random;

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
    public bool ignorePause;

    [Tooltip("A value of 0 plays the sound fully in 2D space, a value of 1 plays the sound fully in 3D space")]
    [Range(0f, 1f)]
    public float dimensionality;

    public bool useLowPassFilter = false;
    public float lowPassFilterCutoffFrequency = 1000f;

    public SoundClipStrategy soundClipStrategy = SoundClipStrategy.RANDOM;
    private int _clipIndex = 0;

    public AudioClip NextClip()
    {
        switch (soundClipStrategy)
        {
            case SoundClipStrategy.SEQUENTIAL:
                AudioClip clip = clips[_clipIndex];
                _clipIndex = (_clipIndex + 1) % clips.Length;
                return clip;
            case SoundClipStrategy.RANDOM:
            default:
                return clips[Random.Range(0, clips.Length)];
        }
    }
}

public enum SoundClipStrategy
{
    RANDOM,
    SEQUENTIAL
}