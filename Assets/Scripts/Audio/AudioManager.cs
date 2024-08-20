using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    private const int AudioSourcePoolSize = 30;
    private const float DefaultVolume = 0.5f;
    public GameObject pooledAudioSourcePrefab;
    private List<GameObject> _pooledAudioSources = new();

    public readonly Dictionary<AudioType, float> VolumeValues = new();
    public float VolumeMasterPercentage => VolumeValues[AudioType.MASTER];
    public float VolumeMusicPercentage => VolumeValues[AudioType.MUSIC];
    public float VolumeSfxPercentage => VolumeValues[AudioType.SFX];
    public float VolumeVoiceLinePercentage => VolumeValues[AudioType.VOICE_LINES];

    // Initialize all sounds in inspector
    public SoundClip[] soundClips;

    /// <summary>
    /// Sound lookup table, initialized based on soundClips
    /// </summary>
    private readonly Dictionary<Sounds, SoundClip> _sounds = new();

    public AudioManager()
    {
        foreach (AudioType audioType in Enum.GetValues(typeof(AudioType)))
        {
            VolumeValues.Add(audioType, DefaultVolume);
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            InitializeSoundsFromInspectorValues();
            InitializeAudioSourcePool();
        }
        
        // ScaleGame singleton will take care of destroying this GameObject
    }

    void Start()
    {
        ScaleGame.Instance.EventRegister.ChangeVolumeEventHandler += OnChangeVolumeEvent;
    }

    // Play a sound @ 0,0,0 using the audio source object pool
    public void PlaySound(Sounds clipName)
    {
        PlaySound(clipName, Vector3.zero);
    }

    // Play a sound @ a position using the audio source object pool
    public void PlaySound(Sounds clipName, Vector3 position)
    {
        SoundClip clip = GetSound(clipName);
        if (clip == null)
        {
            throw new NotImplementedException();
        }

        GameObject pooledAudioSource = GetPooledAudioSource();
        if (!pooledAudioSource)
        {
            Debug.LogWarning("No available audio sources in the pool");
            return;
        }

        pooledAudioSource.GetComponent<PooledAudioSource>().PlayClip(clip);
    }

    // Play a sound on a parent transform
    // NOTE POTENTIAL BUG: If the parent is destroyed before sound ends, what will happen to the pooled object???
    public void PlaySound(Sounds clipName, Transform parent)
    {
        SoundClip clip = GetSound(clipName);
        if (clip == null)
        {
            throw new NotImplementedException();
        }

        GameObject pooledAudioSource = GetPooledAudioSource();
        if (!pooledAudioSource)
        {
            Debug.LogWarning("No available audio sources in the pool");
            return;
        }

        pooledAudioSource.GetComponent<PooledAudioSource>().PlayClip(clip, parent);
    }

    [CanBeNull]
    public SoundClip GetSound(Sounds clipName)
    {
        return _sounds[clipName];
    }

    private void OnChangeVolumeEvent(object _, ChangeVolumeEvent @event)
    {
        VolumeValues[@event.AudioType] = @event.VolumePercentage;
    }

    private void InitializeSoundsFromInspectorValues()
    {
        foreach (SoundClip soundClip in soundClips)
        {
            _sounds.Add(soundClip.name, soundClip);
        }
    }

    private void InitializeAudioSourcePool()
    {
        for (int i = 0; i < AudioSourcePoolSize; i++)
        {
            GameObject pooledAudioSource = Instantiate(pooledAudioSourcePrefab);
            pooledAudioSource.SetActive(false);
            DontDestroyOnLoad(pooledAudioSource);
            _pooledAudioSources.Add(pooledAudioSource);
        }
    }

    private GameObject GetPooledAudioSource()
    {
        for (int i = 0; i < _pooledAudioSources.Count; i++)
        {
            if (!_pooledAudioSources[i].activeInHierarchy)
            {
                return _pooledAudioSources[i];
            }
        }

        return null;
    }
}

public static class AudioSourceExtensions
{
    public static void AssignVolume(this AudioSource source, float audioTypeVolume, float volume)
    {
        source.volume = audioTypeVolume * volume;
    }
}