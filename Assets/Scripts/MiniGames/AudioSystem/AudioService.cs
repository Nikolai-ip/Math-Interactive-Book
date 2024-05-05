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
        [SerializeField] private bool[] _audioSourceLoop;
        private Dictionary<string, AudioSource> _audioSourcesMap = new();
        public AudioService PlaySound(string soundName)
        {
            if (TryGetAudioSource(soundName, out AudioSource audioSource) && !audioSource.isPlaying)
            {
                audioSource.Play();
            }

            return this;
        }

        private void OnValidate()
        {
            if (_audioSourceLoop.Length!= _audioClips.Length)
                _audioSourceLoop = new bool[_audioClips.Length];
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
            for (var i = 0; i < _audioClips.Length; i++)
            {
                var audioClip = _audioClips[i];
                var name = audioClip.name;
                var audioClipObject = new GameObject(name);
                audioClipObject.transform.SetParent(transform);
                var audioSource = audioClipObject.AddComponent<AudioSource>();
                audioSource.clip = audioClip;
                audioSource.playOnAwake = false;
                audioSource.loop = _audioSourceLoop[i];
                _audioSourcesMap.Add(audioClip.name, audioSource);
            }
        }
    }
}