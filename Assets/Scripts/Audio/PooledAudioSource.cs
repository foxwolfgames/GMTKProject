using UnityEngine;

public class PooledAudioSource : MonoBehaviour
{
    public AudioSource audioSource;
    private bool _isPlaying;
    
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
        audioSource.AssignVolume(ScaleGame.Instance.Audio.VolumeValues[clip.audioType], clip.volume);
        audioSource.pitch = clip.pitch;
        audioSource.dopplerLevel = clip.dimensionality;
        audioSource.clip = clip.NextClip();
        audioSource.Play();
        _isPlaying = true;
    }
}