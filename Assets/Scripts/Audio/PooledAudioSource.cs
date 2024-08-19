using UnityEngine;

public class PooledAudioSource : MonoBehaviour
{
    public SoundClip currentSoundClip;
    public AudioSource audioSource;
    public AudioLowPassFilter lowPassFilter;
    private bool _isPlaying;
    // Second flag to prevent the object from being deactivated when audio source is paused
    private bool _isPaused;

    void Start()
    {
        ScaleGame.Instance.EventRegister.ChangeVolumeEventHandler += OnChangeVolumeEvent;
        ScaleGame.Instance.EventRegister.StopSoundEventHandler += OnStopSoundEvent;
        ScaleGame.Instance.EventRegister.PauseEventHandler += OnPauseEvent;
        ScaleGame.Instance.EventRegister.UnpauseEventHandler += OnUnpauseEvent;
    }

    void Update()
    {
        if (_isPlaying && !audioSource.isPlaying && !_isPaused)
        {
            gameObject.SetActive(false);
            transform.parent = null;
        }
    }

    public void PlayClip(SoundClip clip, Transform parent = null)
    {
        // Activate this object
        gameObject.SetActive(true);
        
        // Set the parent if it exists
        if (parent)
        {
            transform.position = parent.position;
            transform.SetParent(parent);
        }
        
        _isPaused = false;
        currentSoundClip = clip;
        // Update the audio source
        AssignDefaultVolume();
        audioSource.pitch = currentSoundClip.pitch;
        audioSource.spatialBlend = currentSoundClip.dimensionality;
        audioSource.clip = currentSoundClip.NextClip();
        audioSource.loop = currentSoundClip.loop;
        audioSource.ignoreListenerPause = currentSoundClip.ignorePause;

        lowPassFilter.enabled = currentSoundClip.useLowPassFilter;
        lowPassFilter.cutoffFrequency = currentSoundClip.lowPassFilterCutoffFrequency;

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
            _isPaused = false;
            audioSource.Stop();
        }
    }

    private void OnPauseEvent(object _, PauseEvent @event)
    {
        if (!_isPlaying) return;
        if (currentSoundClip.ignorePause) return;
        _isPaused = true;
        audioSource.Pause();
    }

    private void OnUnpauseEvent(object _, UnpauseEvent @event)
    {
        if (!_isPlaying) return;
        if (currentSoundClip.ignorePause) return;
        _isPaused = false;
        audioSource.UnPause();
    }

    private void AssignDefaultVolume()
    {
        audioSource.AssignVolume(ScaleGame.Instance.Audio.VolumeValues[currentSoundClip.audioType],
            currentSoundClip.volume);
    }
}