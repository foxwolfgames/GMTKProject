using System;
using UnityEngine;

public class PooledAudioSource : MonoBehaviour
{
    public SoundClip currentSoundClip;
    public AudioSource audioSource;
    private bool _isPlaying;

    void Start()
    {
        ScaleGame.Instance.EventRegister.ChangeVolumeEventHandler += OnChangeVolumeEvent;
        ScaleGame.Instance.EventRegister.StopSoundEventHandler += OnStopSoundEvent;
    }
    
    void Update()
    {
        if (_isPlaying && !audioSource.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }

    public void PlayClip(SoundClip clip)
    {
        // Activate this object
        gameObject.SetActive(true);
        currentSoundClip = clip;
        // Update the audio source
        audioSource.AssignVolume(ScaleGame.Instance.Audio.VolumeValues[currentSoundClip.audioType], currentSoundClip.volume);
        audioSource.pitch = currentSoundClip.pitch;
        audioSource.dopplerLevel = currentSoundClip.dimensionality;
        audioSource.clip = currentSoundClip.NextClip();
        audioSource.loop = currentSoundClip.loop;
        audioSource.Play();
        // Flag as playing
        _isPlaying = true;
    }

    private void OnChangeVolumeEvent(object _, ChangeVolumeEvent @event)
    {
        if (!_isPlaying) return;
        
        if (@event.AudioType == currentSoundClip.audioType)
        {
            audioSource.AssignVolume(@event.VolumePercentage, currentSoundClip.volume);
        }
    }

    private void OnStopSoundEvent(object _, StopSoundEvent @event)
    {
        if (!_isPlaying) return;

        if (currentSoundClip.name == @event.SoundName)
        {
            // Update loop will take care of deactivating the object
            audioSource.Stop();
        }
    }
}