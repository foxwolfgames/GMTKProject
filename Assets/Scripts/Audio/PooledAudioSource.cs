using UnityEngine;

public class PooledAudioSource : MonoBehaviour
{
    public SoundClip currentSoundClip;
    public AudioSource audioSource;
    private bool _isPlaying;

    void Start()
    {
        ScaleGame.Instance.EventRegister.ChangeVolumeEventHandler += OnChangeVolumeEvent;
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
        gameObject.SetActive(true);
        currentSoundClip = clip;
        audioSource.AssignVolume(ScaleGame.Instance.Audio.VolumeValues[clip.audioType], clip.volume);
        audioSource.pitch = clip.pitch;
        audioSource.dopplerLevel = clip.dimensionality;
        audioSource.clip = clip.NextClip();
        audioSource.Play();
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
}