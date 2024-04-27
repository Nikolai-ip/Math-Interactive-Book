using System;
using System.Collections;
using System.Collections.Generic;
using MiniGames.ServiceLocatorModule;
using UnityEngine;

namespace MiniGames.AudioSystem
{
    public class AudioService:InitializeableMono, IService
    {
        [SerializeField] private AudioClip[] _audioClips;
        private Dictionary<string, AudioSource> _audioSourcesMap = new();
        public AudioService PlaySound(string soundName)
        {
            if (TryGetAudioSource(soundName, out AudioSource audioSource) && !audioSource.isPlaying)
            {
                audioSource.Play();
            }

            return this;
        }

        public void SetGlobalVolume(float volume)
        {
            foreach (var audioSource in _audioSourcesMap)
            {
                audioSource.Value.volume = volume;
            }
        }
        public AudioService SetVolume(string soundName, float volume)
        {
            if (TryGetAudioSource(soundName, out AudioSource audioSource))
            {
                audioSource.volume = volume;
            }
            return this;
        }
        public AudioService Stop(string soundName)
        {
            if (TryGetAudioSource(soundName, out AudioSource audioSource))
            {
                audioSource.Stop();
            }
            return this;
        }

        public AudioService SetLoop(string soundName, bool loop)
        {
            if (TryGetAudioSource(soundName, out AudioSource audioSource))
            {
                audioSource.loop = loop;
            }
            return this;
        }

        public AudioService SlowMuteSound(string soundName, float time=1f)
        {
            if (TryGetAudioSource(soundName, out AudioSource audioSource))
            {
                StartCoroutine(SlowMuteSoundCoroutine(audioSource, time));
            }

            return this;
        }

        private IEnumerator SlowMuteSoundCoroutine(AudioSource audioSource, float time)
        {
            float elapsedTime = 0;
            float originalVolume = audioSource.volume;
            while (elapsedTime < time)
            {
                elapsedTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(originalVolume, 0, elapsedTime / time);
                yield return null;
            }
        }
        private bool TryGetAudioSource(string soundName, out AudioSource audioSource)
        {
            if (_audioSourcesMap.TryGetValue(soundName, out AudioSource audio))
            {
                audioSource = audio;
                return true;
            }
            Debug.LogError($"Failed to find the {soundName} audio");
            audioSource = null;
            return false;
        }

        public override void Init()
        {
            foreach (var audioClip in _audioClips)
            {
                var gameObject = Instantiate(new GameObject(audioClip.name), transform);
                var audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = audioClip;
                audioSource.playOnAwake = false;
                _audioSourcesMap.Add(audioClip.name, audioSource);
            } 
        }
    }
}