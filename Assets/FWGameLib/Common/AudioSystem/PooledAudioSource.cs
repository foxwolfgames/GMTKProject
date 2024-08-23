using FWGameLib.Common.AudioSystem.Event;
using FWGameLib.InProject.EventSystem;
using UnityEngine;

namespace FWGameLib.Common.AudioSystem
{
    public class PooledAudioSource : MonoBehaviour
    {
        public SoundClip currentSoundClip;
        public AudioSource audioSource;
        public AudioLowPassFilter lowPassFilter;
        [SerializeField] private Transform trackedParent;
        private bool _isPlaying;
        // Second flag to prevent the object from being deactivated when audio source is paused
        private bool _isPaused;

        void Start()
        {
            EventRegister.Instance.ChangeVolumeEventHandler += OnChangeVolumeEvent;
            EventRegister.Instance.StopSoundEventHandler += OnStopSoundEvent;
            EventRegister.Instance.PauseEventHandler += OnPauseEvent;
            EventRegister.Instance.UnpauseEventHandler += OnUnpauseEvent;
        }

        void Update()
        {
            if (trackedParent)
            {
                transform.position = trackedParent.position;
            }

            if (_isPlaying && !audioSource.isPlaying && !_isPaused)
            {
                new SoundFinishedEvent(currentSoundClip.name).Invoke();
                trackedParent = null;
                gameObject.SetActive(false);
            }
        }

        public void PlayClip(SoundClip clip, Transform parent = null)
        {
            // Activate this object
            gameObject.SetActive(true);
        
            // Set the parent if it exists
            if (parent)
            {
                trackedParent = parent;
                transform.position = parent.position;
            }
            else
            {
                trackedParent = null;
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

            if (@event.AudioVolumeType == currentSoundClip.audioVolumeType)
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
            audioSource.AssignVolume(AudioManager.Instance.VolumeValues[currentSoundClip.audioVolumeType],
                currentSoundClip.volume);
        }
    }
}